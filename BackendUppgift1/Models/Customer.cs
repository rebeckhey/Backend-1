using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackendProjekt1.Models
{
    [Index(nameof(Email), IsUnique = true)]
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column (TypeName = "nvarchar(50)")]
        public string FirstName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string LastName { get; set; }


        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public int AdressId { get; set; }


        public virtual Adress Adresses { get; set; }

        
    }
}
