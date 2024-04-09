﻿using PetGuardian.Domain.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetGuardian.Domain.Pets
{
    public interface IPetRepository : IRepository<Pet>
    {
        Task CreatePet(Pet pet);
        Task<IEnumerable<Pet>> GetAllPetsByUserId(Guid userId);
        Task Update(Pet pet);
        Task<Pet> GetPetMedicines(Guid petId);
        Task<Pet> GetPetById(Guid userId, Guid petId);
        Task DeletePet(Guid petId, Guid userId);
    }
}
