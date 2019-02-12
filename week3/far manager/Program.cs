using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarManager
{
    enum FSIMode
    {
        DirectoryInfo = 1,
        File = 2,
        Rename = 3
    }

    class Layer
    {
        public FileSystemInfo[] Content
        {
            get;
            set;
        }
        public int SelectedIndex
        {
            get;
            set;
        }
        public void Draw()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            for (int i = 0; i < Content.Length; ++i)
            {
                if (i == SelectedIndex)
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                Console.Write(i+1 + ". ");
                Console.WriteLine(Content[i].Name);
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\Users\aknur\Desktop\CN");
            string path = @"C:\Users\aknur\Desktop\CN";
            Layer l = new Layer
            {
                Content = dir.GetFileSystemInfos(),
                SelectedIndex = 0
            };

            FSIMode curMode = FSIMode.DirectoryInfo;

            Stack<Layer> history = new Stack<Layer>();
            history.Push(l);

            bool esc = false;
            while (!esc)
            {
                if (curMode == FSIMode.DirectoryInfo)
                {
                    history.Peek().Draw();
                }
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
                switch (consoleKeyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        history.Peek().SelectedIndex--;
                        break;
                    case ConsoleKey.DownArrow:
                        history.Peek().SelectedIndex++;
                        break;
                    case ConsoleKey.Enter:
                        int index = history.Peek().SelectedIndex;
                        FileSystemInfo fsi = history.Peek().Content[index];
                        if (fsi.GetType() == typeof(DirectoryInfo))
                        {
                            curMode = FSIMode.DirectoryInfo;
                            DirectoryInfo d = fsi as DirectoryInfo;
                            history.Push(new Layer
                            {
                                Content = d.GetFileSystemInfos(),
                                SelectedIndex = 0
                            });
                        }
                        else
                        {
                            curMode = FSIMode.File;
                            using (FileStream fs = new FileStream(fsi.FullName, FileMode.Open, FileAccess.Read))
                            {
                                using (StreamReader sr = new StreamReader(fs))
                                {
                                    Console.BackgroundColor = ConsoleColor.White;
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.Clear();
                                    Console.WriteLine(sr.ReadToEnd());
                                }
                            }
                        }
                        break;
                    case ConsoleKey.Backspace:
                        if (curMode == FSIMode.DirectoryInfo)
                        {
                            history.Pop();
                        }
                        else
                        {
                            curMode = FSIMode.DirectoryInfo;
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        break;
                    case ConsoleKey.Delete:
                        int indexDel = history.Peek().SelectedIndex;
                        FileSystemInfo fsiDel = history.Peek().Content[indexDel];
                        string pathDelete = path + @"\" + fsiDel;
                        if(fsiDel.GetType() == typeof(DirectoryInfo))
                        {
                            Directory.Delete(pathDelete);
                        }
                        else
                        {
                            File.Delete(pathDelete);
                        }
                        break;
                    case ConsoleKey.F4:
                        Console.Clear();
                        int indexReName = history.Peek().SelectedIndex;
                        FileSystemInfo fsiReName = history.Peek().Content[indexReName];
                        string pathRename = Console.ReadLine();
                        string path1 = path + @"\" + fsiReName;
                        string path2 = path + @"\" + pathRename;
                        if (fsiReName.GetType() == typeof(DirectoryInfo))
                        {
                            Directory.Move(path, path1);
                        }
                        else
                        {
                            File.Move(path1, path2);
                        }
                        break;
                    case ConsoleKey.Escape:
                        esc = true;
                        break;
                }
            }
        }
    }
}