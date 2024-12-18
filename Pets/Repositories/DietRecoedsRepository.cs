﻿using Dapper;
using Pets.Dtos;
using Pets.Interfaces;
using Pets.Models;
using Pets.Utilities;
using System.Data;

namespace Pets.Repositories
{
    public class DietRecoedsRepository : IDietRecoeds
    {
        private readonly DbContext _dbContext;
        // 在建構子中初始化DbContext 服務
        public DietRecoedsRepository(DbContext dbContext)
        {
            // 注入DbContext 服務
            _dbContext = dbContext;
        }
        // 查詢所有飲食資料的實作
        public async Task<IEnumerable<DietRecords>> GetAllDietRecoeds()
        {
            // 設定查詢用的SQL 語法
            string sqlQuery = "SELECT * FROM dietRecoeds";
            // 建立資料庫連線
            using (var connection = _dbContext.CreateConnection())
            {
                // 執行查詢
                var DietRecoeds = await connection.QueryAsync<DietRecords>(sqlQuery);

                return DietRecoeds.ToList();
            }
        }
        // 查詢指定id 的飲食資料
        public async Task<DietRecords> GetDietRecordsById(Guid id)
        // 新增走失寵物資料
        {
            string sqlQuery = "SELECT * FROM dietRecoeds WHERE DRid = @Id";
            // 建立資料庫連線
            using (var connection = _dbContext.CreateConnection())
            {
                // 執行查詢
                var DietRecoeds = await connection.QueryFirstOrDefaultAsync<DietRecords>(sqlQuery, new { Id = id });
                return DietRecoeds;
            }
        }
        public async Task<DietRecoedsForCreactionDto> CreateDietRecords(DietRecoedsForCreactionDto DietRecoeds)
        {
            string sqlQuery = "INSERT INTO dietRecoeds (Pid,mealTime,foodType,amount,waterIntake,petReaction,DRremark) VALUES (@Pid,@mealTime,@foodType,@amount,@waterIntake,@petReaction,@DRremark)";
            // 建立資料庫連線
            using (var connection = _dbContext.CreateConnection())
            {
                // 執行新增
                await connection.ExecuteAsync(sqlQuery, DietRecoeds);
                return DietRecoeds;
            }
        }
        public async Task UpdateDietRecords(Guid id, DietRecoedsForUpdateDto DietRecoeds)
        {
            string sqlQuery = "UPDATE dietRecoeds SET mealTime = @mealTime, foodType = @foodType, amount = @amount, waterIntake = @waterIntake, petReaction = @petReaction, DRremark = @DRremark WHERE DRid = @Id";
            // 建立參數物件
            var parameters = new DynamicParameters();
            // 加入參數
            parameters.Add("Id", id, DbType.Guid);
            parameters.Add("mealTime", DietRecoeds.mealTime, DbType.DateTime);
            parameters.Add("foodType", DietRecoeds.foodType, DbType.String);
            parameters.Add("amount", DietRecoeds.amount, DbType.Int64);
            parameters.Add("waterIntake", DietRecoeds.waterIntake, DbType.Int64);
            parameters.Add("petReaction", DietRecoeds.petReaction, DbType.String);
            parameters.Add("DRremark", DietRecoeds.DRremark, DbType.String);
            // 建立資料庫連線
            using (var connection = _dbContext.CreateConnection())
            {
                // 執行更新
                await connection.ExecuteAsync(sqlQuery, parameters);
            }
        }
        public async Task DeleteDietRecords(Guid id)
        {
            string sqlQuery = "DELETE FROM dietRecoeds WHERE DRid = @Id";
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
        // 查詢多筆 DietRecords 資料(依指定 Pid)
        public async Task<IEnumerable<DietRecords>> GetDietRecordsByPid(Guid pid)
        {
            string sqlQuery = "SELECT * FROM dietRecoeds WHERE Pid = @Pid";

            // 建立資料庫連線
            using (var connection = _dbContext.CreateConnection())
            {
                // 執行查詢
                var dietRecords = await connection.QueryAsync<DietRecords>(sqlQuery, new { Pid = pid });
                return dietRecords.ToList();
            }
        }
    }
}
