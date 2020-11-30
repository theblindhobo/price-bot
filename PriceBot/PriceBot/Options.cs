using CommandLine;

namespace PriceBot
{
    /// <summary>
    ///     Class to parametrize the price bot.
    /// </summary>
    public class Options
    {
        /// <summary>
        ///     Gets or sets the Discord-Token.
        /// </summary>
        [Option('d', "discordToken", Required = false, HelpText = "Set the discord token for the bot.")]
        public string DiscordToken { get; set; }

        /// <summary>
        ///     Gets or sets the API token.
        /// </summary>
        [Option('n', "tokenName", Required = false, HelpText = "Set the name of the bot/token.")]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the API token.
        /// </summary>
        [Option('t', "tokenAddress", Required = false, HelpText = "Set the token address")]
        public string TokenAddress { get; set; }

        /// <summary>
        ///     Gets or sets the API token.
        /// </summary>
        [Option('a', "buyAmount", Required = false, HelpText = "Set the buy amount (extend the decimal count, e.g. for 1 Token with 6 decimals use 100000")]
        public string BuyAmount { get; set; }
    }
}
