﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenIO.Objects
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Barcode { get; set; }
        public double Price { get; set; }
        public int Type { get; set; }
    }
}
