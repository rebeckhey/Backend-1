using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackendProjekt1.Models
{
    [Index(nameof(SubCategoryName), IsUnique = true)]
    public class SubCategory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string SubCategoryName { get; set; }

        public int CategoryId { get; set; } 

        public virtual Category Category { get; set; } //kopplar mellan category

        public virtual ICollection<Product> Products { get; set; } //hämtar produkterna


    }
}
