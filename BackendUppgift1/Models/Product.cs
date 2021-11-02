using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackendProjekt1.Models
{
    public class Product
    {
        [Key]
        public int Id {get; set;}

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string ProductName { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string ProductDescription { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string ProductImageLink { get; set; }

        [Required]
        [Column (TypeName = "money")]
        public decimal ProductPrice { get; set; }

        [Required]
        public int SubCategoryId { get; set; }
        
        public virtual SubCategory SubCategories { get; set; } //ger koppling till subcategory

    }
}
