using System;
using System.Collections;

namespace EnglishQuestion.Logical 
{
    public class LogicalClass : SubLogicClass, IComparable
    {

        private IPlayer _player;

        WordsDataBase[] wdbVariants = new WordsDataBase[4];
        private WordsDataBase trueVariant;

        public LogicalClass(WordsDataBase[] wdb, int lenght) : base(wdb,lenght){}

        public LogicalClass(IPlayer player,WordsDataBase[] wdb, int lenght, bool ru)
            : base(wdb, lenght, ru)
        {
            _player = player;
        }

        public string[] GetdVariants()
        {
            if (CheckWordsForQuestion())
            {
                string[] variants = new string[4];

                wdbVariants[0] = GetWordsForQuestion(true);
                wdbVariants[1] = GetWordsForFakeAnswers(false);
                wdbVariants[2] = GetWordsForFakeAnswers(false);
                wdbVariants[3] = GetWordsForFakeAnswers(false);

                trueVariant = wdbVariants[0];

                Array.Sort(wdbVariants);
                for (int i = 0; i < wdbVariants.Length; i++)
                {
                    variants[i] = wdbVariants[i].RussianWord;
                }

                return variants;
            }
            return null;
        }

        public string GetWord()
        {
            return trueVariant.EnglishWord;
        }

        public bool Move(string word)
        {
            if (trueVariant.RussianWord == word)
            {
                _player.MovePlayer(true, word);
                return true;
            }
            _player.MovePlayer(false, word);
            return false;
        }
 
        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }

        string CheckForWinners(Player one, Player two)
        {
            string message;
            Player winer;
            if (two == null)
                message = "Игрок " + one.Name + " набрал " + one.Scores + " очков из " + _arrayLenght;
            if (one.Scores > two.Scores)
            {
                winer = one;
            }
            else winer = two;
            message = "Игрок " + winer.Name + " набрал " + winer.Scores + " и выиграл эту игру!";
            return message;
        }
    }
}
