using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;//библиотека работа с файламали и директорями
namespace game_snake
{
    class Program
    {
        static int o,ii=0,jj=0;//статичные перемены которые содержать один или ноль зависимо от левела
        static void Main(string[] args)
        {
            snake Snake = new snake();//создает эгземпляр класса снейк
            
            Console.Clear();
            
            
            Wall wall = new Wall(1);//создает эгземпляр класса уол
            wall.draw();//функция класса уол который рисует стену
            StreamReader sr = new StreamReader(@"C:\Users\User\Desktop\PP2labs\Week4\game snake\game over.txt");//содержит текст который выводит после порожения

            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey();//ждет пока нажимаем клавиатуру 
                if (key.Key == ConsoleKey.UpArrow)
                    Snake.move(0, -1,wall);
                if (key.Key == ConsoleKey.DownArrow)
                    Snake.move(0, 1,wall);
                if (key.Key == ConsoleKey.RightArrow)
                    Snake.move(1, 0,wall);
                if (key.Key == ConsoleKey.LeftArrow)
                    Snake.move(-1, 0,wall);
                if (Snake.sum==5 && ii==0)//если длина больше чем 5 то меняем левел 
                {
                    wall = new Wall(2);
                    ii = 1;//чтобы повторно не менят //чтобы повторно не менят карту
                    Console.Clear();
                    wall.draw();//рисуем новую карту
                }
                if (Snake.sum==12 && jj==0)//если длина больше чем 12 то подключаем третий левел
                {
                    jj = 1;//чтобы повторно не менят карту
                    wall = new Wall(3);
                    Console.Clear();
                    wall.draw();//рисуем новую карту
                }
                for (int i = 1; i < Snake.body.Count - 1; ++i)
                    if (Snake.body[0].x == Snake.body[i].x && Snake.body[0].y == Snake.body[i].y)//если голова снейка ударилась в тело
                    {
                        Console.Clear();
                        Console.SetCursorPosition(10, 10);
                        Console.WriteLine(sr.ReadToEnd());
                        Console.ReadKey();
                        return;
                    }
                for (int i = 1; i < wall.body.Count - 1; ++i)
                    if (Snake.body[0].x == wall.body[i].x && Snake.body[0].y == wall.body[i].y)//если голова снейка ударилась в стенку
                    {
                        Console.Clear();

                        Console.SetCursorPosition(10, 10);
                        Console.WriteLine(sr.ReadToEnd());
                        Console.ReadKey();
                        return;
                    }
                Snake.draw();//рисуем тело снейка


            }
        }
    }
}
