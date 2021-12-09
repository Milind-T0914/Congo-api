using Congo.DTOs;
using Congo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Congo
{
    public static class Extensions
    {
        public static UserDTO AsDTO(this User User)
        {
            return new UserDTO
            {
                Id = User.Id,
                Name = User.Name,
                Email = User.Email,
                Password = User.Password,
                PhoneNumber = User.PhoneNumber,
                Role = User.Role
            };
        }
    }
}
