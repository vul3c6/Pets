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
        // Member 資料的實作
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

        public async Task<Member> GetMemberById(string Maccount)
        {
            string sqlQuery = "SELECT * FROM member WHERE Maccount = @MAccount";
            // 建立資料庫連線
            using (var connection = _dbContext.CreateConnection())
            {
                // 執行查詢
                var members = await
                connection.QueryFirstOrDefaultAsync<Member>(sqlQuery, new { MAccount = Maccount });
                return members;
            }
        }

        public async Task<MemberForCreationDto> CreateMember(MemberForCreationDto member)
        {
            string sqlQuery = "INSERT INTO member (Maccount, Mpassword, Mname, Memail, Msex, Mdate ) VALUES (@Maccount, @Mpassword, @Mname, @Memail, @Msex, @Mdate )";
            // 建立資料庫連線
            using (var connection = _dbContext.CreateConnection())
            {
                // 執行新增
                await connection.ExecuteAsync(sqlQuery, member);
                return member;
            }
        }
        //會員登入
        public async Task<Member> Login(string account, string password)
        {
            using (IDbConnection dbConnection = _dbContext.CreateConnection())
            {
                string query = "SELECT * FROM Member WHERE Maccount = @Account AND Mpassword = @Password";
                return await dbConnection.QuerySingleOrDefaultAsync<Member>(query, new { Account = account, Password = password });
            }
        }

        public async Task UpdateMember(string Maccount, MemberForUpdateDto member)
        {
            string sqlQuery = "UPDATE member SET Mpassword = @Mpassword, Mname = @Mname, Memail = @Memail, Msex= @Msex , Mdate = @Mdate WHERE Maccount = @Maccount";
            // 建立參數物件
            var parameters = new DynamicParameters();
            // 加入參數
            parameters.Add("Maccount", member.Maccount, DbType.String);
            parameters.Add("Mpassword", member.Mpassword, DbType.String);
            parameters.Add("Mname", member.Mname, DbType.String);
            parameters.Add("Memail", member.Memail, DbType.String);
            parameters.Add("Msex", member.Msex, DbType.String);
            parameters.Add("Mdate", member.Mdate, DbType.String);
            // 建立資料庫連線
            using (var connection = _dbContext.CreateConnection())
            {
                // 執行更新
                await connection.ExecuteAsync(sqlQuery, parameters);
            }
        }

        public async Task DeleteMember(string Maccount)
        {
            string sqlQuery = "DELETE FROM member WHERE Maccount = @Account";
            // 建立參數物件
            var parameters = new DynamicParameters();
            // 加入參數
            parameters.Add("Account", Maccount, DbType.String);
            // 建立資料庫連線
            using (var connection = _dbContext.CreateConnection())
            {
                // 執行刪除
                await connection.ExecuteAsync(sqlQuery, parameters);
            }
        }
    }
}
