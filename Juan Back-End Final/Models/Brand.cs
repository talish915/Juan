using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Juan_Back_End_Final.Models
{
    public class Brand : BaseEntity
    {
        [StringLength(255), Required]
        public string Name { get; set; }
        [StringLength(1000)]
        public string Image { get; set; }
        [StringLength(255), Required]
        public string Link { get; set; }

        [NotMapped]
        public IFormFile LogoImage { get; set; }
    }
}
