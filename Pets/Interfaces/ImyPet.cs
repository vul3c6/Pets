﻿using Pets.Dtos;
using Pets.Models;

namespace Pets.Interfaces
{
    public interface ImyPet
    {
        // myPet 資料的介面
        public Task<IEnumerable<MyPet>> GetAllMyPets();
        //public Task<MyPet> GetMyPetById(Guid id);
        public Task<myPetForCreationDto> CreateMyPet(myPetForCreationDto myPet);
        public Task UpdateMyPet(Guid id, myPetForUpdateDto myPet);
        public Task DeleteMyPet(Guid id);
    }
}
