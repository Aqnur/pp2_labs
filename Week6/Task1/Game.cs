using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Xml.Serialization;

namespace Task1
{
    public class Game
    {
        public Worm worm;
        public Wall wall;
        public Food food;
        public string username;
        public bool Gameover;

        List<Player> LeaderBoards = new List<Player>();
        Timer timer = new Timer();
        Timer timer2 = new Timer();
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(Game));

        public Game()
        {
            Gameover = true;
            worm = new Worm('O');
            food = new Food('@');
            wall = new Wall('#');

            Console.SetWindowSize(40, 40);
            Console.SetBufferSize(40, 40);
            Console.CursorVisible = false;
        }
        
        public void Reset()
        {
            Console.Clear();
            timer.Elapsed -= Timer_Elapsed;
        }
        
        public void Save()
        {
            using (FileStream fileStream = new FileStream("game.xml", FileMode.Create, FileAccess.Write))
            {
                xmlSerializer.Serialize(fileStream, this);
                fileStream.Close();
            }
        }

        public Game Load()
        {
            Game res = null;
            using (FileStream fileStream = new FileStream("game.xml", FileMode.Open, FileAccess.Read))
            {
                res = xmlSerializer.Deserialize(fileStream) as Game;
                fileStream.Close();
            }

            return res;
        }

        public void Run()
        {
            Menu();
            Console.Clear();
            timer2.Elapsed += ChangeTime;
            timer2.Interval = 1000;
            timer2.Start();

            timer.Elapsed += Timer_Elapsed;
            timer.Interval = 120;
            timer.Start();
            
            wall.Draw();
        }

        private void ChangeTime(object sender, ElapsedEventArgs e)
        {
            Console.SetCursorPosition(0, 37);
            Console.WriteLine(DateTime.Now.Second);
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {

            Gameover = true;
            worm.Clear();
            worm.Move();
            worm.Draw();
            food.Draw();

            WallCollision();
            FoodCollision();
            Score();
            Info();
        }

        void WallCollision()
        {
            if (worm.CheckCollision(wall.body))
            {
                GameOver();
            }
        }
        
        void FoodCollision()
        {
            if (worm.CheckCollision(food.body))
            {
                worm.Eat(food.body);
                food.Generate();
                food.Draw();
                Data.score++;
            }
        }

        void Info()
        {
            Console.SetCursorPosition(20, 37);
            Console.Write("F2 - save");
            Console.SetCursorPosition(20, 38);
            Console.Write("F3 - reset game");
            Console.SetCursorPosition(20, 39);
            Console.Write("SPACE - pause");
        }

        void Score()
        {
            Console.SetCursorPosition(0, 38);
            Console.Write("Score - " + Data.score);
        }

        public void PressedKey(ConsoleKeyInfo consoleKeyInfo)
        {
            switch (consoleKeyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    worm.Dx = 0;
                    worm.Dy = -1;
                    break;
                case ConsoleKey.DownArrow:
                    worm.Dx = 0;
                    worm.Dy = 1;
                    break;
                case ConsoleKey.LeftArrow:
                    worm.Dx = -1;
                    worm.Dy = 0;
                    break;
                case ConsoleKey.RightArrow:
                    worm.Dx = 1;
                    worm.Dy = 0;
                    break;
                case ConsoleKey.Spacebar:
                    timer.Enabled = !timer.Enabled;
                    break;
                case ConsoleKey.Escape:
                    Environment.Exit(0);
                    break;
            }
        }
        
        void GameOver()
        {
            Console.Clear();
            Console.SetCursorPosition(20, 20);
            Console.Write("Game Over!");
            timer.Enabled = !timer.Enabled;
            Console.ReadKey();
            Console.SetCursorPosition(0,1);
            Console.WriteLine("Name: ");
            Console.SetCursorPosition(0, 2);
            string username = Console.ReadLine();
            if(username.Length > 0)
            {
                LeaderBoards.Add(new Player(username, Data.score));
            }

            LeaderBoards.Sort((x, y) => x.score.CompareTo(y.score));

            ShowLeaderboards();
            SaveLeaderboards(LeaderBoards);
        }

        void ShowLeaderboards()
        {
            Console.Clear();
            Console.WriteLine("Name:");
            Console.SetCursorPosition(20, 0);
            Console.WriteLine("Score:");

            for(int i = LeaderBoards.Count - 1; i >= 0; i--)
            {
                Console.Write(LeaderBoards[i].username);
                Console.SetCursorPosition(25, LeaderBoards.Count - i);
                Console.Write(LeaderBoards[i].score);
            }
        }

        public void SaveLeaderboards(List<Player> players)
        {
            FileStream fs = new FileStream(@"LeaderBoards.ser", FileMode.OpenOrCreate, FileAccess.Write);
            BinaryFormatter xs = new BinaryFormatter();
            try
            {
                xs.Serialize(fs, players);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                fs.Close();
            }
        }

        public List<Player> GetLeadeboards()
        {
            FileStream fs = new FileStream(@"LeaderBoards.ser", FileMode.OpenOrCreate, FileAccess.Read);
            BinaryFormatter xs = new BinaryFormatter();
            List<Player> G = new List<Player>();
            try
            {
                G = (List<Player>)xs.Deserialize(fs);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                fs.Close();
            }
            return G;
        }

        void PrintLeaderboards()
        {
            Console.SetCursorPosition(25, 0);
            Console.WriteLine("Score: " + Convert.ToString(Data.score));
        }

        public string[] menu = { "New Game", "Continue", "Leaderboards" };
        public int pos = 0;
        public void Menu()
        {
            while (true)
            {
                Console.Clear();
                for (int i = 0; i < menu.Length; i++)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = (pos == i) ? ConsoleColor.Green : ConsoleColor.Black;
                    Console.WriteLine(menu[i]);
                }

                ConsoleKeyInfo btn = Console.ReadKey();
                if (btn.Key == ConsoleKey.UpArrow) pos = ((pos == 0) ? pos = 2 : pos - 1);
                if (btn.Key == ConsoleKey.DownArrow) pos = (pos + 1) % 3;
                if (btn.Key == ConsoleKey.Enter)
                {
                    if (pos != 2) break;
                    ShowLeaderboards();
                    while (Console.ReadKey().Key != ConsoleKey.Escape) ;
                }
            }
        }
    }
}