using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackendProjekt1.Models
{
    [Index(nameof(CategoryName), IsUnique = true)]
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string CategoryName { get; set; }

        public virtual ICollection<SubCategory> SubCategories { get; set; }
    }
}
