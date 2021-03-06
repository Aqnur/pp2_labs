﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task1
{
    public class Wall : GameObject
    {
        public int lvl = 1;
        public Wall() : base()
        {

        }
        public Wall(char sign) : base(sign)
        {
            LoadLevel(lvl);
        }

        public void LoadLevel(int level)
        {
            string name = string.Format("Levels/Level{0}.txt", level);
            StreamReader sr = new StreamReader(name);

            int r = 0;
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                for (int c = 0; c < line.Length; ++c)
                {
                    if (line[c] == '#')
                    {
                        body.Add(new Point { X = c, Y = r });
                    }
                }
                r++;
            }
        }
    }
}
