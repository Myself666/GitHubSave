using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishQuestion.Logical
{
    class OnePlayer : IPlayer
    {
        private Player _player;

        private WordsDataBase[] _wdBase;
        private int _wbdLenght;
        private LogicalClass _logikClass;


        public Player PlayerInfo
        {
            get { return _player; }
            set { _player = value; }
        }

        public Player PlayerOneInfo
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public Player PlayerTwoInfo
        {
            get { return null; }
            set { throw new NotImplementedException(); }
        }

        public void InstantiatePlayer(WordsDataBase[] wdb, int len)
        {
            _wdBase = new WordsDataBase[len];
            _wdBase = wdb;
            _player = new Player("Игрок НомерОдин");
            _logikClass = new LogicalClass(_wdBase,len);
            
        }


        public void MovePlayer(WordsDataBase quest, WordsDataBase answer)
        {
            if (_logikClass.WordsCheck(quest, answer))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" <---Все верно! Вы угадали.");
                return;
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" <---Не верно");
        }
    }
}
