using System;
using System.IO;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

namespace _8_Ball_magic
{
    class Program
    {
        static bool realchat = false;
        static string prefix = "+k";

        static async Task Main()
        {
            DiscordSocketClient client = new DiscordSocketClient();
            client.MessageReceived += Client_MessageReceived;
            client.ReactionAdded += Client_ReactionAdded;
            client.Log += Client_Log;

            var token = GetToken();

            await client.LoginAsync(TokenType.Bot, token);
            await client.StartAsync();
            do
            {
                Console.ReadLine();
            } while (true);
        }

        static private string GetToken()
        {
            string token = "";
            using(StreamReader sr = new StreamReader("C://Users//kano//Desktop//token.txt"))
            {
                token = sr.ReadLine();
            }
            return (token);
        }

        private static Task Client_ReactionAdded(Cacheable<IUserMessage, ulong> arg1, Cacheable<IMessageChannel, ulong> arg2, SocketReaction arg3)
        {
            /*
            if (arg3.Emote
            Console.WriteLine("ReactionAdded");
            */
            return Task.CompletedTask;
        }

        static private Task Client_Log(LogMessage arg)
        {
            Console.WriteLine(arg);
            return Task.CompletedTask;
        }

        static Random rd = new Random();

        static private Task Client_MessageReceived(SocketMessage message)
        {
            if (message.Content.StartsWith(prefix + " шар") && !message.Author.IsBot && !realchat)
            {
                Eight_Ball(message);
            }
            else if (message.Content.StartsWith(prefix + " ДаНет") && !message.Author.IsBot)
            {
                YesNO(message);
            }
            else if ((message.Content.StartsWith(prefix + " Ранд ") || message.Content.StartsWith(prefix + " ранд ")) && !message.Author.IsBot)
            {
                RandMessage(message);
            }
            else if (message.Content.StartsWith(prefix + " Тест") && !message.Author.IsBot)
            {
                message.Channel.SendMessageAsync("Вы ввели не верное значение");
                var heartEmoji = new Emoji("\U0001f495");
                var emote = Emote.Parse("<:igorNotSmile:877385578784620574>");
                message.AddReactionAsync(emote);
            }
            else if (message.Content.StartsWith(prefix + " Пинге") && !message.Author.IsBot)
            {
                for (int i = 0; i < 5; i++)
                {
                    message.Channel.SendMessageAsync("<@!500315437800882196>");
                }
            }
            else if ((message.Content.StartsWith(prefix + " Хелп") || message.Content.StartsWith(prefix + " хелп")) && !message.Author.IsBot)
            {
                message.Channel.SendMessageAsync($"```команды лоха-бота \n {prefix} шар - это команда шара удачи \n {prefix} ДаНет - помогает в с ответом на вопрос да или нет  \n {prefix} Ранд - помогает выбрать случайное число ```");
            }
            else if ((message.Content.StartsWith(prefix + " КНБ") || message.Content.StartsWith(prefix + " хелп")) && !message.Author.IsBot)
            {
                RPS_Game(message);
            }
            else if (message.Content.StartsWith(prefix) && !message.Author.IsBot)
            {
                message.Channel.SendMessageAsync($"В моей базе данных нет подобной команды, попробуйте *{prefix} хелп*, для  помощи");
            }
            return Task.CompletedTask;
        }
        static private Task RandMessage(SocketMessage message)
        {
            string Rand = message.Content;
            Rand = Rand.Remove(0, 8);
            try
            {
                int randomInt = int.Parse(Rand);
                Rand = (rd.Next(randomInt) + 1).ToString();
                message.Channel.SendMessageAsync(Rand);
            }
            catch (Exception)
            {
                message.Channel.SendMessageAsync("Вы ввели не верное значение");
            }
            return Task.CompletedTask;
        }

        static private Task YesNO(SocketMessage message)
        {
            int YesNO = rd.Next(2);
            switch (YesNO)
            {
                case 0:
                    message.Channel.SendMessageAsync(":red_circle: Нет");
                    break;
                case 1:
                    message.Channel.SendMessageAsync(":green_circle: Да");
                    break;
            }
            return Task.CompletedTask;
        }

        static private Task Eight_Ball(SocketMessage message)
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
            return Task.CompletedTask;
        }

        static private Task RPS_Game(SocketMessage message)
        {
        int playerTurn = 0;
        int rdKNB = rd.Next(3);
        string Rand = message.Content;
        Rand = Rand.Remove(0, 7);
                if (Rand == "ножницы")
                {
                    playerTurn = 1;
                }
                else if (Rand == "камень")
                {
                    playerTurn = 0;
                }
                else if (Rand == "бумага")
                {
                    playerTurn = 2;
                }
                else
                {
                    message.Channel.SendMessageAsync("я вас не понял");
                }
                switch (rdKNB)
                {
                    case 0:
                        message.Channel.SendMessageAsync("камень :rock:");
                        break;
                    case 1:
                        message.Channel.SendMessageAsync("ножницы :scissors:");
                        break;
                    case 2:
                        message.Channel.SendMessageAsync("бумага :roll_of_paper:");
                        break;
                }
                switch (playerTurn)
                {
                    case 0:
                        if (rdKNB == 0)
                        {
                            message.Channel.SendMessageAsync("ничья");
                        }
                        else if (rdKNB == 1)
                        {
                            message.Channel.SendMessageAsync("вы выйграли");
                        }
                        else if (rdKNB == 2)
                        {
                            message.Channel.SendMessageAsync("вы проиграли");
                        }
                        break;
                    case 1:
                        if (rdKNB == 0)
                        {
                            message.Channel.SendMessageAsync("вы проиграли");
                        }
                        else if (rdKNB == 1)
                        {
                            message.Channel.SendMessageAsync("ничья");
                        }
                        else if (rdKNB == 2)
                        {
                            message.Channel.SendMessageAsync("вы выйграли");
                        }
                        break;
                    case 2:
                        if (rdKNB == 0)
                        {
                            message.Channel.SendMessageAsync("вы выйграли");
                        }
                        else if (rdKNB == 1)
                        {
                            message.Channel.SendMessageAsync("вы проиграли");
                        }
                        else if (rdKNB == 2)
                        {
                            message.Channel.SendMessageAsync("ничья");
                        }
                        break;
                }
            return Task.CompletedTask;
        }
    }
}
