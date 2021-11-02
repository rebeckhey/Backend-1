using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackendUppgift1.Models
{
    public class CreateSubCategory
    {
        [Required]
        public string SubCategoryName { get; set; }

        public int CategoryId { get; set; }
    }
}
