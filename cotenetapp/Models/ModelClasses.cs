using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace cotenetapp.Models
{
    public class Category
    {
        [Key]
        public int CategoryRowId { get; set; }
        [Required(ErrorMessage ="Category Id is Must")]
        public string CategoryId { get; set; }

        [Required(ErrorMessage = "Category Name is Must")]
        [StringLength(100, ErrorMessage ="Must be max 100 characters")]
        public string CategoryName { get; set; }

        [Required(ErrorMessage = "Base Price is Must")]
        [NumericValidator(ErrorMessage ="Value Cannot be Zero or -Ve")]
        public int BasePrice { get; set; }

        // one-to-many Relationship
        public ICollection<Product> Products { get; set; }
    }

    public class Product
    {
        [Key]
        public int ProductRowId { get; set; }
        [Required(ErrorMessage ="Product Id is Must")]
        public string ProductId { get; set; }
        [Required(ErrorMessage ="Product Name is Must")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Manufacturer is Must")]
        public string Manufacturer { get; set; }
        [Required(ErrorMessage ="Price is Must")]
        [NumericValidator(ErrorMessage = "Value Cannot be Zero or -Ve")]

        public int Price { get; set; }
        // Foreign Key
        public int CategoryRowId { get; set; }
        // Has-a Relatoinship
        public Category Category { get; set; }

    }

}
