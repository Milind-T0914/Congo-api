using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Congo.DTOs
{
    public record LoginUserDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; init; }
        [Required]
        public string Password { get; init; }
    }
}
