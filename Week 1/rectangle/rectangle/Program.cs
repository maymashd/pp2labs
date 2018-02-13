using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rectangle
{
    class Program
    {
        class rectangle
        {
            double w, h, s, p;
            public rectangle()
            {
                
            }
            public rectangle(double w,double h)
            {
                this.w = w;
                this.h = h;
                findarea();
                findperimetre();

            }
            
            public void findarea()
            {
                this.s = w * h;
            }
            public void findperimetre()
            {
                this.p = 2*(w + h);
            }
            public override string ToString()
            {
                return "Area=" + s + "\nPerimetre=" + p;
            }



        }
        static void Main(string[] args)
        {
            Console.WriteLine("Width?");
            double w =double.Parse( Console.ReadLine());
            Console.WriteLine("Height?");
            double h = double.Parse(Console.ReadLine());
            rectangle a = new rectangle(w, h);
            Console.WriteLine(a);
            Console.ReadKey();
        }
    }
}
