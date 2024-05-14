using Pets.Dtos;
using Dapper;
using Pets.Contracts;
using Pets.Models;
using Pets.Utilities;

namespace Pets.Repositories
{
    public class Cross1Repositories : ICross1
    {
        private readonly DbContext _dbContext;
        public Cross1Repositories(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        // 查詢Member 和他/她參與的所有Calendars 的詳細資料（依指定id）
        public async Task<PetDetailsOfMember> GetPetDetailsByMemberId(Guid id)
        {
            string sqlQuery = "SELECT Mid, MName, MAccount FROM Member WHERE Mid = @Id;" + "SELECT P.* FROM myPet P, memberOfMyPet MP " + "WHERE MP.Mid = @Id AND P.Pid = MP.Pid;";
            using (var connection = _dbContext.CreateConnection())
            {
                var multi = await connection.QueryMultipleAsync(sqlQuery, new { Id = id });
                var member = await multi.ReadSingleOrDefaultAsync<PetDetailsOfMember>();
                if (member != null) member.Pets = (await multi.ReadAsync<myPet>()).ToList();
                return member;
            }
        }
    }
}