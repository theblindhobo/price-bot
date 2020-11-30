using CommandLine;
using Discord;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;

namespace PriceBot
{
    /// <summary>
    ///     Main part of the application.
    /// </summary>
    public class Program : IDisposable
    {
        private static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args).MapResult((opts) => RunOptions(opts), errs => HandleParseError(errs));
        }


        /// <summary>
        ///     Set the current variables, received by the command line arguments.
        /// </summary>
        /// <param name="opts">Options which where received.</param>
        public static int RunOptions(Options opts)
        {
            State.Options = opts;
            using var program = new Program();
            program.MainAsync().GetAwaiter().GetResult();
            return 0;
        }

        /// <summary>
        ///     Handles wrong command line arguments.
        /// </summary>
        /// <param name="errs">Errs which were received.</param>
        public static int HandleParseError(IEnumerable<Error> errs)
        {
            foreach (var err in errs)
            {
                Log(new LogMessage(LogSeverity.Error, "CommandLineArguments", err.Tag.ToString())).Wait();
            }
            return -1;
        }

        // Log the given message to the output console.
        public static Task Log(LogMessage message)
        {
            switch (message.Severity)
            {
                case LogSeverity.Critical:
                case LogSeverity.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;

                case LogSeverity.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;

                case LogSeverity.Info:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;

                case LogSeverity.Verbose:
                case LogSeverity.Debug:
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    break;
            }
            Console.WriteLine($"{DateTime.Now,-19} [{message.Severity,8}] {message.Source}: {message.Message} {message.Exception}");
            Console.ResetColor();

            return Task.CompletedTask;
        }

        private Program()
        {
            State.Client = new DiscordSocketClient(new DiscordSocketConfig
            {
                LogLevel = LogSeverity.Info,
            });

            State.Client.Log += Log;
        }

        private async Task MainAsync()
        {
            // Login and connect.
            await State.Client.LoginAsync(TokenType.Bot, State.Options.DiscordToken);
            await State.Client.StartAsync();

            // Set name and refreshing tasks
            var client = new Client();
            var task = new PeriodicTask();
            await task.Run(() =>
            {
                var weth = client.GetWethPrice();
                var usdc = client.GetUsdcPrice();
                var usdcPrice = (double.TryParse(usdc.Price, NumberStyles.Any, CultureInfo.InvariantCulture, out var parsedUsdcValue) ? Math.Round(parsedUsdcValue, 2) : double.NaN).ToString(CultureInfo.InvariantCulture);
                var wethPrice = (double.TryParse(weth.Price, NumberStyles.Any, CultureInfo.InvariantCulture, out var parsedWethValue) ? Math.Round(parsedWethValue, 12) : double.NaN).ToString(CultureInfo.InvariantCulture);

                foreach (var guild in State.Client.Guilds)
                {
                    var user = guild.GetUser(State.Client.CurrentUser.Id);
                    user.ModifyAsync(x => { x.Nickname = $"{State.Options.Name} ${usdcPrice}"; }).GetAwaiter().GetResult();
                }

                //State.Client?.Rest?.CurrentUser?.ModifyAsync(b => b.Username = $"{State.Options.Name} ${(double.TryParse(usdc.Price, NumberStyles.Any, CultureInfo.InvariantCulture, out var value) ? Math.Round(value, 2) : double.NaN)}");
                State.Client.SetGameAsync($"ETH {wethPrice}").GetAwaiter().GetResult();
            }, TimeSpan.FromMinutes(1));
        }

        #region IDisposable

        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                State.Client.Dispose();
                disposedValue = true;
            }
        }

        ~Program()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable Support
    }
}