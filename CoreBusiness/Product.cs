using System;
using System.ComponentModel.DataAnnotations;

namespace CoreBusiness
{
    public class Product
    {
        public int ProductID { get; set; }
        [Required]
        public int? CategoryID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double? Quantity { get; set; }
        [Required]
        public double? Price { get; set; }
        public Category Category { get; set; }
        public string? Unit { get; set; }

    }
}
