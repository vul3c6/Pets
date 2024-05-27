using Pets.Interfaces;
using Pets.Dtos;
using Pets.Models;
using Pets.Utilities;
using Dapper;
using System.Data;

namespace Pets.Repositories
{
    public class MemberRepository : IMember
    {
        private readonly DbContext _dbContext;
        public MemberRepository(DbContext dbContext)
        {
            // 注入 DbContext 服務
            _dbContext = dbContext;
        }
        // 查詢所有 Member 資料的實作
        public async Task<IEnumerable<Member>> GetAllMembers()
        {
            string sqlQuery = "SELECT * FROM Member";
            // 建立資料庫連線
            using (var connection = _dbContext.CreateConnection())
            {
                // 執行查詢
                var members = await connection.QueryAsync<Member>(sqlQuery);
                return members.ToList();
            }
        }

        // 查詢單一 Member 資料（依指定 Id）
        public async Task<Member> GetMemberById(Guid id)
        {
            string sqlQuery = "SELECT * FROM Member WHERE Mid = @Id";
            // 建立資料庫連線
            using (var connection = _dbContext.CreateConnection())
            {
                // 執行查詢
                var member = await
                connection.QueryFirstOrDefaultAsync<Member>(sqlQuery, new { Id = id });
                return member;
            }
        }

        // 新增 Member 資料
        public async Task<MemberForCreationDto> CreateMember(MemberForCreationDto member)
        {
            string sqlQuery = "INSERT INTO Member (MAccount, MPassword, MName) VALUES (@MAccount, @MPassword, @MName)";
            // 建立資料庫連線
            using (var connection = _dbContext.CreateConnection())
            {
                // 執行新增
                await connection.ExecuteAsync(sqlQuery, member);
                return member;
            }
        }
        // 更新 Member 資料（依指定 id）
        public async Task UpdateMember(Guid id, MemberForUpdateDto member)
        {
            string sqlQuery = "UPDATE Member SET MAccount = @MAccount , MPassword = @MPassword, MName = @MName WHERE Mid = @Id";
            // 建立參數物件
            var parameters = new DynamicParameters();
            // 加入參數
            parameters.Add("Id", id, DbType.Guid);
            parameters.Add("MAccount", member.MAccount, DbType.String);
            parameters.Add("MPassword", member.MPassword, DbType.String);
            parameters.Add("MName", member.MName, DbType.String);
            // 建立資料庫連線
            using (var connection = _dbContext.CreateConnection())
            {
                // 執行更新
                await connection.ExecuteAsync(sqlQuery, parameters);
            }
        }

        // 刪除 Member 資料（依指定 id）
        public async Task DeleteMember(Guid id)
        {
            string sqlQuery = "DELETE FROM Member WHERE Mid = @Id";
            // 建立參數物件
            var parameters = new DynamicParameters();
            // 加入參數
            parameters.Add("Id", id, DbType.Guid);
            // 建立資料庫連線
            using (var connection = _dbContext.CreateConnection())
            {
                // 執行刪除
                await connection.ExecuteAsync(sqlQuery, parameters);
            }
        }
    }
}
