using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;//библиотека работа с файламали и директорями
using System.Runtime.Serialization.Formatters.Binary;
namespace game_snake
{
    class Program
    {
        static void F1(snake Snake)
        {
            FileStream v = new FileStream("date1.txt", FileMode.OpenOrCreate,FileAccess.ReadWrite);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(v, Snake);
            v.Close();
            
        }
        static snake F2()
        {

            FileStream v = new FileStream("date1.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryFormatter bf = new BinaryFormatter();
            snake Snake2 = bf.Deserialize(v) as snake;
            v.Close();
            return Snake2;

        }
        static void F3(Wall wall)
        {
            FileStream v = new FileStream("date2.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(v,wall );
            v.Close();

        }
        static Wall F4()
        {

            FileStream v = new FileStream("date2.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryFormatter bf = new BinaryFormatter();
            Wall wall = bf.Deserialize(v) as Wall;
            v.Close();
            return wall;

        }
        static void F5(int b)
        {
            StreamWriter a = new StreamWriter(@"C:\Users\User\Desktop\PP2labs\Week4\game snake\record.txt");
            a.WriteLine(b);
            a.Close(); 
        }
        static int F6()
        {
            StreamReader a = new StreamReader(@"C:\Users\User\Desktop\PP2labs\Week4\game snake\record.txt");
            string s = a.ReadLine();
            a.Close();
            return int.Parse(s);
        }


        static int o,ii=0,jj=0;//статичные перемены которые содержать один или ноль зависимо от левела
        static void Main(string[] args)
        {
             

            snake Snake = new snake();//создает эгземпляр класса снейк
            Snake = F2();
            Console.Clear();

            
            Wall wall = new Wall(1);//создает эгземпляр класса уол
            wall = F4();
            Console.WriteLine("If you want to start again type 1");
            Console.WriteLine("If you want to continue type 2");
            ConsoleKeyInfo ki = Console.ReadKey();
            if (ki.Key == ConsoleKey.NumPad1)
            {
                snake Snake3 = new snake();
                F1(Snake3);
                Wall wall4 = new Wall(1);
                F3(wall4);
                Snake = Snake3;
                wall = wall4;

            }
            Console.Clear();
            Snake.record = F6();
            wall.draw();//функция класса уол который рисует стену
            StreamReader sr = new StreamReader(@"C:\Users\User\Desktop\PP2labs\Week4\game snake\game over.txt");//содержит текст который выводит после порожения
            Snake.draw();
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
                if (key.Key==ConsoleKey.Spacebar)
                {
                    F1(Snake);
                    F3(wall);
                    F5(Snake.record); 
                }
                if (key.Key == ConsoleKey.Escape)
               {
                    return;

                }

                if (Snake.sum==5 && ii==0)//если длина больше чем 5 то меняем левел 
                {
                    wall = new Wall(2);
                    int m = 3;
                    foreach (Point P in Snake.body)
                    {
                        P.x = 5;
                        P.y = m;
                        m++;
                    }
                    ii = 1;//чтобы повторно не менят //чтобы повторно не менят карту
                    Console.Clear();
                    wall.draw();//рисуем новую карту
                    Snake.createfood(wall);
                   
                }
                if (Snake.sum==12 && jj==0)//если длина больше чем 12 то подключаем третий левел
                {
                    wall = new Wall(3);
                    jj = 1;//чтобы повторно не менят карту
                    int m = 3;
                    foreach (Point P in Snake.body)
                    {
                        P.x = 5;
                        P.y = m;
                        m++;
                    }
                   
                    Console.Clear();
                    wall.draw();//рисуем новую карту
                    Snake.createfood(wall);
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
