﻿using Pets.Dtos;
using Pets.Models;

namespace Pets.Interfaces
{
    public interface IMember
    {
        // 會員的介面
        public Task<IEnumerable<Member>> GetAllMembers();
        public Task<Member> GetMemberById(string Maccount);
        public Task<MemberForCreationDto> CreateMember(MemberForCreationDto member);
        public Task<Member> Login(string Maccount, string password);
        //會員登入
        public Task UpdateMember(string Maccount, MemberForUpdateDto member);
        public Task DeleteMember(string Maccount);
    }
}
