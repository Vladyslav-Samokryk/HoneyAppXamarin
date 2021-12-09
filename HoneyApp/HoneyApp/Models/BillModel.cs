using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HoneyApp.Models
{
    public class BillModel
    {
        public int Id { get; set; }
        public List<BillItem> BillItems { get; set; }

        public DateTime Date { get; set; }

        public int Sum  => BillItems.Sum(X => X.TotalPrize);

        public int HeightList => BillItems.Count * 40;
    }

    public class BillItem
    {
        public string Name { get; set; }

        public int Prize { get; set; }

        public int Count { get; set; }

        public int TotalPrize => Prize * Count;
    }
}
