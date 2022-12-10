using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Args;

namespace arana
{
    class program
    {
        private static string token { get; set; } = new("5971052723:AAFp_-J3sQNBs2UDX_NdqgXGyrI0dinhqMg");

        private const string earth = "earth";
        private const string moon = "moon";
        private const string mercury = "mercury";
        private static TelegramBotClient client;
      

        static void Main(string[] args)
        {
            client = new TelegramBotClient(token);
            client.StartReceiving();
            client.OnMessage += message;
            Console.ReadLine();
            client.StopReceiving();

        }
        private static async void message(object sender, MessageEventArgs e)
        {
            var msg = e.Message;
            {
                await client.SendTextMessageAsync(msg.Chat.Id, msg.Text, replyToMessageId: msg.MessageId);
            }
        }

        private IReplyMarkup GetButton()
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton>{new KeyboardButton{ Text = earth}, new KeyboardButton{ Text = moon }},
                    new List<KeyboardButton>{ new KeyboardButton{ Text = mercury},}

                }
            };
        }
    }
}
