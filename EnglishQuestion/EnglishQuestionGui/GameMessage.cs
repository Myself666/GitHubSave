using System;
using System.Linq;

namespace EnglishQuestionGui
{
    static class GameMessage
    {
        public static string Russian(MessageType type)
        {
            return MessageDictionary.First(message => message.Item1 == type).Item3;
        }

        public static string English(MessageType type)
        {
            return MessageDictionary.First(message => message.Item1 == type).Item2;
        }

        private static readonly Tuple<MessageType, string, string>[] MessageDictionary =
        {
            new Tuple<MessageType, string, string>(MessageType.Hello, 
                "Greetings from Seal and his creation.\n" +
                "This game is made to streighten the English language knowledge.\n" + 
                "For now there are {0} word pairs in the database.\n" +
                "It is never late to add more.",
                "Вас приветствует Тюлень и его произведение.\n" +
                "Данная игра сделана с целью подкрепления знаний в Английском языке.\n" +
                "На данный момент в базе данных содержится {0} пар слов.\n" +
                "Никогда не поздно пополнить их."),
            new Tuple<MessageType, string, string>(MessageType.MakeMove,
                "Please select the correct translation of the word", "Пожалуйста выберите корректный перевод слова"),
            new Tuple<MessageType, string, string>(MessageType.Win, "Congratulations! {0} is the winner!!!",
                "Поздравляем! {0} победитель!!!")
        };
    }
}
