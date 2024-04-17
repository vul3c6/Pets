using Pets.Interfaces;
using Pets.Models;
using Pets.Utilities;
using Dapper;

namespace Pets.Repositories
{
    public class lostRepository : Ilost
    {
        private readonly DbContext _dbContext;
        // 在建構子中初始化DbContext 服務
        public lostRepository(DbContext dbContext)
        {
            // 注入DbContext 服務
            _dbContext = dbContext;
        }
        // 查詢所有走失寵物資料的實作
        public async Task<IEnumerable<lost>> GetAllLostPets()
        {
            // 設定查詢用的SQL 語法
            string sqlQuery = "SELECT * FROM lost";
            // 建立資料庫連線
            using (var connection = _dbContext.CreateConnection())
            {
                // 執行查詢
                var losts = await connection.QueryAsync<lost>(sqlQuery);

                return losts.ToList();
            }
        }
    }
}
