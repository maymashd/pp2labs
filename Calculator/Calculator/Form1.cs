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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }
        private void numbers_click(object sender, EventArgs e)
        {
            

            Button btn = sender as Button;
            /*if ((btn.Text == "0" && textBox1.Text == "0") || (textBox1.Text == "0" && btn.Text == "00"))
            {

            }
            else
            {
                textBox1.Text += btn.Text;
                label1.Text += btn.Text;    
            }
            */
            if (btn.Text == "0")
                btn.Text = btn.Text;
            else
                btn.Text += btn.Text;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            Calc.update();
            Calc.a = 0;
            label1.Text = "";   
        }

        private void operator_click(object sender, EventArgs e)
        {
            if (Calc.operator1 != "")
            {
                Calc.operator_equal(textBox1.Text);
                textBox1.Text = Calc.sum.ToString();
                Button btn = sender as Button;
                label1.Text = textBox1.Text;
                label1.Text += btn.Text;
                Calc.operator_click(sender, textBox1.Text);
                textBox1.Text = "";
            }
            else
            {
                Calc.operator_click(sender, textBox1.Text);
                textBox1.Text = "";
                Button btn = sender as Button;
                label1.Text += btn.Text;
            }

        }

        private void button_equal_Click(object sender, EventArgs e)
        {
            Calc.operator_equal(textBox1.Text);
            textBox1.Text = Calc.sum.ToString();
            Calc.update();
            label1.Text =textBox1.Text ;
        }

        private void operator2_click(object sender, EventArgs e)
        {
            Calc.operator_click2(sender, textBox1.Text);
            textBox1.Text = Calc.sum.ToString();
            label1.Text = textBox1.Text;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text = (double.Parse(textBox1.Text) * (-1)).ToString();
            label1.Text = textBox1.Text;
        }

        private void button36_Click(object sender, EventArgs e)
        {

        }

        private void button27_Click(object sender, EventArgs e)
        {
            Calc.point_click(sender);

        }
    }
}
