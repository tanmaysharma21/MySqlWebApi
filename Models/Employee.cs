using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Database.Models
{
    public class Employee : IEmployee
    {
        [Required(ErrorMessage ="Name is Required")]
        public string Name { get; set; }
        [Key]
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Team { get; set; }

    }
}
