using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackendProjekt1.Models
{
    public class Adress
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column (TypeName ="nvarchar(50)")]
        public string AdressLine { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(10)")]
        public int ZipCode{ get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string City { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }


    }
}
