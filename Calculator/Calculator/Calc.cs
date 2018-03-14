using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Calculator
{
    class Calc
    {
        public static double sum = 0;
        public static string operator1 = "";
        public static double a, b;
        public static void operator_click(object sender,string x)
        {
            if (x != "")
            {
                a = double.Parse(x);
                Button btn = sender as Button;
                operator1 = btn.Text;
            }
        }
        public static void operator_click2(object sender,string x)
        {
            if (x != "")
            {
                Button btn = sender as Button;
                if (btn.Text == "%")
                {
                    a = double.Parse(x)/100;
                    Calc.update();
                    sum = a;
                }
                if (btn.Text=="1/x")
                {

                    a = 1/double.Parse(x) ;
                    Calc.update();
                    sum = a;
                }

                if (btn.Text == "x^2")
                {

                    a = double.Parse(x) * double.Parse(x);
                    Calc.update();
                    sum = a;
                }
                if (btn.Text == "√")
                {

                    a = Math.Sqrt(double.Parse(x));
                    Calc.update();
                    sum = a;
                }


            }
        }
        public static void operator_equal(string x)
        {
            if (operator1 != "")
            {
                b = double.Parse(x);
                if (operator1 == "+")
                    sum = a + b;
                if (operator1 == "-")
                    sum = a - b;
                if (operator1 == "*")
                    sum = a * b;
                if (operator1 == "/")
                    sum = a / b;
                a = sum;  
            }


        }
        public static void update()
        {


         double sum = 0;
         string operator1 = "";
         double  b=0;

    }
        


    }
}
