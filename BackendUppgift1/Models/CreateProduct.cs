using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackendUppgift1.Models
{
    public class CreateProduct
    {
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string ProductName { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string ProductDescription { get; set; }

        [Required]
        [Column(TypeName = "money")]
        public decimal ProductPrice { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string ProductImageLink { get; set; }    

        [Required]
        public int SubCategoryId { get; set; }
    }
}
