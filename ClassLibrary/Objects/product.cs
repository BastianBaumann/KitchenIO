using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenIO.Objects
{
    public class Product
    {
        public Guid Id { get; set; }
        public string name { get; set; }
        public int barcode { get; set; }
        public int amount { get; set; }
        public int weight { get; set; }
        public double price { get; set; }
    }
}
