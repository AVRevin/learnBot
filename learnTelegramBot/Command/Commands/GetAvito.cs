using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;
using learnTelegramBot.CoreParser;
using learnTelegramBot.CoreParser.Avito;
using System.Threading;

namespace learnTelegramBot.Command.Commands
{
    public class GetAvito:Command
    {
        private static ParserWorker<string[]> parser;
        public override string[] Names { get; set; } = new string[] {"avito"};
        public static string temp = null;
        public override async void Execute(Message message, TelegramBotClient client)
        {
            parser = new ParserWorker<string[]>(new AvitoParser());
            parser.Settings = new AvitoSettings(1, 5);
            parser.Start();
            parser.OnNewData += Parser_OnNewData;
            Thread.Sleep(5000);
            await client.SendTextMessageAsync(message.Chat.Id, temp);
        }

        private static void Parser_OnNewData(object arg1, string[] arg2)
        {
           temp = arg2[0];
        }
    }
}
