using Congo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Congo.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserAsync(Guid Id);
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User> LoginUserAsync(string email, string password);
        Task RegisterUserAsync(User User);
        Task UpdateUserAsync(User User);
        Task DeleteUserAsync(Guid Id);
    }
}
