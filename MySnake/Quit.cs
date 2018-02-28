using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySnake
{
   public class Quit
    {
        string[] items = { "No", "Yes" };
        int index = 0;

        public bool WantToQuit()
        {
            DrawBorder();
            while (true)
            {
                Draw();
                ConsoleKeyInfo button = Console.ReadKey(true);
                switch (button.Key)
                {
                    case ConsoleKey.RightArrow:
                        {
                            index++;
                            if (index > 1)
                            {
                                index = 1;
                            }
                            break;
                        }
                    case ConsoleKey.LeftArrow:
                        {
                            index--;
                            if (index < 0)
                            {
                                index = 0;
                            }
                            break;
                        }
                    case ConsoleKey.Enter:
                        {
                            Console.Clear();
                            if (index == 0)
                            {
                                //Environment.Exit(0);
                                
                                return false;
                            }
                            if (index == 1)
                            {
                                Environment.Exit(0);
                                return true;
                            }
                            break;
                        }
                }
            }
        }

        void Draw()
        {
            ConsoleColor color1 = ConsoleColor.Black;
            ConsoleColor color2 = ConsoleColor.Red;
            int posX = 32, posY = 12;
            Console.SetCursorPosition(posX - 8, posY - 1);
            Console.WriteLine("Are you sure you want to exit?");

            for (int i = 0; i < 2; i++)
            {
                Console.SetCursorPosition(posX + 2 + 8 * i, posY + 1);
                if (index == i)
                {
                    Console.BackgroundColor = color2;
                }
                else
                {
                    Console.BackgroundColor = color1;
                }

                Console.Write(items[i]);
            }
            Console.BackgroundColor = color1;
        }

        void DrawBorder()
        {
            Console.Clear();

            for (int i = 0; i < 4; i++)
            {
                Console.SetCursorPosition(22, 11 + i);
                Console.Write("│");

                Console.SetCursorPosition(55, 11 + i);
                Console.Write("│");
            }
        }

    }
}
