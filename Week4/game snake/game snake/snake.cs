using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_snake
{
    class snake
    {
        public List<Point> body;
        public string sign;
        public Wall wall1;
        public Wall wall2;
        public int sum = 2;
        public int xr, yr,xc,yc;
        Random rnd = new Random();
        
        public snake()//пустой конструктор класса снейк
        {
            body = new List<Point>();//тело снейка

            xr = rnd.Next(2, 20);//рандомный фуд
            yr = rnd.Next(2, 20);

            

            body.Add(new Point(10, 10));//изначально длина 1
            sign = "*";
        }
        public void draw()//функция которая рисует снейк
        {
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            
            Console.SetCursorPosition(xr, yr);
            Console.WriteLine("o");
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
            Console.SetCursorPosition(xc, yc);
            Console.Write(' ');
               //Wall wall = new Wall();
            //wall.draw();

        }
        public void move(int xx, int yy,Wall wall)//двигает тело снейка в определенную сторону
        {

            xc = body[body.Count - 1].x;
            yc = body[body.Count - 1].y;

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
                Console.SetCursorPosition(10, 50);
                Console.WriteLine("Your length is: " + sum);

                body.Add(new Point(0, 0));
                Console.SetCursorPosition(xr, yr);
                Console.Write(' ');
                xr = rnd.Next(2, 30);
                yr = rnd.Next(2, 30);
                while (true)
                {
                    int k = 0;
                    foreach (Point p in body)
                    {
                        foreach(Point t in wall.body)
                        {

                            if ((xr == t.x && yr != t.y) || (xr == p.x && yr == p.x))
                            {
                                xr = rnd.Next(2, 30);
                                yr = rnd.Next(2, 30);
                                continue;
                            }
                            else
                            {
                                k = 1;
                                break;
                            }
                        }
                        if (k == 1)
                            break;
                    }
                    if (k == 1)
                        break;
                }
                
                sum++;
                

            }

            




        }
    }
}