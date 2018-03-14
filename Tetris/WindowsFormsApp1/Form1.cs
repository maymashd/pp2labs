using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
         List<Button> body = new List<Button>();
        public Form1()
        {
            InitializeComponent();

        }
        public static int sum = 0;
        public void Create_Button()
        {
            Button btn = new Button();
            
            Random rnd = new Random();
            int k= rnd.Next(1, 350);
            btn.Location = new Point(k, 0);
            btn.Size = new Size(25, 25);
            btn.BackColor = Color.Red;
            body.Add(btn);
            Controls.Add(body[body.Count-1]);
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            sum = 0;
            foreach (Button p in body)
            {
                int k1 = p.Location.X;
                int k2 = p.Location.Y;
                if (k2 > 336)
                    sum++;
                  p.Location = new Point(k1, k2 + 5);
            }
            button.Text = sum.ToString();
            if (Checker() == false)
            {
                timer1.Enabled = false;
                timer2.Enabled = false;
                MessageBox.Show("Game Over");
            }

        }
        public bool Checker()
        {
            int x1 = button.Location.X;
            int y1 = button.Location.Y;
            
            foreach (Button b in body)
            {
                int x2 = b.Location.X;
                int y2 = b.Location.Y;
                int minn1 = Math.Min(x1, x2);
                int maxx1 = Math.Max(x1+38, x2+25);
                
                int minn2 = Math.Min(y1, y2);
                int maxx2 = Math.Max(y1+23, y2+25);
                if ( (maxx2 - minn2) < 48 && (maxx1 - minn1) < 63)
                {
                    
                    return false;
                }



            }
            return true;
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            Create_Button();
        }
        

        private void button_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)52)
            {

                int k1 = button.Location.X;
                int k2 = button.Location.Y;

                button.Location = new Point(k1 - 5, k2);
            }

            if (e.KeyChar == (char)54)
            {

                int k1 = button.Location.X;
                int k2 = button.Location.Y;

                button.Location = new Point(k1 + 5, k2);
            }

        }
    }
}
