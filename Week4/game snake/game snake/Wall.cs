using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace game_snake
{
   [Serializable]
    class Wall
    {
        public List<Point> body;
        public int o;
        public Wall(int o)
        {
            this.o = o;
            //каждая содержит адресс левела
            StreamReader sr = new StreamReader(@"C:\Users\User\Desktop\PP2labs\Week4\game snake\maps\level 1.txt");
            
            
                StreamReader sr1 = new StreamReader(@"C:\Users\User\Desktop\PP2labs\Week4\game snake\maps\level 2.txt");
            
                StreamReader sr2 = new StreamReader(@"C:\Users\User\Desktop\PP2labs\Week4\game snake\maps\level 3.txt");
            
            body= new List<Point>();
            if (o == 1)//первая карта
            {

                int n = int.Parse(sr.ReadLine());

                for (int i = 0; i < n; i++)
                {
                    string s = sr.ReadLine();
                    for (int j = 0; j < s.Length; j++)
                        if (s[j] == '#')
                            body.Add(new Point(j, i));
                }
                sr.Close();
            }
            if (o == 2)//вторая карта
            {

                int n = int.Parse(sr1.ReadLine());

                for (int i = 0; i < n; i++)
                {
                    string s = sr1.ReadLine();
                    for (int j = 0; j < s.Length; j++)
                        if (s[j] == '#')
                            body.Add(new Point(j, i));
                }
                sr1.Close();
            }
            if (o == 3)
            {

                int n = int.Parse(sr2.ReadLine());

                for (int i = 0; i < n; i++)
                {
                    string s = sr2.ReadLine();
                    for (int j = 0; j < s.Length; j++)
                        if (s[j] == '#')
                            body.Add(new Point(j, i));
                }
                sr2.Close();
            }

        }
        public void draw()
        {//рисует стенку
            foreach (Point p in body)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.SetCursorPosition(p.x, p.y);

                Console.WriteLine("#");
            }

        }


}
}
