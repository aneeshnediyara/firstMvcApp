using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace firstMvcApp.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Product Name is required.")]
        [MinLength(3,ErrorMessage = "Minimum 3 chars are needed.")]
        [MaxLength(50, ErrorMessage ="Maximum 50 Chars allowed.")]
        [Display(Name ="Product Name")]
        public string ProductName { get; set; }

        [Required(ErrorMessage ="Stock Price is required.")]
        [Range(0, 200, ErrorMessage ="Stock Price is out of range.")]
        [Display(Name = "Price")]
        public short UnitsInStock { get; set; }

        [Required(ErrorMessage = "Stock Level is required.")]
        [DataType(DataType.Currency, ErrorMessage = "Stock level is out of range.")]
        [Display(Name = "Stock Level")]
        public decimal UnitPrice { get; set; }

        [Display(Name ="In use ?")]
        public bool Discontinued { get; set; }

        public int CategoryId { get; set; }
    }
}