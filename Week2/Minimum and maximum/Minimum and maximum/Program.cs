using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace maximum_and_mimimum
{
    public class Class1
    {
        static void Main(string[] args)
        {
            
            string line2 =  File.ReadAllText(@"C:\Users\User\desktop\PP2labs\Week2\Minimum and maximum\test.txt");
           


            string[] line = line2.Split(' ');

            int maxx = int.Parse(line[0]);
            int minn = int.Parse(line[0]);

            
            foreach (string s in line)
            {
                if (int.Parse(s) > maxx)
                    maxx = int.Parse(s);
                if (int.Parse(s) < minn)
                    minn = int.Parse(s);

            }
            StreamWriter sw = new StreamWriter(@"C:\Users\User\Desktop\PP2labs\Week2\Minimum and maximum\answer");
            sw.WriteLine("Maximum number is "+maxx);
            sw.WriteLine("Minimum number is "+minn);
            sw.Close();
            

            Console.ReadKey();

        }
    }
}
