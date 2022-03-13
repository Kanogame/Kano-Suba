using System;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

namespace _8_Ball_magic
{
    class Program
    {
        //private readonly DiscordSocketClient client;
        static bool realchat = false;
        static string cons = "";

        static async Task Main()
        {
            DiscordSocketClient client = new DiscordSocketClient();
            client.MessageReceived += Client_MessageReceived;
            if (!realchat)
            {
                client.Log += Client_Log;
            }
            else
            {
                client.Log -= Client_Log;
            }

            var token = "";

            await client.LoginAsync(TokenType.Bot, token);
            await client.StartAsync();

            string a = "";
            do
            {
                Console.ReadLine();
            } while (a != "real chat" || realchat);
            if (a == "real chat")
            {
                realChat();
                
            }
        }

        static private Task Client_Log(LogMessage arg)
        {
            Console.WriteLine(arg);
            return Task.CompletedTask;
        }

        static private void realChat()
        {
            realchat = true;
        }

        static private Task Client_MessageReceived(SocketMessage message)
        {
            Random rd = new Random();
            if (message.Content.StartsWith("+лох шар") && !message.Author.IsBot && !realchat)
            {
                int A = rd.Next(20);
                switch (A)
                {
                    case 1:
                        message.Channel.SendMessageAsync(":green_circle: Бесспорно");
                        break;
                    case 2:
                        message.Channel.SendMessageAsync(":green_circle: Предрешено");
                        break;
                    case 3:
                        message.Channel.SendMessageAsync(":green_circle: Никаких сомнений");
                        break;
                    case 4:
                        message.Channel.SendMessageAsync(":green_circle: Определённо да");
                        break;
                    case 5:
                        message.Channel.SendMessageAsync(":green_circle: Можешь быть уверен в этом");
                        break;
                    case 6:
                        message.Channel.SendMessageAsync(":yellow_circle: Мне кажется — «да»");
                        break;
                    case 7:
                        message.Channel.SendMessageAsync(":yellow_circle: Вероятнее всего");
                        break;
                    case 8:
                        message.Channel.SendMessageAsync(":yellow_circle: Хорошие перспективы");
                        break;
                    case 9:
                        message.Channel.SendMessageAsync(":yellow_circle: Знаки говорят — «да»");
                        break;
                    case 10:
                        message.Channel.SendMessageAsync(":yellow_circle: Да");
                        break;
                    case 11:
                        message.Channel.SendMessageAsync(":orange_circle: Пока не ясно, попробуй снова");
                        break;
                    case 12:
                        message.Channel.SendMessageAsync(":orange_circle: Лучше не рассказывать");
                        break;
                    case 13:
                        message.Channel.SendMessageAsync(":orange_circle: Сейчас нельзя предсказать");
                        break;
                    case 14:
                        message.Channel.SendMessageAsync(":orange_circle: Сконцентрируйся и спроси опять");
                        break;
                    case 15:
                        message.Channel.SendMessageAsync(":orange_circle: Спроси позже");
                        break;
                    case 16:
                        message.Channel.SendMessageAsync(":red_circle: Мой ответ — «нет»");
                        break;
                    case 17:
                        message.Channel.SendMessageAsync(":red_circle: По моим данным — «нет»");
                        break;
                    case 18:
                        message.Channel.SendMessageAsync(":red_circle: Перспективы не очень хорошие");
                        break;
                    case 19:
                        message.Channel.SendMessageAsync(":red_circle: Весьма сомнительно");
                        break;
                    case 0:
                        message.Channel.SendMessageAsync(":red_circle: Даже не думай");
                        break;
                    }
                }    
            else if (realchat)
            {
                message.Channel.SendMessageAsync(cons);
            }
            return Task.CompletedTask;
        }
    }
}
