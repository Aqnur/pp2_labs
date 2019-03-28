using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Task1
{
    [Serializable]
    public class GameObject
    {
        public Worm worm;
        public Wall wall;
        public Food food;
        public int score;
        public int level;
        public bool Gameover;
        
        public List<Point> body = new List<Point>();
        public char sign;

        public GameObject()
        {
            worm = Data.worm;
            wall = Data.wall;
            food = Data.food;
            Gameover = Data.Gameover;
            level = Data.level;
            score = Data.score;
        }

        public GameObject(char sign)
        {
            this.sign = sign;
        }

        public void Clear()
        {
            foreach(Point p in body)
            {
                Console.SetCursorPosition(p.X, p.Y);
                Console.Write(' ');
            }
        }

        public void Draw()
        {
            for(int i = 0; i < body.Count; i++)
            {
                Console.SetCursorPosition(body[i].X, body[i].Y);
                Console.Write(sign);
            }
        }
    }
}