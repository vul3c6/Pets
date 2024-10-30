using Pets.Dtos;
using Pets.Models;

namespace Pets.Interfaces
{
    public interface ImyPet
    {
        // myPet 資料的介面
        public Task<IEnumerable<MyPet>> GetAllMyPets();
        public Task<MyPet> GetMyPetById(Guid id);
        public Task<myPetForCreationDto> CreateMyPet(myPetForCreationDto myPet);
        public Task UpdateMyPet(Guid id, myPetForUpdateDto myPet);
        public Task DeleteMyPet(Guid id);
        // 查詢單一 myPet 資料(依指定 Maccount)
        public Task<IEnumerable<MyPet>> GetPetsByMaccount(string maccount);

    }
}
