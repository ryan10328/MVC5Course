using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5Course.Models
{
    public class ProductViewModel
    {
        [Required]
        public int ProductId { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        [Range(1, 9999, ErrorMessage = "價格必須介於 1 ~ 9999 之間")]
        public decimal Price { get; set; }
    }
}