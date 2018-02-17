using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace internet_shops
{
    class Shop
    {
        public string name;
        public string adress;
        public List<product> pr = new List<product>();
        public Shop(string name,string adress)
        {
            this.name = name;
            this.adress = adress;
        }
        public Shop()
        {

        }
        public Shop(string name)
        {
            this.name = name;
        }
        public void AddNewShop(List<Shop> a)
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Clear();
                Console.WriteLine("Please write the name of shop");
                string name2 = Console.ReadLine();
              FileStream fs = new FileStream(@"C:\Users\User\Desktop\PP2labs\Internet shops\internet shops\name of shops\" + name2 + ".txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                fs.Close();
                a.Add(new Shop(name2));
                Console.Clear();
                Console.WriteLine("1) If you want to create another one ");
                Console.WriteLine("2) If you want to back ");
                ConsoleKeyInfo ki = Console.ReadKey();
                if (ki.Key == ConsoleKey.NumPad2)
                {
                    Console.Clear();
                    break;
                }
            }
        }
     
        public void OpenShop()
        {
            Console.Clear();
            while (true)
            {
                Console.Clear();
                for (int i = 0; i < this.pr.Count; ++i)
                {
                    Console.WriteLine(i + 1 + ") name:" + this.pr[i].name+"       quantity:"+ this.pr[i].amount+"       price:"+this.pr[i].price);
                }
                if (this.pr.Count == 0)
                    Console.WriteLine("Shop doesn't have anything!");
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("if you want to return, please type esp");
                Console.WriteLine("if you want to buy the product,please type enter");
                Console.WriteLine("if you want to add product,please type 'A' ");
                ConsoleKeyInfo ki = Console.ReadKey();
                if (ki.Key == ConsoleKey.Escape)
                    break;
                if (ki.Key==ConsoleKey.Enter)
                {
                    BuyProduct(this.pr);
                }
                if (ki.Key == ConsoleKey.A)
                {
                    AddNewProduct(this .pr);
                }
            }
        }
        public void AddNewProduct(List<product> pr)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Please type 1,if you want to add product which exist");
                Console.WriteLine("Please type 2,if you want to add new product");
                Console.WriteLine("Please type esc,if you want to back");
                Console.WriteLine("");
                ConsoleKeyInfo ki = Console.ReadKey();
                if (ki.Key==ConsoleKey.NumPad1)
                {
                    Console.Clear();
                    for (int i = 0; i < pr.Count; ++i)
                    Console.WriteLine(i + 1 + ") name:" + pr[i].name + "    quantity:" + pr[i].amount + "    price:" + pr[i].price);
                    Console.WriteLine(" ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("please write the number of product");
                    int ind = int.Parse(Console.ReadLine()) - 1;
                    Console.WriteLine("how much do you want to add?");
                    int amount = int.Parse(Console.ReadLine());
                    pr[ind].amount += amount;
                    
                }
                if (ki.Key == ConsoleKey.Escape)
                    break;
                if (ki.Key == ConsoleKey.NumPad2)
                {
                    Console.Clear();
                    Console.WriteLine("Please write the name,quantity and price in this order");
                    string name = Console.ReadLine();
                    int quantity = int.Parse(Console.ReadLine());
                    int price = int.Parse(Console.ReadLine());
                    pr.Add(new product(name, quantity, price));
                }
            }
        }
        public void BuyProduct(List<product> l)
        {
            while (true)
            {
                Console.Clear();
                for (int i = 0; i < l.Count; ++i)
                {
                    Console.WriteLine(i + 1 + ") name:" + l[i].name + "       quantity:" + l[i].amount + "       price:" + l[i].price);
                }
                Console.WriteLine(" ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("if you want to back, please type esp");
                Console.WriteLine("if you want to buy, please type enter");
                
                ConsoleKeyInfo ki = Console.ReadKey();
                if (ki.Key == ConsoleKey.Escape)
                    break;
                if (ki.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    Console.WriteLine("Please write the number of product");
                    for (int i = 0; i < l.Count; ++i)
                    {
                        Console.WriteLine(i + 1 + ") name:" + l[i].name + "       quantity:" + l[i].amount + "       price:" + l[i].price);
                    }
                    int ind = int.Parse(Console.ReadLine());
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please write how many do you want to buy");
                    int s = int.Parse(Console.ReadLine());
                    if ( (l[ind - 1].amount-s) >= 0)
                    {
                        l[ind - 1].amount-=s;
                        Console.Clear();
                        int sum = s * l[ind - 1].price;
                        Console.WriteLine("You have successfully bought, you should pay:" + sum);
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Sale is impossible!");
                        Console.ReadKey();
                    }   
                }
            }
        }
        public void ShowShops(List<Shop> a)
        {
            while (true) {
                Console.Clear();
                for (int i = 0; i < a.Count; ++i)
                    Console.WriteLine(i + 1 + ")" + a[i].name);
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("esp- If you want to back ");
                Console.WriteLine("enter- Open the shop");
                ConsoleKeyInfo ki = Console.ReadKey();
                if (ki.Key == ConsoleKey.Escape)
                    return;
                if (ki.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    Console.WriteLine("please write the number of shop");
                        for (int i = 0; i < a.Count; ++i)
                        Console.WriteLine(i + 1 + ")" + a[i].name);
                    int ind = int.Parse(Console.ReadLine());
                    a[ind-1].OpenShop();
                }
            }
            
        }
    }
}
