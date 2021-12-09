using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Congo.DTOs
{
    public record UpdateUserDTO
    {
        [Required]
        public string Name { get; init; }
        [Required]
        [EmailAddress]
        public string Email { get; init; }
        [Required]
        public string Password { get; init; }
        [Required]
        public string PhoneNumber { get; init; }
        [Required]
        [RegularExpression("^(?i)(buyer|seller)$")]
        public string Role { get; init; }
    }
}
