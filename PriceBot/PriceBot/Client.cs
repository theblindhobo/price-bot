using System;
using System.Net.Http;
using System.Net.Http.Json;
using PriceBot.Models;


namespace PriceBot
{
    /// <summary>
    ///     Client to interact with the 0x-API.
    /// </summary>
    public class Client
    {
        const string BasePath = "https://api.0x.org/swap/v1/";
        HttpClient client;

        /// <summary>
        ///     ctor
        /// </summary>
        public Client()
        {
            client = new HttpClient()
            {
                BaseAddress = new Uri(BasePath),
            };
        }

        /// <summary>
        ///     Gets the current weth price of the specified token.
        /// </summary>
        /// <returns></returns>
        public PriceObj GetWethPrice()
        {
            return client.GetFromJsonAsync<PriceObj>($"price?sellToken=weth&buyToken={State.Options.TokenAddress}&buyAmount={State.Options.BuyAmount}").Result;
        }

        /// <summary>
        ///     Gets the current usdc price of the specified token.
        /// </summary>
        /// <returns></returns>
        public PriceObj GetUsdcPrice()
        {
            return client.GetFromJsonAsync<PriceObj>($"price?sellToken=usdc&buyToken={State.Options.TokenAddress}&buyAmount={State.Options.BuyAmount}").Result;
        }
    }
}
