using Dapper;
using Pets.Dtos;
using Pets.Interfaces;
using Pets.Models;
using Pets.Utilities;
using System.Data;

namespace Pets.Repositories
{
    public class ReceiveRepository : IReceive
    {
        private readonly DbContext _dbContext;
        // 在建構子中初始化DbContext 服務
        public ReceiveRepository(DbContext dbContext)
        {
            // 注入DbContext 服務
            _dbContext = dbContext;
        }
        // 查詢所有走失寵物資料的實作
        public async Task<IEnumerable<Receive>> GetAllReceivePets()
        {
            // 設定查詢用的SQL 語法
            string sqlQuery = "SELECT * FROM receive";
            // 建立資料庫連線
            using (var connection = _dbContext.CreateConnection())
            {
                // 執行查詢
                var receives = await connection.QueryAsync<Receive>(sqlQuery);

                return receives.ToList();
            }
        }
        //// 查詢指定id 的走失寵物資料
        //public async Task<Receive> GetReceiveById(Guid id)
        //// 新增走失寵物資料
        //{
        //    string sqlQuery = "SELECT * FROM receive WHERE Rid = @Id";
        //    // 建立資料庫連線
        //    using (var connection = _dbContext.CreateConnection())
        //    {
        //        // 執行查詢
        //        var receive = await connection.QueryFirstOrDefaultAsync<Receive>(sqlQuery, new { Id = id });
        //        return receive;
        //    }
        //}
        public async Task<ReceiveForCreationDto> CreateReceive(ReceiveForCreationDto receive)
        {
            string sqlQuery = "INSERT INTO receive (RBreed, RTime,RPlace,RFeature,RContactlnformation) VALUES (@RBreed, @RTime,@RPlace,@RFeature,@RContactlnformation)";
            // 建立資料庫連線
            using (var connection = _dbContext.CreateConnection())
            {
                // 執行新增
                await connection.ExecuteAsync(sqlQuery, receive);
                return receive;
            }
        }
        public async Task UpdateReceive(Guid id, ReceiveForUpdateDto receive)
        {
            string sqlQuery = "UPDATE receive SET RBreed = @RBreed, RTime = @RTime, RPlace = @RPlace, RFeature = @RFeature,RContactlnformation=@RContactlnformation WHERE Rid = @Id";
            // 建立參數物件
            var parameters = new DynamicParameters();
            // 加入參數
            parameters.Add("Id", id, DbType.Guid);
            parameters.Add("RBreed", receive.RBreed, DbType.String);
            parameters.Add("RTime", receive.RTime, DbType.String);
            parameters.Add("RPlace", receive.RPlace, DbType.String);
            parameters.Add("RFeature", receive.RFeature, DbType.String);
            parameters.Add("RContactlnformation", receive.RContactlnformation, DbType.String);
            // 建立資料庫連線
            using (var connection = _dbContext.CreateConnection())
            {
                // 執行更新
                await connection.ExecuteAsync(sqlQuery, parameters);
            }
        }
        public async Task DeleteReceive(Guid id)
        {
            string sqlQuery = "DELETE FROM receive WHERE rid = @Id";
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
