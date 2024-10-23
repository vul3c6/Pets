using Pets.Dtos;
using Pets.Models;

namespace Pets.Interfaces
{
    public interface IReceive
    {
        // 領取寵物資料的介面
        public Task<IEnumerable<Receive>> GetAllReceivePets();
        public Task<Receive> GetReceiveById(Guid id);
        public Task<ReceiveForCreationDto> CreateReceive(ReceiveForCreationDto receive);
        public Task UpdateReceive(Guid id, ReceiveForUpdateDto receive);
        public Task DeleteReceive(Guid id);
        public Task<IEnumerable<Receive>> GetReceivesByMaccount(string Maccount);
    }
}
