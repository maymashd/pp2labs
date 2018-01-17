using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace little_prime_number
{
    class Program
    {
        static void Main(string[] args)
        {
            int test(int c)
            {
                int cnt = 0;
                for (int i = 1; i <= c; ++i)
                    if (c % i == 0)
                        cnt++;
                return cnt;
            }
            int minn=10000000;
            string line = File.ReadAllText(@"C:\Users\User\desktop\PP2labs\Week2\little prime number\test.txt");
            string[] a = line.Split(' ');
            foreach(string s in a)
            {
                int l = int.Parse(s);
                if ( (test(l) == 2) && (minn > l) )
                    minn = l;
            }
            StreamWriter sr = new StreamWriter(@"C:\Users\User\desktop\PP2labs\Week2\little prime number\answer.txt");
            sr.WriteLine(minn);
            sr.Close();
            Console.ReadKey();
        }
    }
}
