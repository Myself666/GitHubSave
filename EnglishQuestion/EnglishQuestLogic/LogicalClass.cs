using System;
using System.Collections;

namespace EnglishQuestion.Logical 
{
    public class LogicalClass : IComparable
    {
        private WordsDataBase[] _wordsDataBaseUsed;

        private int _arrayLenght;
        private Random _rand = new Random();
        
        public LogicalClass(WordsDataBase[] wdb, int lenght)
        {
            _wordsDataBaseUsed = new WordsDataBase[lenght];
            _wordsDataBaseUsed = wdb;
            _arrayLenght = lenght;
        }

        public bool WordsCheck(WordsDataBase wdbQuestion, WordsDataBase wdbAnswer)
        {
            return wdbQuestion.IdValue == wdbAnswer.IdValue;
        }

        public WordsDataBase GetWordsForQuestion(bool rus)
        {
            WordsDataBase keyWord = null;
            int indRand;
            int cycles = 1;
            if (CheckWordsForQuestion())
            {
                for (int i = 0; i < cycles; i++)
                {
                    indRand = _rand.Next(_arrayLenght);
                    if (_wordsDataBaseUsed[indRand].Used)
                    {
                        cycles++;
                        continue;
                    }
                    if (rus)
                    {
                        keyWord = _wordsDataBaseUsed[indRand];
                        _wordsDataBaseUsed[indRand].Used = true;
                        _wordsDataBaseUsed[indRand].FakeUse = true;
                    }
                    else
                    {
                        keyWord = _wordsDataBaseUsed[indRand];
                        _wordsDataBaseUsed[indRand].Used = true;
                        _wordsDataBaseUsed[indRand].FakeUse = true;
                    }
                }
            }
            else
            {
                Console.WriteLine("Было отвечено на все вопросы");
            }
            return keyWord;
        }

        public WordsDataBase GetWordsForFakeAnswers(bool rus)
        {
            WordsDataBase keyWord = null;
            int indRand;
            int cycles = 1;
            int indexOfKeyWords = 0;
            for (int i = 0; i < cycles; i++)
            {
                indRand = _rand.Next(_arrayLenght - 1);
                if (_wordsDataBaseUsed[indRand].FakeUse)
                {
                    cycles++;
                    continue;           
                }
                if (rus)
                    {
                        keyWord = _wordsDataBaseUsed[indRand];
                        _wordsDataBaseUsed[indRand].FakeUse = true;
                    }
                else { keyWord = _wordsDataBaseUsed[indRand]; _wordsDataBaseUsed[indRand].FakeUse = true; }
                break;
            }
            return keyWord;
        }

        private bool CheckWordsForQuestion()
        {
            int usedWords = 0;
            for (int i = 0; i < _wordsDataBaseUsed.Length; i++)
            {
                if (_wordsDataBaseUsed[i].Used)
                    usedWords++;
            }
            return (usedWords < _wordsDataBaseUsed.Length);
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
