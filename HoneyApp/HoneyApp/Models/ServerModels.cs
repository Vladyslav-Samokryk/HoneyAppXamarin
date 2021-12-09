using System;
using System.Collections.Generic;
using System.Text;

namespace HoneyApp.Models
{
    public class Bill
    { 
        public DateTime Date { get; set; }

        public List<BillItem> Items { get; set; }
    }
}

