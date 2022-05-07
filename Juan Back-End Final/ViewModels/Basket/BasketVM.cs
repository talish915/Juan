using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Juan_Back_End_Final.ViewModels.Basket
{
    public class BasketVM
    {
        public string Title { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public int Color { get; set; }
        public int Size { get; set; }
    }
}
