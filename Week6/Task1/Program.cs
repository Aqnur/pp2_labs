using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {

            Game game = new Game();
            game.Run();

            while (true)
            {
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
                switch (consoleKeyInfo.Key)
                {
                    case ConsoleKey.F2:
                        game.Save();
                        break;
                    case ConsoleKey.F3:
                        game.Reset();
                        game = game.Load();
                        game.Run();
                        break;
                    default:
                        game.PressedKey(consoleKeyInfo);
                        break;
                }
            }
        }
    }
}