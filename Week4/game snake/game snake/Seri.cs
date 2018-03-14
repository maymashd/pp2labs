using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
namespace game_snake
{
    class Seri
    {
        static Seri()
        {

        }
         public void F1(snake Snake)
        {
            FileStream v = new FileStream("date1.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(v, Snake);
            v.Close();

        }
         public snake F2()
        {

            FileStream v = new FileStream("date1.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryFormatter bf = new BinaryFormatter();
            snake Snake2 = bf.Deserialize(v) as snake;
            v.Close();
            return Snake2;

        }
        public  void F3(Wall wall)
        {
            FileStream v = new FileStream("date2.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(v, wall);
            v.Close();

        }
        public  Wall F4()
        {

            FileStream v = new FileStream("date2.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryFormatter bf = new BinaryFormatter();
            Wall wall = bf.Deserialize(v) as Wall;
            v.Close();
            return wall;

        }
        public  void F5(int b)
        {
            StreamWriter a = new StreamWriter(@"C:\Users\User\Desktop\PP2labs\Week4\game snake\record.txt");
            a.WriteLine(b);
            a.Close();
        }
        public  int F6()
        {
            StreamReader a = new StreamReader(@"C:\Users\User\Desktop\PP2labs\Week4\game snake\record.txt");
            string s = a.ReadLine();
            a.Close();
            return int.Parse(s);
        }
    }
}
