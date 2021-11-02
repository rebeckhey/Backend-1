using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackendUppgift1.Models
{
    public class CreateAdress
    {
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string AdressLine { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(10)")]
        public int ZipCode { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string City { get; set; }
    }
}
