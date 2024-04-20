﻿using Pets.Interfaces;
using Pets.Models;
using Pets.Utilities;
using Pets.Dtos;
using Dapper;
using System.Data;

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
        public async Task<lostForCreationDto> CreateLost(lostForCreationDto lost)
        {
            string sqlQuery = "INSERT INTO lost (LBreed, LTime,LPlace,LFeature,LContactlnformation) VALUES (@LBreed, @LTime,@LPlace,@LFeature,@LContactlnformation)";
            // 建立資料庫連線
            using (var connection = _dbContext.CreateConnection())
            {
                // 執行新增
                await connection.ExecuteAsync(sqlQuery, lost);
                return lost;
            }
        }
        public async Task UpdateLost(Guid id, lostForUpdateDto lost)
        {
            string sqlQuery = "UPDATE lost SET LBreed = @LBreed, LTime = @LTime, LPlace = @LPlace, LFeature = @LFeature,LContactlnformation=@LContactlnformation WHERE Lid = @Id";
            // 建立參數物件
            var parameters = new DynamicParameters();
            // 加入參數
            parameters.Add("Id", id, DbType.Guid);
            parameters.Add("LBreed", lost.LBreed, DbType.String);
            parameters.Add("LTime", lost.LTime, DbType.String);
            parameters.Add("LPlace", lost.LPlace, DbType.String);
            parameters.Add("LFeature", lost.LFeature, DbType.String);
            parameters.Add("LContactlnformation", lost.LContactlnformation, DbType.String);
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
    }
}
