using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Xml.Serialization;


namespace complex_number
{  [Serializable]
    class Complex
    {
        public int a, b;

        public Complex(int _a, int _b)
        {
            a = _a;
            b = _b;

        }

        public override string ToString()
        {
            return a + "/" + b;
        }


        public Complex Add(Complex complex2)
        {
            Complex result = new Complex(this.a * complex2.b + complex2.a * this.b, this.b * complex2.b);

            return result;
        }
        public Complex Minus(Complex complex2)
        {
            Complex result = new Complex(this.a * complex2.b - complex2.a * this.b, this.b * complex2.b);

            return result;
        }
        public Complex Multiple(Complex complex2)
        {
            Complex result = new Complex(this.a * complex2.a, this.b * complex2.b);

            return result;
        }
        public Complex Division(Complex complex2)
        {
            Complex result = new Complex(this.a * complex2.b, this.b * complex2.a);

            return result;
        }

        public static Complex operator +(Complex c1, Complex c2)
        {
            Complex c = new Complex(c1.a + c2.a, c1.b + c2.b);

            return c;
        }
        public void Simplify()
        {
            int _a = this.a;
            int _b = this.b;
            while (_a > 0 && _b > 0)
            {
                if (_a > _b)
                    _a = _a % _b;
                else
                    _b = _b % _a;
            }
            int nod = _a + _b;
            a /= nod;
            b /= nod;
        }





    }

    class Program
    {
        
        static void Main(string[] args)
        {

            string line = Console.ReadLine();
            string[] s = line.Split(' ');
            string a = s[0];
            string b = s[1];
            string[] d = a.Split('/');
            string[] v = b.Split('/');

            int a1 = int.Parse(d[0]);
            int a2 = int.Parse(d[1]);
            int b1 = int.Parse(v[0]);
            int b2 = int.Parse(v[1]);

            Complex t1 = new Complex(a1, a2);
            Complex t2 = new Complex(b1, b2);
            Complex t3 = t1.Add(t2);
            Complex t4 = t1.Minus(t2);
            Complex t5 = t1.Multiple(t2);
            Complex t6 = t1.Division(t2);
            t3.Simplify();
            t4.Simplify();
            t5.Simplify();
            t6.Simplify();

            Console.WriteLine("The sum of two numbers is=" + t3);
            Console.WriteLine("The subtract of two numbers is=" + t4);
            Console.WriteLine("The product of two numbers is=" + t5);
            Console.WriteLine("The division of two numbers is=" + t6);

            FileStream fs = new FileStream("data.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, t6);
            fs.Close();
            bf = new BinaryFormatter();
            FileStream fs2 = new FileStream("data.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            Complex t7 = bf.Deserialize(fs2) as Complex;
            Console.WriteLine("The Complex was successfully Deserialized " + t7);
             Console.ReadKey();

        }
    }
}
