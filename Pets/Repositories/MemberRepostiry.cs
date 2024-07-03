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
            string sqlQuery = "SELECT * FROM member";
            // 建立資料庫連線
            using (var connection = _dbContext.CreateConnection())
            {
                // 執行查詢
                var members = await connection.QueryAsync<Member>(sqlQuery);
                return members.ToList();
            }
        }

        // 查詢單一 Member 資料（依指定 Id）
        public async Task<Member> GetMemberById(string Maccount)
        {
            string sqlQuery = "SELECT * FROM Member WHERE Maccount = @Maccount";
            // 建立資料庫連線
            using (var connection = _dbContext.CreateConnection())
            {
                // 執行查詢
                var member = await
                connection.QueryFirstOrDefaultAsync<Member>(sqlQuery, new { Maccount = Maccount });
                return member;
            }
        }

        // 新增 Member 資料
        public async Task<MemberForCreationDto> CreateMember(MemberForCreationDto member)
        {
            string sqlQuery = "INSERT INTO Member (Maccount, Mpassword, Mname, Memail, Msex ) VALUES (@Maccount, @Mpassword, @Mname, @Memail, @Msex )";
            // 建立資料庫連線
            using (var connection = _dbContext.CreateConnection())
            {
                // 執行新增
                await connection.ExecuteAsync(sqlQuery, member);
                return member;
            }
        }

        // 更新 Member 資料（依指定 id）
        //public async Task UpdateMember(string Maccount, MemberForUpdateDto member)
        //{
        //    string sqlQuery = "UPDATE Member SET MPassword = @MPassword, MName = @MName, Email = @mail WHERE MAccount = @MAccount";
        //    // 建立參數物件
        //    var parameters = new DynamicParameters();
        //    // 加入參數
        //    parameters.Add("MAccount", member.MAccount, DbType.String);
        //    parameters.Add("MPassword", member.MPassword, DbType.String);
        //    parameters.Add("MName", member.MName, DbType.String);
        //    parameters.Add("mail", member.mail, DbType.String);
        //    // 建立資料庫連線
        //    using (var connection = _dbContext.CreateConnection())
        //    {
        //        // 執行更新
        //        await connection.ExecuteAsync(sqlQuery, parameters);
        //    }
        //}

        // 刪除 Member 資料（依指定 id）
        public async Task DeleteMember(string Maccount)
        {
            string sqlQuery = "DELETE FROM Member WHERE Maccount = @Maccount";
            // 建立參數物件
            var parameters = new DynamicParameters();
            // 加入參數
            parameters.Add("Maccount", Maccount, DbType.String);
            // 建立資料庫連線
            using (var connection = _dbContext.CreateConnection())
            {
                // 執行刪除
                await connection.ExecuteAsync(sqlQuery, parameters);
            }
        }
    }
}
