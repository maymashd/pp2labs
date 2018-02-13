using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*string line;
           line= Console.ReadLine();
            string[] arr = line.Split(' ');*/
            foreach (string s in args)// для всех strings в массива аргс выполняется следующее
            {
                 int a = int.Parse(s); // переводит string на int
                
                int sum = 0; // счетчик делители
                if (a == 1)
                {
                    sum = 1;// потому что 1 не простое число
                }
                for (int i=2;i*i<=a;++i)
                    if (a%i==0)// если делит
                    {
                        sum = sum + 1;// увеличиваем количестов делители
                    }
                if (sum == 0)
                    Console.WriteLine(a);// если нет делители в интервале от 2 до sqrt(n) то выводим это число
            }
            Console.ReadKey();// чтобы не закрывалось
        }
    }
}
