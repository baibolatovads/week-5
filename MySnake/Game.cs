using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MySnake
{
    enum GameLevel
    {
        First,
        Second,
        Bonus
    }

    class Game
    {
        public static int speed = 250;
        public static int boardW = 40;
        public static int boardH = 40;

        bool[,] field = new bool[10, 10];

        Worm worm;
        Food food;
        Wall wall;
        public bool isAlive = true;
        public int k = 0;

        GameLevel gameLevel;

        List<GameObject> g_objects = new List<GameObject>();
        
        public void SetUpBoard()
        {
            Console.SetWindowSize(Game.boardW, Game.boardH);
            Console.SetBufferSize(Game.boardW, Game.boardH);
            Console.CursorVisible = false;
        }

        
        public void Status()
        {
            Console.SetCursorPosition(5, 1);
            Console.Write("Score:");
            Console.SetCursorPosition(15, 1);
            Console.Write(k);

            Console.SetCursorPosition(30, 1);
            Console.Write("Speed:");
            Console.SetCursorPosition(40, 1);
            Console.Write(speed);
            Console.Write("  ");
        }

        public void LoadLvl(int k)
        {
            /*if (worm.body.Count <= 2) {
               // gameLevel = GameLevel.First;
                wall.LoadLevel(GameLevel.First);
               
            }
            else
            {
                //gameLevel = GameLevel.Second;
               
                worm.body.Clear();
                wall.body.Clear();
                
                wall.LoadLevel(GameLevel.Second);
                wall.Draw();
                worm.body.Add(new Point { X = 10, Y = 10 });
                Food food = new Food(new Point { X = new Random().Next(1, 34), Y = new Random().Next(1, 34) }, ConsoleColor.Black, '*');

            }*/
         
            if (k < 3)
            {
                gameLevel = GameLevel.First;
                wall.LoadLevel(gameLevel);
            }
            if (k >= 3)
            {
               
                gameLevel = GameLevel.Second;
                wall.LoadLevel(gameLevel);
            }
           
           wall.LoadLevel(gameLevel);
        
           // Lvl();
        }
        public Game()
        {
            
            gameLevel = GameLevel.First;
            

            worm = new Worm(new Point { X = 10, Y = 10 },
                            ConsoleColor.White, '*');
            food = new Food(new Point { X = 20, Y = 10 },
                           ConsoleColor.White, '+');
            wall = new Wall(null, ConsoleColor.White, '#');



            g_objects.Add(worm);
            g_objects.Add(food);
            g_objects.Add(wall);
            LoadLvl(k);
            // Lvl();

        }
        public void Start()
        {
            
            ThreadStart ts = new ThreadStart(Draw);
            Thread t = new Thread(ts);
            t.Start();
        }

        public void Draw()
        {

            while (isAlive)
            {
                worm.Move();
                // Lvl();
                

                if (worm.body[0].Equals(food.body[0]))
                {
                    k++;
                    worm.body.Add(new Point { X = food.body[0].X, Y = food.body[0].Y });
                    food.body.Clear();
                    food.body.Add(new Point { X = new Random().Next(1, 34), Y = new Random().Next(1, 34) });
                }
                

               
                else
                {
                    foreach (Point p in wall.body)
                    {
                        if (p.Equals(worm.body[0]))
                        {
                            isAlive = false;
                            break;
                        }
                    }
                
                  foreach (Point p in worm.body)
                    {
                        if (worm.body[0].Equals(p) && p != worm.body[0])
                        {
                            isAlive = false;
                            break;
                        }
                    }
                }
            
                Console.Clear();
                foreach (GameObject g in g_objects)
                {
                    g.Draw();
                }
                Thread.Sleep(Game.speed);
            }

            Console.Clear();
            Console.SetCursorPosition(10, 5);
            Console.WriteLine("GAME OVER!!!");
            Console.SetCursorPosition(10, 6);
            Console.WriteLine("Your score: " + k);
        }

        public void Exit()
        {

        }

        public void Process(ConsoleKeyInfo pressedButton)
        {
            switch (pressedButton.Key)
            {
                case ConsoleKey.UpArrow:
                    worm.DX = 0;
                    worm.DY = -1;
                    break;
                case ConsoleKey.DownArrow:
                    worm.DX = 0;
                    worm.DY = 1;
                    break;
                case ConsoleKey.LeftArrow:
                    worm.DX = -1;
                    worm.DY = 0;
                    break;
                case ConsoleKey.RightArrow:
                    worm.DX = 1;
                    worm.DY = 0;
                    break;
                case ConsoleKey.Escape:
                    Console.Clear();
                    Menu menu = new Menu();
                    menu.Process();
                    Console.ReadKey();
                    break;
                case ConsoleKey.F2:
                    worm.Save();
                    food.Save();
                    break;
                case ConsoleKey.F1:
                    worm = worm.Load() as Worm;
                    food = food.Load() as Food;
                    break;
            }
        }
    }
}
