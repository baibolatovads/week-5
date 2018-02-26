using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySnake
{
   public class Food:GameObject
    {
        public Food (Point firstpoint, ConsoleColor color, char sign) : base (firstpoint, color, sign)
        {

        }
        public Food() { }
    }
}
