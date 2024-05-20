using Pets.Dtos;

namespace Pets.Interfaces
{
    public interface ICross
    {
        // 查詢會員所有登記的寵物詳細資料（依會員id）
        public Task<PetDetailsOfMember> GetPetDetailsByMemberId(Guid id);
        // 查詢寵物所登記的疫苗詳細資料（依寵物id）
        public Task<VaccinesDetailOfPet> GetVaccinesDetailsByPetId(Guid id);
    }
}