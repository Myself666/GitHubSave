using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishQuestion.Logical
{
    public class TwoPlayers : IPlayer
    {
        private Player _playerOne;
        private Player _playerTwo;

        private Player _currentPlayer;

        public Player PlayerInfo
        {
            get { return _currentPlayer; }
            set { _currentPlayer = value; }
        }

        public Player PlayerOneInfo
        {
            get { return _playerOne;}
            set { _playerOne = value; }
        }

        public Player PlayerTwoInfo
        {
            get { return _playerTwo; }
            set { _playerTwo = value; }
        }

        public void InstantiatePlayer()
        {
            Console.WriteLine("\nВведите имя первого игрока");
            string nameOne = Console.ReadLine();
            Console.WriteLine("\nВведите имя второго игрока");
            string nameTwo = Console.ReadLine();
            _playerOne = new Player(nameOne);
            _playerTwo = new Player(nameTwo);
            if (_currentPlayer == null)
            {
                _currentPlayer = _playerOne;
                _playerOne.Moved = true;
                _playerTwo.Moved = false;
            }
        }


        public void MovePlayer(bool q, string word)
        {
            if (_playerOne.Moved)
            {
                MoveFirstPlayer(q);
                SetupPlayerQueue();
                return;
            }

            if (_playerTwo.Moved)
            {
                MoveSecondPlayer(q);
                SetupPlayerQueue();
            }
        }

        void SetupPlayerQueue()
        {
            if (_playerOne.Moved && !_playerTwo.Moved)
            {
                _currentPlayer = _playerOne;
            }
            if (!_playerOne.Moved && _playerTwo.Moved)
                _currentPlayer = _playerTwo;
        }

        void MoveFirstPlayer(bool aTrue)
        {
            if (aTrue)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" <---Все верно! {0} перевел правильно.", _currentPlayer.Name);
                _currentPlayer.Scores += 2;
                _playerOne.Moved = false;
                _playerTwo.Moved = true;
                return;
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" <---Не верно. {0} Ошибся", _currentPlayer.Name);
                _currentPlayer.Scores -=1;
            _playerOne.Moved = false;
            _playerTwo.Moved = true;
        }

        void MoveSecondPlayer(bool bTrue)
        {
            if (bTrue)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" <---Все верно! {0} перевел правильно.", _currentPlayer.Name);
                _currentPlayer.Scores += 2;
                _playerOne.Moved = true;
                _playerTwo.Moved = false;
                return;
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" <---Не верно. {0} Ошибся", _currentPlayer.Name);
            _currentPlayer.Scores -= 1;
            _playerOne.Moved = true;
            _playerTwo.Moved = false;
        }
    }
}
