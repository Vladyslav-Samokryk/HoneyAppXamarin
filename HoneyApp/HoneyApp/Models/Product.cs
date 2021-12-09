using System;
using System.Collections.Generic;
using System.Text;

namespace HoneyApp.Models
{
    public class Product
    {
        public int Id { get; set; }

        public int Price { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public byte[] Icon { get; set; }
    }
}
