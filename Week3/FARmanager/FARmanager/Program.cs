using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace FileManager{
    class Program{
        static int s = 0,l=0;
        static DirectoryInfo a = new DirectoryInfo(@"C:\Users\User\Desktop\PP2labs"), q = a;
        static FileSystemInfo[] b = a.GetFileSystemInfos();
        static Stack<int> stack = new Stack<int> () ;
        static void shower(FileSystemInfo[] t, ConsoleKeyInfo p, int s2){
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            if (p.Key == ConsoleKey.Enter){
                stack.Push(s2);
                if (t[s2].GetType() == typeof(DirectoryInfo)){
                    a = new DirectoryInfo(t[s2].FullName);
                    b = a.GetFileSystemInfos();
                    s = 0;
                    s2 = s;
                    t = b;
                }
                else{
                    StreamReader sr = new StreamReader(t[s2].FullName);
                    string st = sr.ReadLine();
                    Console.WriteLine(st);
                    while (true)
                    {
                        ConsoleKeyInfo q = Console.ReadKey();
                        if (q.Key == ConsoleKey.Q)
                            break;
                    }

                    
                }}
            if (p.Key == ConsoleKey.Escape){
                if (a.FullName == q.FullName){
                    l = 1;
                    return;
                }    
                a = a.Parent;
                b = a.GetFileSystemInfos();
                s2 = stack.Pop();
                t = b;
            }
            int size = t.Length;
            if (p.Key == ConsoleKey.DownArrow){
                s2++;
                if (s2 == size)
                    s2 = 0;
            }
            if (p.Key == ConsoleKey.UpArrow){
                s2--;
                if (s2 == -1)
                    s2 = size - 1;
            }
            int m = 0;
            foreach (FileSystemInfo g in t){
                if (m == s2){
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine(g.Name);
                }
                else{
                    Console.BackgroundColor = ConsoleColor.Black;
                    if (g.GetType() == typeof(FileInfo)){
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(g.Name);
                    }
                    if (g.GetType() == typeof(DirectoryInfo)){
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine(g.Name);
                    } }
                m++;
            }
            s = s2;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("please type a letter 's' to start =)");
            while (true){
                ConsoleKeyInfo pk = Console.ReadKey();
                shower(b, pk, s);
                if (l == 1)
                    break;
            }
        }
    }
}
