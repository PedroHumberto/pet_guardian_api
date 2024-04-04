using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetGuardian.Domain.Users
{
    public interface IUserRepository
    {
        Task CreateUser(User user);
        void UpdateUser(User updatedUser);
        Task<User> GetUser(Guid userId);
        Task InativateUser(Guid userId);
    }
}