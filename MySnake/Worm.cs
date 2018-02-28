using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySnake
{
    public class Worm : GameObject
    {
        /*public Worm(Point firstPoint, ConsoleColor color, char sign) : base(firstPoint, color, sign)
        {

        }

        public Worm() { }
        public void Move(int dx, int dy)
        {
            Point newHeadPos = new Point { X = body[0].X + dx, Y = body[0].Y + dy };

            for (int i = body.Count - 1; i > 0; --i)
            {
                body[i].X = body[i - 1].X;
                body[i].Y = body[i - 1].Y;
            }

            body[0] = newHeadPos;
        }*/

        public int DX { get; set; }
        public int DY { get; set; }



        public Worm(Point firstPoint, ConsoleColor color, char sign) : base(firstPoint, color, sign)
        {
            DX = 0;
            DY = 0;
        }

        public Worm() { }
        public void Move()
        {
            for (int i = body.Count - 1; i > 0; --i)
            {
                body[i].X = body[i - 1].X;
                body[i].Y = body[i - 1].Y;
            }

            body[0].X += DX;
            body[0].Y += DY;

            if (body[0].X == Game.boardW)
            {
                body[0].X = 0;
            }else if (body[0].Y == Game.boardH)
            {
                body[0].Y = 0;
            }else if (body[0].X == -1)
            {
                body[0].X = Game.boardW-1;
            }else if (body[0].Y == -1)
            {
                body[0].Y = Game.boardH-1;
            }
        }

        public void ChangeDir(ConsoleKeyInfo pressedButton)
        {
            switch (pressedButton.Key)
            {
                case ConsoleKey.UpArrow:
                    DX = 0;
                    DY = -1;
                    break;
                case ConsoleKey.DownArrow:
                    DX = 0;
                    DY = 1;
                    break;
                case ConsoleKey.LeftArrow:
                    DX = -1;
                    DY = 0;
                    break;
                case ConsoleKey.RightArrow:
                    DX = 1;
                    DY = 0;
                    break;
            }
        }
    }
}
