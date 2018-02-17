using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace internet_shops
{
    class product
    {
        public string name;
        public int price;
        public int amount;
        public product(string name, int price)
        {
            this.name = name;
            this.price = price;
        }
        public product(string name,int amount,int price)
        {
            this.name = name;
            this.amount = amount;
            this.price = price;

        }
        public product()
        {

        }
        
    }
}
