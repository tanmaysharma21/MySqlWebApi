using System;
using System.ComponentModel.DataAnnotations;

namespace Database.Models
{
    public interface IEmployee
    {
        [Required(ErrorMessage = "Name is Required")]
        string Name { get; set; }
        [Key]
        [Required]
        Guid Id { get; set; }
        [Required]
        string Team { get; set; }
    }
}
