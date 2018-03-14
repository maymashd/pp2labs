using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;//библиотека работа с файламали и директорями
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
namespace game_snake
{
    class Program
    {
        public static void MoveSnake()
        {
            while (!Game.GameOver)
            {

                switch (Game.direction)
                {
                    case 1:
                        Game.Snake.move(1, 0,Game.wall);
                        break;
                    case 2:
                        Game.Snake.move(-1, 0, Game.wall);
                        break;
                    case 3:
                        Game.Snake.move(0, 1, Game.wall);
                        break;
                    case 4:
                        Game.Snake.move(0, -1, Game.wall);
                        break;
                }
                Game.GameCheck(Game.GameOver);
                if (!Game.GameOver)
                {
                    Thread a = new Thread(MoveSnake);
                    a.Abort();

                }
                Game.Draw();




                Thread.Sleep(Game.speed);
            }
        }
        static int o,ii=0,jj=0;//статичные перемены которые содержать один или ноль зависимо от левела
        static void Main(string[] args)
        {
          
            Console.WriteLine("If you want to start again type 1");
            Console.WriteLine("If you want to continue type 2");
            ConsoleKeyInfo ki = Console.ReadKey();
            Game game=new Game(1);
            if (ki.Key == ConsoleKey.NumPad1)
            {
                 game=new Game(1);
                Game.Snake.move(Game.x, Game.y, Game.wall);
            }
            if (ki.Key == ConsoleKey.NumPad2)
            {
                game = new Game(2);
            }
            Console.Clear();

            Game.wall.draw();
          
            Thread t = new Thread(MoveSnake);
            t.Start();
            while (true)
            {
                ConsoleKeyInfo btn = Console.ReadKey();//ждет пока нажимаем клавиатуру 
                switch (btn.Key)
                {
                    case ConsoleKey.UpArrow:
                        Game.direction = 4;
                        break;
                    case ConsoleKey.DownArrow:
                        Game.direction = 3;
                        break;
                    case ConsoleKey.LeftArrow:
                        Game.direction = 2;
                        break;
                    case ConsoleKey.RightArrow:
                        Game.direction = 1;
                        break;
                   
                }

            
            if (btn.Key==ConsoleKey.Spacebar)
                {
                    t.Abort();

                    Game.seri.F1(Game.Snake);
                    Game.seri.F3(Game.wall);
                    Game.seri.F5(Game.Snake.record); 
                }
                if (btn.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    t = new Thread(MoveSnake);
                    t.Start();
                    Game.wall.draw();

                }
                if (btn.Key == ConsoleKey.Escape)
                {
                    t.Abort();
                    return;
                }
                



            }
        }
    }
}
