using Pets.Interfaces;
using Pets.Models;
using Pets.Utilities;
using Pets.Dtos;
using Dapper;
using System.Data;

namespace Pets.Repositories
{
    public class myPetRepository : ImyPet
    {
        private readonly DbContext _dbContext;
        public myPetRepository(DbContext dbContext)
        {
            // 注入 DbContext 服務
            _dbContext = dbContext;
        }
        // 查詢所有 myPet 資料的實作
        public async Task<IEnumerable<myPet>> GetAllmyPets()
        {
            string sqlQuery = "SELECT * FROM myPet";
            // 建立資料庫連線
            using (var connection = _dbContext.CreateConnection())
            {
                // 執行查詢
                var myPets = await connection.QueryAsync<myPet>(sqlQuery);
                return myPets.ToList();
            }
        }

        // 查詢單一 myPets 資料（依指定 Id）
        public async Task<myPet> GetmyPetById(Guid id)
        {
            string sqlQuery = "SELECT * FROM myPet WHERE Pid = @Id";
            // 建立資料庫連線
            using (var connection = _dbContext.CreateConnection())
            {
                // 執行查詢
                var myPet = await
                connection.QueryFirstOrDefaultAsync<myPet>(sqlQuery, new { Id = id });
                return myPet;
            }
        }

        // 新增 myPets 資料
        public async Task<myPetForCreationDto> CreateMyPet(myPetForCreationDto myPet)
        {
            string sqlQuery = "INSERT INTO myPet (PName, PBreed, PWeight, PBorn) VALUES (@PName, @PBreed, @PWeight, @PBorn)";
            // 建立資料庫連線
            using (var connection = _dbContext.CreateConnection())
            {
                // 執行新增
                await connection.ExecuteAsync(sqlQuery, myPet);
                return myPet;
            }
        }

        // 更新 myPet 資料（依指定 id）
        public async Task UpdateMyPet(Guid id, myPetForUpdateDto myPet)
        {
            string sqlQuery = "UPDATE myPet SET PName = @PName, PBreed = @PBreed, PWeight = @PWeight, PBorn = @PBorn WHERE Pid = @Id";
            // 建立參數物件
            var parameters = new DynamicParameters();
            // 加入參數
            parameters.Add("Id", id, DbType.Guid);
            parameters.Add("PName", myPet.PName, DbType.String);
            parameters.Add("PBreed", myPet.PBreed, DbType.String);
            parameters.Add("PWeight", myPet.PWeight, DbType.String);
            parameters.Add("PBorn", myPet.PBorn, DbType.String);
            // 建立資料庫連線
            using (var connection = _dbContext.CreateConnection())
            {
                // 執行更新
                await connection.ExecuteAsync(sqlQuery, parameters);
            }

        }

        // 刪除 myPet 資料（依指定 id）
        public async Task DeleteMyPet(Guid id)
        {
            string sqlQuery = "DELETE FROM myPet WHERE Pid = @Id";
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
