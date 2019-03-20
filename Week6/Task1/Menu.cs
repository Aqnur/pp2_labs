using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Menu
    {
        public string[] menu = { "New Game", "Continue", "Leaderboards" };
        public int pos = 0;
        public Menu()
        {
            while (true)
            {
                Console.Clear();
                for (int i = 0; i < menu.Length; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.BackgroundColor = (pos == i) ? ConsoleColor.Green : ConsoleColor.Black;
                    Console.WriteLine(menu[i]);
                }
                ConsoleKeyInfo consoleKey = Console.ReadKey();
                switch (consoleKey.Key)
                {
                    case ConsoleKey.DownArrow:
                        pos = (pos + 1) % 3;
                        break;
                    case ConsoleKey.UpArrow:
                        pos = ((pos == 0) ? pos = 2 : pos - 1);
                        break;
                    case ConsoleKey.Enter:
                        if (pos != 2) break;
//                        ShowLeaderboards();
                        break;
                }
            }
        }
    }
}
