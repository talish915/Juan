using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Juan_Back_End_Final.Models
{
    public class ProductColor
    {
        public int Id { get; set; }
        public Nullable<int> ColorId { get; set; }
        public Color Color { get; set; }
        public Nullable<int> ProductId { get; set; }
        public Product Product { get; set; }
    }
}
