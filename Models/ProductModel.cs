using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ProductModel
    {
        public int ID { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public int Stock { get; set; }
        public decimal Amount { get; set; }
    }
    public class ProductEventArgs : EventArgs
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Stock { get; set; }
    }
}
