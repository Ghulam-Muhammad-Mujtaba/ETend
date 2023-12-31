﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETend.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        [ValidateNever]
        public Product Product { get; set; }
        [Range(3, 1000, ErrorMessage = "Please enter a value between 3 and 100")]
        public int Count { get; set; }

        public string CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        [ValidateNever]
        public Customer Customer { get; set; }

        [NotMapped]
        public double Price { get; set; }
    }
}
