using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student
{
    class Program
    {
        class student
        {
            string name, lastname;
            int age;
            double gpa;
            public student(string name, string lastname, int age,double gpa)
            {
                this.name = name;
                this.lastname = lastname;
               this. gpa =gpa;
                this.age = age;
            }
            public student (string name1,string lastname1)
            {
                this.name = name1;
                lastname = lastname1;
            }
            public override string ToString()
            {
                return "Your name is " + name + "\nYour last name is " + lastname + "\nYour age is " + age + "\nYour gpa is " + gpa;
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("What is your name sir?");
            string name = Console.ReadLine();
            Console.WriteLine("What is your last name?");
            string lastname = Console.ReadLine();
            Console.WriteLine("What is your name age?");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("What is your name gpa?");
            double gpa =double.Parse( Console.ReadLine());
            student a = new student(name, lastname, age, gpa);

            student a2 = new student(name, lastname);
            Console.WriteLine(a);
            Console.ReadKey();
        }
    }
}
