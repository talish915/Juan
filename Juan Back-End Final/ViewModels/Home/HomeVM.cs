using Juan_Back_End_Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Juan_Back_End_Final.ViewModels.Home
{
    public class HomeVM
    {
        public IEnumerable<Brand> Brands { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<ServiceOffer> ServiceOffers { get; set; }
        public IEnumerable<Slider> Sliders { get; set; }
    }
}
