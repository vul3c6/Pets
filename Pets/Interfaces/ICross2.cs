using Pets.Dtos;

namespace Pets.Interfaces
{
    public interface ICross2
    {
        // 查詢Member 和他/她參與的所有Calendars 的詳細資料（依指定id）
        public Task<VaccinesDetailsOfPet> GetVaccinesDetailsByPetId(Guid id);
        // 查詢Calendar 和參與其中的所有Members 的詳細資料（依指定id）
        public Task<PetDetailsOfVaccine> GetPetDetailsByVaccineId(Guid id);
    }
}
