using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Data
    {
        static public Worm worm;
        static public Wall wall;
        static public Food food;
        static public int score;
        static public int level;
        static public bool Gameover;
        static public void Init(GameObject G)
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(70, 27);
            if (G.Gameover == false)
            {
                food = G.food;
                score = G.score;
                level = G.level;
                worm = G.worm;
                wall = G.wall;
                Gameover = G.Gameover;
            }
            else
            {
                score = 0;
                Gameover = false;
                level = 0;
                worm = new Worm();
                wall = new Wall();
                food = new Food();
            }
        }

        static public void initfrom(GameObject G)
        {
            food = G.food;
            score = G.score;
            level = G.level;
            worm = G.worm;
            wall = G.wall;
            Gameover = G.Gameover;
        }
    }
}
