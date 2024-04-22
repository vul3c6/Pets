using Pets.Models;
using Pets.Dtos;

namespace Pets.Interfaces
{
    public interface Ilost
    {
        // 走失寵物資料的介面
        public Task<IEnumerable<Lost>> GetAllLostPets();
        public Task<Lost> GetLostById(Guid id); 
        public Task<LostForCreationDto> CreateLost(LostForCreationDto lost);
        public Task UpdateLost(Guid id, LostForUpdateDto lost);
        public Task DeleteLost(Guid id);
    }
}
