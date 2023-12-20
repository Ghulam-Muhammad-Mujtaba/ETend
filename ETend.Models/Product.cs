using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETend.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        [Range(0, 10000)]
        public double Price { get; set; }

        [Required]
        [Range(1, 10000)]
        [DisplayName("Discount Price")]
        public double DiscountedPrice { get; set; }
        [Required]
        [ValidateNever]
        public string ImageUrl { get; set; }
    }
}