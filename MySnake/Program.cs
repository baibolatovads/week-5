using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySnake
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Menu menu = new Menu();
            Game game = new Game();
            
            while (true)
            {
                //game.Status();
                menu.Process();
            }
            /*
            Game game = new Game();
            game.SetUpBoard();
           // game.StartGame();
            game.Start();

            while (game.isAlive)
            {
                ConsoleKeyInfo pressedButton = Console.ReadKey();
                game.Process(pressedButton);

            }
            */
        }
    }
}
