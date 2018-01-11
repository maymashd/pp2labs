using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace circle
{
    class circle
    {
        double r, area, length, diametre;
        public circle(double r)
        {
            this.r = r;
            findarea(this.r);
            findlenght(this.r);
            finddiametre(this.r);
        }
        public void findarea(double r)
        {
            area = Math.PI * r * r;
        }
        public void findlenght(double r)
        {
            length = r * 2*Math.PI;
        }
        public void finddiametre(double r)
        {
            diametre = 2 * r;
        }
        public override string ToString()
        {
            return "Area=" + area + "\nLenght=" + length + "\ndiametre=" + diametre;

        }


    }
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Radius?");
            double r = double.Parse(Console.ReadLine());
            circle a = new circle(r);
            Console.WriteLine(a);
           
            Console.ReadKey();


        }
    }
}
