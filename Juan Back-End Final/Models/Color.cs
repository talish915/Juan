using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Juan_Back_End_Final.Models
{
    public class Color : BaseEntity
    {
        [StringLength(255)]
        public string Name { get; set; }

        public IEnumerable<ProductColorSize> ProductColorSizes { get; set; }
    }
}
