using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;

namespace game_snake
{
    [Serializable]
    class snake
    {
        public List<Point> body;
        public string sign;
        public Wall wall1;
        public Wall wall2;
        public int sum = 1;
        public int xr, yr,xc,yc;
        public int record;
        Random rnd = new Random();
        void init()
        {

        }
        public snake()//пустой конструктор класса снейк
        {
            body = new List<Point>();//тело снейка

            xr = rnd.Next(2, 20);//рандомный фуд
            yr = rnd.Next(2, 20);
            record = 0;
            

            body.Add(new Point(10, 10));//изначально длина 1
            sign = "*";
           
        }
        public void draw()//функция которая рисует снейк
        {
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            
            Console.SetCursorPosition(xr, yr);
            Console.WriteLine("@");
            Console.ForegroundColor = ConsoleColor.Blue;
            foreach (Point p in body)
            {
                if (p.x == body[0].x && p.y == body[0].y)
                    Console.ForegroundColor = ConsoleColor.Green;
                else
                    Console.ForegroundColor = ConsoleColor.Blue;


                Console.SetCursorPosition(p.x, p.y);

                Console.WriteLine(sign);
            }
            //Console.SetCursorPosition(xc, yc);
            //Console.Write(' ');
            //Wall wall = new Wall();
            //wall.draw();

            Console.SetCursorPosition(10, 50);
            Console.WriteLine("Your length is: " + sum);
            Console.SetCursorPosition(10, 52);
            Console.WriteLine("Record is: " + record);
            Console.SetCursorPosition(10, 54);
            Console.WriteLine("If you want to safe,please type spacebar "); 
            Console.SetCursorPosition(10, 56);
            Console.WriteLine("If you want to exit,please type esp ");

        }
        public void createfood(Wall wall5)
        {
           
            bool k = true;
            while (k)
            {
                xr = rnd.Next(2, 30);
                yr = rnd.Next(2, 30);
                k = false;
                for (int i=0;i<body.Count;++i)
                    for (int j = 0; j < wall5.body.Count; ++j)
                    {
                        if ((xr == body[i].x && yr == body[i].y) || (xr == wall5.body[j].x && yr == wall5.body[j].y))
                            k = true;
                    }
            }

        
        }
        public void move(int xx, int yy,Wall wall3)//двигает тело снейка в определенную сторону
        {
            int xxx = body[0].x + xx;
            int yyy = body[0].y + yy;
            
            if (body.Count >= 2)
            {
                if (body[1].x == xxx && body[1].y == yyy )
                    return;
            }
            

            xc = body[body.Count - 1].x;
            yc = body[body.Count - 1].y;
            Console.SetCursorPosition(xc, yc);
            Console.Write(' ');

            for (int i = body.Count() - 1; i >= 1; i--)
            {
                body[i].x = body[i - 1].x;
                body[i].y = body[i - 1].y;

            }

            body[0].x += xx;
            body[0].y += yy;

            if (body[0].x == xr && body[0].y == yr)//пересечение головы снейка с фудом
            {
                Console.SetCursorPosition(10, 50);
                Console.WriteLine("                       ");
                
                body.Add(new Point(0, 0));
                Console.SetCursorPosition(xr, yr);
                Console.Write(' ');
                createfood(Game.wall);          
                
                
                sum++;
                record = Math.Max(record, sum);

            }

            



        }
    }
}