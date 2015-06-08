using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishQuestion.Logical 
{
    public delegate string GameMessage(string msg);
    public class SubLogicClass
    {
        protected WordsDataBase[] _wordsDataBaseUsed;

        protected int _arrayLenght;
        protected bool _rus;
        protected Random _rand = new Random();

        protected SubLogicClass(WordsDataBase[] wdbBase, int len){}

        protected SubLogicClass(WordsDataBase[] wdbBase, int len, bool ru)
        {
            _wordsDataBaseUsed = new WordsDataBase[len];
            _wordsDataBaseUsed = wdbBase;
            _arrayLenght = len;
            _rus = ru;
        }

        protected bool WordsCheck(WordsDataBase wdbQuestion, WordsDataBase wdbAnswer)
        {
            return wdbQuestion.IdValue == wdbAnswer.IdValue;
        }

        protected WordsDataBase GetWordsForQuestion(bool rus)
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

        protected WordsDataBase GetWordsForFakeAnswers(bool rus)
        {
            WordsDataBase keyWord = null;
            int indRand;
            int cycles = 1;
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

        protected bool CheckWordsForQuestion()
        {
            int usedWords = 0;
            for (int i = 0; i < _wordsDataBaseUsed.Length; i++)
            {
                if (_wordsDataBaseUsed[i].Used)
                {
                    usedWords++;
                    _wordsDataBaseUsed[i].FakeUse = false;
                }
            }
            return (usedWords < _wordsDataBaseUsed.Length);
        }

        public string Messenger(string msg)
        {
            return msg;
        }
    }
}
