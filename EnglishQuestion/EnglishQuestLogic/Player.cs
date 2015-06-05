using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishQuestion.Logical
{
    public class Player
    {
        private string _name;
        private bool  _moved;
        private int _scores;

        public Player(string n)
        {
            _name = n;
        }

        public string Name{get { return _name; } set { _name = value; }}

        public bool Moved {get { return _moved; } set { _moved = value; }}

        public int Scores{get { return _scores; } set { _scores = value; }}
    }
}
