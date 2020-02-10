using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dicee
{
    class Game
    {
        //public bool p1Played = true;

        //public string Turn()
        //{
        //    if (p1Played){
        //        p1Played = false;
        //        return "Roll (Player 2)";
        //    }
        //    else
        //        return "Roll (Player 1)";

        //}

        public List<int> Roll()
        {
            Random randomNumberGenerator = new Random();
            List<int> numbers = new List<int>();

            for (int i = 0; i < 2; i++)
            {
                numbers.Add(randomNumberGenerator.Next(1, 7));
            }
            return numbers;
        }
    }
}
