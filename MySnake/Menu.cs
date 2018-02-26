using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySnake
{
    class Menu
    {
        string[] items = { "New Game", "Load Game", "Save Game", "Settings", "Exit" };
        int ItemsCount = 5;
        int selectedItemIndex = 0;
        ConsoleColor selectedColor = ConsoleColor.Red;
        ConsoleColor unselectedColor = ConsoleColor.Yellow;

        void NewGame()
        {
            //StatusBar.ShowInfo("New Game!");
            
            Game game = new Game();
            game.Start();
            while (game.isAlive)
            {
                ConsoleKeyInfo pressedButton = Console.ReadKey();
                game.Process(pressedButton);

            }
        }

        void LoadGame()
        {
            Console.Clear();
            Console.SetCursorPosition(15, 15);
            Console.WriteLine("LoadGame");
            Console.ReadKey();
        }

        void SaveGame()
        {
            StatusBar.ShowInfo("SaveGame!");
        }

        void Settings()
        {
            StatusBar.ShowInfo("Settings!");
        }

        void Exit()
        {
            StatusBar.ShowInfo("Exit!");
        }

        public void Draw()
        {
            /*
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Black;

            for (int i = 0; i < Game.boardH - 2; ++i)
            {
                for (int j = 0; j < Game.boardW; ++j)
                {
                    Console.Write(' ');
                }
                Console.WriteLine();
            }

            */
            // Console.SetCursorPosition(0, 0);
            //0, (Game.boardH - 25) / 2
            /*  Console.ForegroundColor = ConsoleColor.Yellow;
              Console.SetCursorPosition(32,14);

              for (int i = 0; i < items.Length; ++i)
              {
                  if (i == selectedItemIndex)
                  {
                      Console.ForegroundColor = ConsoleColor.White;
                  }
                  else
                  {
                      Console.ForegroundColor = ConsoleColor.Yellow;
                  }
                  Console.WriteLine(String.Format("          {0}. {1}", i, items[i]));
              }*/
            int posX = 32, posY = 14;
            Console.SetCursorPosition(posX, posY);
            for (int i = 0; i < ItemsCount; i++)
            {

                Console.SetCursorPosition(posX, posY + i);
                Console.Write("│");
                if (selectedItemIndex == i)
                {
                    Console.ForegroundColor = selectedColor;
                }
                else
                {
                    Console.ForegroundColor = unselectedColor;
                }

                Console.Write(items[i]);
                Console.ForegroundColor = unselectedColor;
                Console.Write("│");

                if (selectedItemIndex == i)
                {
                    Console.ForegroundColor = selectedColor;
                    Console.SetCursorPosition(posX - 2, posY + i);
                    Console.Write(">");
                    Console.ForegroundColor = unselectedColor;
                }
            }
        }

        public void Process()
        {

            DrawTitle();
            Draw();
            ConsoleKeyInfo pressedButton = Console.ReadKey(true);
            switch (pressedButton.Key)
            {
                case ConsoleKey.UpArrow:
                    selectedItemIndex--;
                    if (selectedItemIndex < 0)
                    {
                        selectedItemIndex = items.Length - 1;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    selectedItemIndex++;
                    if (selectedItemIndex >= items.Length)
                    {
                        selectedItemIndex = 0;
                    }
                    break;
                case ConsoleKey.Enter:

                    switch (selectedItemIndex)
                    {
                        case 0:
                            NewGame();
                            
                            break;
                        case 1:
                            LoadGame();
                            break;
                        case 2:
                            SaveGame();
                            break;
                        case 3:
                            Settings();
                            break;
                        case 4:
                            Exit();
                            break;
                    }

                    break;
            }
        }
        void DrawTitle()
        {

            FileStream fs = new FileStream(@"files\Title.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);

            string value;
            int y = 4;
            while ((value = sr.ReadLine()) != null)
            {
                Console.SetCursorPosition(10, y++);
                Console.WriteLine(value);
            }

            sr.Close();
            fs.Close();

        }


        
    }
}
