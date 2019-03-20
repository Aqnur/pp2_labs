using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Food : GameObject
    {
        public Food() : base()
        {

        }
        public Food(char sign) : base(sign)
        {

        }
        public void GenerateLocation(List<Point> wormbody, List<Point> wallbody)
        {
            body.Clear();
            Random random = new Random(DateTime.Now.Second);
            Point p = new Point(random.Next(0, 39), random.Next(0, 39));
            while (!IsGoodPoint(p, wormbody) || !IsGoodPoint(p, wallbody))
            {
                p = new Point(random.Next(0, 39), random.Next(0, 39));
            }
            body.Add(p);
        }

        public bool IsGoodPoint(Point p, List<Point> points)
        {
            bool res = true;
            foreach (Point t in points)
            {
                if (p.X == t.X && p.Y == t.Y)
                {
                    res = false;
                    break;
                }
            }
            return res;
        }
    }
}

