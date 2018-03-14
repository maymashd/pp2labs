using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
namespace game_snake
{
    class Game
    {
        public static int ii=0, jj=0;
       public static snake Snake;
        public static Wall wall;
        public static Seri seri = new Seri();
       public static StreamReader sr = new StreamReader(@"C:\Users\User\Desktop\PP2labs\Week4\game snake\game over.txt");
        public static int x=1,y=0;
        public static int speed=200;
        public static int key = 1;
        public static bool GameOver = false;
        public static int direction=1;
        
        public Game(int a)
        {
             if (a == 1)
            {
                Snake = new snake();
                wall = new Wall(1);
                Snake.record = seri.F6();
                Game.speed = 200;
            }
            else
            {
                Snake = seri.F2();
                wall = seri.F4();
                Snake.record = seri.F6();
            }

        }
        public void Init()
        {

        }
        public static void Draw()
        {
            Game.Snake.draw();
            

        }
        public static void GameCheck(bool k)
        {
            k = true;
            if (Game.Snake.sum == 5 && Game.ii == 0)//если длина больше чем 5 то меняем левел 
            {
                Game.wall = new Wall(2);
                int m = 3;
                Game.speed = 120;
                Game.x = 1;
                Game.y = 0;
                foreach (Point P in Game.Snake.body)
                {
                    P.x = 5;
                    P.y = m;
                    m++;
                }
                Game.direction = 1;
                Game.ii = 1;//чтобы повторно не менят //чтобы повторно не менят карту
                Console.Clear();
                Game.wall.draw();//рисуем новую карту
                Game.Snake.createfood(Game.wall);

            }
            if (Game.Snake.sum == 12 && Game.jj == 0)//если длина больше чем 12 то подключаем третий левел
            {
                Game.wall = new Wall(3);
                Game.jj = 1;//чтобы повторно не менят карту
                int m = 3;
                Game.speed = 80;
                foreach (Point P in Game.Snake.body)
                {
                    P.x = 5;
                    P.y = m;
                    m++;
                }

                Console.Clear();
                Game.wall.draw();//рисуем новую карту
                Game.Snake.createfood(Game.wall);
            }

            for (int i = 1; i < Game.Snake.body.Count - 1; ++i)
                if (Game.Snake.body[0].x == Game.Snake.body[i].x && Game.Snake.body[0].y == Game.Snake.body[i].y)//если голова снейка ударилась в тело
                {
                    Game.GameOver = true;
                    k = false;
                    Console.Clear();
                    Console.SetCursorPosition(10, 10);

                    Console.WriteLine(Game.sr.ReadToEnd());
                    Console.ReadKey();
                    Console.Clear();
                    /*Console.WriteLine("if you want to start again type Enter");
                    Console.WriteLine("if you want to exit type Esp");
                    ConsoleKeyInfo ki2 = Console.ReadKey();
                    Console.Clear();
                    if (ki2.Key == ConsoleKey.Enter)
                    {

                        Game.Snake = new snake();
                        Game.speed = 200;
                        Game.wall = new Wall(1);
                        Game.Snake.record = Game.seri.F6();
                        Console.Clear();
                        Game.wall.draw();
                    }
                    if (ki2.Key == ConsoleKey.Escape)
                        return;*/
                }
            for (int i = 1; i < Game.wall.body.Count - 1; ++i)
                if (Game.Snake.body[0].x == Game.wall.body[i].x && Game.Snake.body[0].y == Game.wall.body[i].y)//если голова снейка ударилась в стенку
                {
                    Game.GameOver = true;


                    Console.Clear();
                    Console.SetCursorPosition(10, 10);

                    Console.WriteLine(Game.sr.ReadToEnd());
                    Console.ReadKey();
                    Console.Clear();
                    /*
                    Console.WriteLine("if you want to start again type Enter");
                    Console.WriteLine("if you want to exit type Esp");
                    ConsoleKeyInfo ki2 = Console.ReadKey();
                    Console.Clear();
 
                    if (ki2.Key == ConsoleKey.Enter)
                    {
                        Game.speed = 200;
                        Game.Snake = new snake();
                        Game.wall = new Wall(1);
                        Game.Snake.record = Game.seri.F6();

                        Console.Clear();
                        Game.wall.draw();
                    }
                    if (ki2.Key == ConsoleKey.Escape)
                        return;
                        */
                }

        }
    }
}
