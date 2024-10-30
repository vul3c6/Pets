using Pets.Dtos;
using Pets.Models;

namespace Pets.Interfaces
{
    public interface IMember
    {
        // 會員介面
        //全
        public Task<IEnumerable<Member>> GetAllMembers();
        //單一
        public Task<Member> GetMemberById(string Maccount);
        //新增
        public Task<MemberForCreationDto> CreateMember(MemberForCreationDto member);
        //更新
        public Task UpdateMember(string Maccount, MemberForUpdateDto member);
        //刪除
        public Task DeleteMember(string Maccount);
        //登入
        public Task<Member> Login(string Maccount, string password);
    }
}
