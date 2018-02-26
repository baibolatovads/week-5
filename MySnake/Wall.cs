using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySnake
{
    class Wall:GameObject
    {
        public Wall(Point firstpoint, ConsoleColor color, char sign) : base (firstpoint, color, sign)
        {

        }
        /// <summary>
        /// Levels of the Game
        /// </summary>
        /// <param name="level">Number of the lvl</param>
        public void LoadLevel(GameLevel level)
        {
            string fname = "";
          //  string fname2 = "";

            switch (level)
            {
                case GameLevel.First:
                    fname = "Level1.txt";
                    break;
                case GameLevel.Second:
                    fname = "lvl1.txt";
                    break;
                default:
                    break;
            }

            //Build zabor

            FileStream fs = new FileStream(fname, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string line;
            int y = 0;

            while((line = sr.ReadLine()) != null)
            {
                for (int x = 0; x < line.Length; x++)
                {
                    if (line[x] == '#')
                    {
                        this.body.Add(new Point { X = x, Y = y });
                    }
                }
                y++;
            }
            sr.Close();
            fs.Close();
        }
    }
}
