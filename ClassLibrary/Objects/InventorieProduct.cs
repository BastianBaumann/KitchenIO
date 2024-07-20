using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Objects
{
    public class InventorieProduct
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public float Amount { get; set; }
        public float Weight { get; set; }
        public DateTime EP {  get; set; }
    }
}
