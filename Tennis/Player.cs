using System;
using System.Collections.Generic;
using System.Text;

namespace Tennis
{
    public class Player
    {
        public Player(string name)
        {
            this.Name = name;
            this.Score = 0;
        }
       
        public string Name { get; private set; }

        public int Score { get; private set; }

        public void SetScore()
        {
            this.Score++;
        }
    }
}
