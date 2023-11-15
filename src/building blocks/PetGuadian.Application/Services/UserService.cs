using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PetGuadian.Application.Dto.UserDto;
using PetGuadian.Application.Services.Interfaces;
using PetGuardian.Domain.Repositories;
using PetGuardian.Models.Models;

namespace PetGuadian.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateUser(CreateUserDto userDto)
        {
            var user = new User(
                userDto.UserIdentity,
                userDto.Name,
                userDto.Email);

            await _repository.CreateUser(user);
        }

        public void DeleteUser(Guid userId)
        {
            throw new NotImplementedException();
        }

        public void GetUser(Guid userId)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(CreateUserDto updatedUserDto)
        {
            throw new NotImplementedException();
        }
    }
}