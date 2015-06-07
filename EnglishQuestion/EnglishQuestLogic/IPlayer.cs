using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using EnglishQuestion.Logical;

namespace EnglishQuestion
{
    public interface IPlayer
    {
        Player PlayerInfo { get; set; }
        Player PlayerOneInfo { get; set; }
        Player PlayerTwoInfo { get; set; }

        void InstantiatePlayer();
        void MovePlayer(bool q, string word);
    }
}
