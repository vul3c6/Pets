using Pets.Dtos;
namespace Pets.Contracts
{
    public interface ICross1
    {
        // 查詢Member 和他/她參與的所有myPet 的詳細資料（依指定id）
        public Task<PetDetailsOfMember> GetPetDetailsByMemberId(Guid id);
    }
}