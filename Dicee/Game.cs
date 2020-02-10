using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dicee
{
    class Game
    {
        public List<int> numbers = new List<int>();

        public List<int> Roll()
        {
            //numbers.Add(6); numbers.Add(6); return numbers;

            Random randomNumberGenerator = new Random();

            for (int i = 0; i < 2; i++)
            {
                numbers.Add(randomNumberGenerator.Next(1, 7));
            }
            return numbers;
        }

        public int CaculateScore(int jackpot)
        {
            if (jackpot == 1)
                return 200;
            else if (jackpot == 2)
                return 500;
            else if (numbers[0] == 6 && numbers[1] == 6)
                return 100;
            else if (numbers[0] == numbers[1] && numbers[0] != 6)
                return numbers[0] * 10;
            else
                return 0;
        }
    }
}
