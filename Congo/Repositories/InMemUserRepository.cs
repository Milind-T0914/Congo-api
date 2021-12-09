using Congo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Congo.Repositories
{
    public class InMemUserRepository : IUserRepository
    {
        private readonly List<User> Users = new()
        {
            new User { Id = Guid.NewGuid(), Name = "Milind", Email = "milind@gmail.com", Password = "milind11", PhoneNumber = "111", Role = "Buyer" },
            new User { Id = Guid.NewGuid(), Name = "Amit", Email = "amit@gmail.com", Password = "amit11", PhoneNumber = "222", Role = "Buyer" },
            new User { Id = Guid.NewGuid(), Name = "Mishra", Email = "mishra@gmail.com", Password = "mishra11", PhoneNumber = "333", Role = "Buyer" },
            new User { Id = Guid.NewGuid(), Name = "Sambit", Email = "sambit@gmail.com", Password = "sambit11", PhoneNumber = "444", Role = "Seller" },
            new User { Id = Guid.NewGuid(), Name = "Ani", Email = "ani@gmail.com", Password = "ani11", PhoneNumber = "555", Role = "Seller" },
            new User { Id = Guid.NewGuid(), Name = "Bhakti", Email = "bhakti@gmail.com", Password = "bhakti11", PhoneNumber = "666", Role = "Seller" }
        };

        public async Task DeleteUserAsync(Guid Id)
        {
            var index = Users.FindIndex(existingUser => existingUser.Id == Id);
            Users.RemoveAt(index);
            await Task.CompletedTask;
        }

        public async Task<User> GetUserAsync(Guid Id)
        {
            var user = Users.Where(user => user.Id == Id).SingleOrDefault();
            return await Task.FromResult(user);
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await Task.FromResult(Users);
        }

        public async Task LoginUserAsync(string email, string password)
        {
            var user = Users.Where(user => user.Email == email && user.Password == password).SingleOrDefault();
            await Task.FromResult(user);
        }

        public async Task RegisterUserAsync(User User)
        {
            Users.Add(User);
            await Task.CompletedTask;
        }

        public async Task UpdateUserAsync(User User)
        {
            var index = Users.FindIndex(existingUser => existingUser.Id == User.Id);
            Users[index] = User;
            await Task.CompletedTask;
        }
    }
}
