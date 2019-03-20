using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    [Serializable]
    public class Player
    {
        public string username;
        public int score;
        public Player(string username, int score)
        {
            this.username = username;
            this.score = score;
        }
    }
}
