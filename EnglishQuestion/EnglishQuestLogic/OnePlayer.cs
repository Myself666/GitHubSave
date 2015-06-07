using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishQuestion.Logical
{
    public class OnePlayer : IPlayer
    {
        private Player _player;

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

        public void InstantiatePlayer()
        {
            _player = new Player("Игрок НомерОдин");            
        }


        public void MovePlayer(bool q, string word)
        {
            if (q)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" {0}<---Все верно! Вы угадали.", word);
                _player.Scores++;
                return;
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" {0}<---Не верно", word);
        }
    }
}
