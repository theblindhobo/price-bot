using Discord.WebSocket;

namespace PriceBot
{
    /// <summary>
    ///     Caches stateful variables of the current instance.
    /// </summary>
    public static class State
    {
        /// <summary>
        ///     Gets or sets the command line arguments.
        /// </summary>
        public static Options Options { get; set; }

        /// <summary>
        ///     The discord socket client.
        /// </summary>
        public static DiscordSocketClient Client { get; set; }
    }
}
