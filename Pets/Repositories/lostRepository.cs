using Pets.Interfaces;
using Pets.Models;
using Pets.Utilities;
using Pets.Dtos;
using Dapper;
using System.Data;

namespace Pets.Repositories
{
    public class LostRepository : ILost
    {
        private readonly DbContext _dbContext;
        // 在建構子中初始化DbContext 服務
        public LostRepository(DbContext dbContext)
        {
            // 注入DbContext 服務
            _dbContext = dbContext;
        }
        // 查詢所有走失寵物資料的實作
        public async Task<IEnumerable<Lost>> GetAllLostPets()
        {
            // 設定查詢用的SQL 語法
            string sqlQuery = "SELECT * FROM lost";
            // 建立資料庫連線
            using (var connection = _dbContext.CreateConnection())
            {
                // 執行查詢
                var losts = await connection.QueryAsync<Lost>(sqlQuery);

                return losts.ToList();
            }
        }
        // 查詢指定id 的走失寵物資料
        public async Task<Lost> GetLostById(Guid id)
        // 新增走失寵物資料
        {
            string sqlQuery = "SELECT * FROM lost WHERE Lid = @Id";
            // 建立資料庫連線
            using (var connection = _dbContext.CreateConnection())
            {
                // 執行查詢
                var lost = await connection.QueryFirstOrDefaultAsync<Lost>(sqlQuery, new { Id = id });
                return lost;
            }
        }
        public async Task<LostForCreationDto> CreateLost(LostForCreationDto lost)
        {
            string sqlQuery = "INSERT INTO lost (LBreed, LTime,LPlace,LFeature,LContactlnformation,Maccount) VALUES (@LBreed, @LTime,@LPlace,@LFeature,@LContactlnformation,@Maccount)";
            // 建立資料庫連線
            using (var connection = _dbContext.CreateConnection())
            {
                // 執行新增
                await connection.ExecuteAsync(sqlQuery, lost);
                return lost;
            }
        }
        public async Task UpdateLost(Guid id, LostForUpdateDto lost)
        {
            string sqlQuery = "UPDATE lost SET LBreed = @LBreed, LTime = @LTime, LPlace = @LPlace, LFeature = @LFeature,LContactlnformation=@LContactlnformation,Maccount=@Maccount WHERE Lid = @Id";
            // 建立參數物件
            var parameters = new DynamicParameters();
            // 加入參數
            parameters.Add("Id", id, DbType.Guid);
            parameters.Add("LBreed", lost.LBreed, DbType.String);
            parameters.Add("LTime", lost.LTime, DbType.DateTime);
            parameters.Add("LPlace", lost.LPlace, DbType.String);
            parameters.Add("LFeature", lost.LFeature, DbType.String);
            parameters.Add("LContactlnformation", lost.LContactlnformation, DbType.String);
            parameters.Add("Maccount", lost.Maccount, DbType.String);
            // 建立資料庫連線
            using (var connection = _dbContext.CreateConnection())
            {
                // 執行更新
                await connection.ExecuteAsync(sqlQuery, parameters);
            }
        }
        public async Task DeleteLost(Guid id)
        {
            string sqlQuery = "DELETE FROM lost WHERE Lid = @Id";
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
        //ByMaccount
        public async Task<List<Lost>> GetLostsByMaccount(string Maccount)
        {
            string sqlQuery = "SELECT * FROM lost WHERE Maccount = @Maccount";
            // 建立資料庫連線
            using (var connection = _dbContext.CreateConnection())
            {
                // 執行查詢，回傳多筆資料
                var losts = await connection.QueryAsync<Lost>(sqlQuery, new { Maccount = Maccount });
                return losts.ToList();
            }
        }
    }
}
