using Dapper;
using Pets.Dtos;
using Pets.Interfaces;
using Pets.Models;
using Pets.Utilities;
using System.Data;

namespace Pets.Repositories
{
    public class ActivitiesRepository : IActivities
    {

        private readonly DbContext _dbContext;
        // 在建構子中初始化DbContext 服務
        public ActivitiesRepository(DbContext dbContext)
        {
            // 注入DbContext 服務
            _dbContext = dbContext;
        }
// 查詢所有活動資料的實作
        public async Task<IEnumerable<Activities>> GetAllActivities()
        {
            // 設定查詢用的SQL 語法
            string sqlQuery = "SELECT * FROM Activities";
            // 建立資料庫連線
            using (var connection = _dbContext.CreateConnection())
            {
                // 執行查詢
                var Activities = await connection.QueryAsync<Activities>(sqlQuery);

                return Activities.ToList();
            }
        }
        // 
        public async Task<Activities> GetActivitiesById(Guid id)
        {
            string sqlQuery = "SELECT * FROM Activities WHERE Aid = @Id";
            // 建立資料庫連線
            using (var connection = _dbContext.CreateConnection())
            {
                // 執行查詢
                var Activities = await connection.QueryFirstOrDefaultAsync<Activities>(sqlQuery, new { Id = id });
                return Activities;
            }
        }
        public async Task<ActivitiesForCreactionDto> CreateActivities(ActivitiesForCreactionDto activities)
        {
            string sqlQuery = "INSERT INTO Activities (Pid,Atype,startTime,endTime) VALUES (@Pid,@Atype,@startTime,@endTime)";
            // 建立資料庫連線
            using (var connection = _dbContext.CreateConnection())
            {
                // 執行新增
                await connection.ExecuteAsync(sqlQuery, activities);
                return activities;
            }
        }
        public async Task UpdateActivities(Guid id, ActivitiesForUpdateDto activities)
        {
            string sqlQuery = "UPDATE Activities SET Atype = @Atype, startTime = @startTime, endTime = @endTime, distance = @distance, steps = @steps WHERE Aid = @Id";
            // 建立參數物件
            var parameters = new DynamicParameters();
            // 加入參數
            parameters.Add("Id", id, DbType.Guid);
            parameters.Add("Atype", activities.Atype, DbType.String);
            parameters.Add("startTime", activities.startTime, DbType.DateTime);
            parameters.Add("endTime", activities.endTime, DbType.DateTime);
            parameters.Add("distance", activities.distance, DbType.Single);
            parameters.Add("steps", activities.steps, DbType.Int16);
            // 建立資料庫連線
            using (var connection = _dbContext.CreateConnection())
            {
                // 執行更新
                await connection.ExecuteAsync(sqlQuery, parameters);
            }
        }
        public async Task DeleteActivities(Guid id)
        {
            string sqlQuery = "DELETE FROM Activities WHERE Aid = @Id";
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

        // 查詢多筆 Activties 資料(依指定 Pid)
        public async Task<IEnumerable<Activities>> GetActivitiesByPid(Guid pid)
        {
            string sqlQuery = "SELECT * FROM Activities WHERE Pid = @Pid";

            // 建立資料庫連線
            using (var connection = _dbContext.CreateConnection())
            {
                // 執行查詢
                var Activties = await connection.QueryAsync<Activities>(sqlQuery, new { Pid = pid });
                return Activties.ToList();
            }
        }
    }
}
