using Pets.Dtos;
using Pets.Models;

namespace Pets.Interfaces
{
    public interface IMember
    {
        // 會員的介面
        public Task<IEnumerable<Member>> GetAllMembers();
        public Task<Member> GetMemberById(Guid id);
        public Task<MemberForCreationDto> CreateMember(MemberForCreationDto member);
        public Task UpdateMember(Guid id, MemberForUpdateDto member);
        public Task DeleteMember(Guid id);
    }
}
