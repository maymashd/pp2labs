using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace internet_shops
{
    class Program
    {
 
        static void Main(string[] args)
        {
            List<Shop> a = new List<Shop>();
            Shop shop=new Shop();
            DirectoryInfo dinfo = new DirectoryInfo(@"C:\Users\User\Desktop\PP2labs\Internet shops\internet shops\name of shops");
            FileSystemInfo[] finfo = dinfo.GetFiles();
            int t = 0;
            
            foreach (FileSystemInfo p in finfo)
            {
                
                StreamReader sr = new StreamReader(p.FullName);
                int k = int.Parse(sr.ReadLine());
                
                a.Add(new Shop(p.Name));
                for (int i=0;i<k;++i)
                {
                    string[] line = sr.ReadLine().Split(' ');
                    string name3 = line[0];
                    int quintity = int.Parse(line[1]);
                    int price2 = int.Parse(line[2]);
                    a[t].pr.Add(new product(name3, quintity, price2));
                }
                sr.Close();
                t++;
            }
            
            
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Hello dear customer, what is your name?");
            string name = Console.ReadLine();
           
            Console.Clear();
                
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Your name is: " + name);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("1) To see list of shops");
                Console.WriteLine("2) Add new shop ");
                Console.WriteLine("3) Exit");
                ConsoleKeyInfo ki = Console.ReadKey();
                
                if (ki.Key == ConsoleKey.NumPad2)
                    shop.AddNewShop(a);
                if (ki.Key == ConsoleKey.NumPad3)
                    return;
                if (ki.Key==ConsoleKey.NumPad1)
                {
                    shop.ShowShops(a);
                }
                Console.Clear();
            }
        }
    }
}
