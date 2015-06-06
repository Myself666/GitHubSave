using EnglishQuestion;
using EnglishQuestion.Logical;

namespace EnglishQuestionGui
{
    static class GameStub
    {
        static WordsDataBase[] wdbBase = new WordsDataBase[12];
        private static IPlayer _newPlayer;
        private static SaveLoadClass _sNloadClass = new SaveLoadClass();

        public const int WordCount = 999;

        public static string[] GetVariants()
        {
            return new[] { "Лол 1", "Лол 2", "Лол 3", "Лол 4" };
        }

        public static string[] GetWord()
        {
            return new[] { "Word" };
        }

        public static bool Move(int selectedVariant)
        {
            return true;
        }

        public static void LoadGame()
        {
        }
    }
}
