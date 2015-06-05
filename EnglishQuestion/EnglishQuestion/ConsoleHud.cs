using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using EnglishQuestion.Logical;

namespace EnglishQuestion
{
    class ConsoleHud
    {       
        private int _baseLenght;
        private IPlayer _player;
        private bool _twoPlayers;
        private bool _rus;
        private LogicalClass _consolLogic;

        WordsDataBase[] wdbvariants = new WordsDataBase[4];
        private WordsDataBase trueVariant;

        public ConsoleHud(WordsDataBase[] wdb, IPlayer player, int len, bool rus, bool two)
        {
            Console.WriteLine("Вас приветствует Тюлень и его произведение.\n" +
                              "Данная игра сделана с целью подкрепления знаний в Английском языке.\n" +
                              "На данный момент в базе данных содержится {0} пар слов\n" +
                              "Никогда не поздно пополнить их"
                              , len);

            _baseLenght = len;
            _rus = rus;
            _twoPlayers = two;
            _consolLogic = new LogicalClass(wdb,len);
            _player = player;
            _player.InstantiatePlayer(wdb,len);
        }

        public void GetStartGame()
        {
            int count = 0;
            do
            {                
                Console.Clear();
                Console.WriteLine("Количество очков:");
                Console.WriteLine(GetInfoPlayer() +"\n");
                MovePlayer();
                Console.ReadLine();
            } while (count < 15);
        }

        public void MovePlayer()
        {
            if(_rus)
                RusQuestion();
        }

        private void RusQuestion()
        {                      
            wdbvariants[0] = _consolLogic.GetWordsForQuestion(true);
            wdbvariants[1] = _consolLogic.GetWordsForFakeAnswers(false);
            wdbvariants[2] = _consolLogic.GetWordsForFakeAnswers(false);
            wdbvariants[3] = _consolLogic.GetWordsForFakeAnswers(false);
            trueVariant = wdbvariants[0];
            if (wdbvariants[0] != null)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Ходит игрок ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write(_player.PlayerInfo.Name);

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n\n\nКак переводится слово {0}", wdbvariants[0].EnglishWord);

                Array.Sort(wdbvariants);

                for (int i = 0; i < wdbvariants.Length; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("{0})  {1}", i + 1, wdbvariants[i].RussianWord);
                }

                ChoseVariants();

                for (int i = 0; i < wdbvariants.Length; i++)
                {
                    wdbvariants[i].FakeUse = false;
                }
            }
            else Console.WriteLine("Игра окончена");

        }

        private void ChoseVariants()
        {
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                    _player.MovePlayer(trueVariant, wdbvariants[0]);
                    break;
                case ConsoleKey.D2:
                    _player.MovePlayer(trueVariant, wdbvariants[1]);
                    break;
                case ConsoleKey.D3:
                    _player.MovePlayer(trueVariant, wdbvariants[2]);
                    break;
                case ConsoleKey.D4:
                    _player.MovePlayer(trueVariant, wdbvariants[3]);
                    break;
                default:
                    Console.WriteLine(" <---Неправильно введен символ!");
                    ChoseVariants();
                    break;
            }
        }

        public string GetInfoPlayer()
        {
            if(_twoPlayers)
                return _player.PlayerOneInfo.Name + " :: " + _player.PlayerOneInfo.Scores +
                    "       " + _player.PlayerTwoInfo.Name + " :: " + _player.PlayerTwoInfo.Scores;
            return _player.PlayerInfo.Name + " :: " + _player.PlayerInfo.Scores;
        }
    }
}
