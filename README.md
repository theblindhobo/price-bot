# Discord Price-Bot for Ethereum Tokens
A discord bot which could be added to your server for price information about a specified token.

# Usage

## Requirements
- Install .NET https://dotnet.microsoft.com/download/dotnet/5.0
- Create your own discord bot https://discordpy.readthedocs.io/en/latest/discord.html

## Run your instance

```
dotnet run -d "<your discord bot token here>" -n "<your eth-token name here>" -t "<your eth-token address here" -a "<your buyAmount here>"

-d - Go to https://discord.com/developers/applications --> Select your bot --> Copy your 58-char-token

-n - Set the name of the bot

-t - Set the ethereum address of the token, e.g. "0x26c7d50b9f372e1fa9ca078cc054298f36d68b17"

-a - Specify the number for which you want to calculate the price. 
Note that you have to multiply your amount by (10^(number of decimal places - 1)). 
For example, if your token has 18 decimal places and you want to calculate the price for 1 token, then you pass as argument "100000000000000000". 
```


