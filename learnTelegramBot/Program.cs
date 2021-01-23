using learnTelegramBot.Command.Commands;
using System;
using System.Collections.Generic;
using Telegram.Bot;
using Telegram.Bot.Args;
using learnTelegramBot.CoreParser;
using learnTelegramBot.CoreParser.Avito;

namespace learnTelegramBot
{
    class Program
    {
       private static TelegramBotClient client;
       private static List<Command.Command> commands;
     //  private static ParserWorker<string[]> parser;


        static void Main()
        {
            client = new TelegramBotClient(CoreTelegram.Config.Token);
           // parser = new ParserWorker<string[]>(new AvitoParser());
           // parser.Settings = new AvitoSettings(1, 5);
            client.StartReceiving();
            AddCommand();
            client.OnMessage += OnMessageHandler;
          //  parser.OnNewData += Parser_OnNewData;
            Console.ReadKey();
            client.StopReceiving();
        }


   private static async void OnMessageHandler(object sender, MessageEventArgs e)
   {
       var message = e.Message;
       if (message.Text != null)
       {
           Console.WriteLine($"[Log]: Пришло новое сообщение! От:{message.From.FirstName} {message.From.LastName} с текстом: {message.Text}");
  
              foreach (var comm in commands)
              {
                  if (comm.Contains(message.Text))
                  {
                      comm.Execute(message, client);
                  }
              }
        }
    }
         private static void AddCommand()
        {
            commands = new List<Command.Command>();
            commands.Add(new GetMyIdCommand());
            commands.Add(new GetChatIdCommand());
            commands.Add(new GetAvito());
        }

     //  private static void Parser_OnNewData(object arg1, string[] arg2)
     //  {
     //      for (int i = 0; i < arg2.Length; i++)
     //      {
     //          Console.WriteLine(arg2[i]);
     //      }
     //  }


    }
}
