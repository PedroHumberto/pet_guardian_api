using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PetGuadian.Application.Dto.PetDto;
using PetGuadian.Application.Services.Interfaces;

namespace PetGuardian.Tests.Repositories
{
    public class FakePetService : IPetService
    {
        public async Task CreatePet(CreatePetDto pet)
        {
        }

        public Task Delete(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GetPetDto>> GetAllPetsByUserId(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<GetPetDto> GetPetById(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}