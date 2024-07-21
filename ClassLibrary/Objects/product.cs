using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Objects
{
    public class Product
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public double Amount { get; set; }
        public double Weight { get; set; }
        public DateTime EP {  get; set; }
    }
}
