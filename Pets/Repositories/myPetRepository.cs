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
        public async Task<IEnumerable<MyPet>> GetAllMyPets()
        {
            string sqlQuery = "SELECT * FROM myPet";
            // 建立資料庫連線
            using (var connection = _dbContext.CreateConnection())
            {
                // 執行查詢
                var myPets = await connection.QueryAsync<MyPet>(sqlQuery);
                return myPets.ToList();
            }
        }

        //查詢單一 myPets 資料（依指定 Id）
        public async Task<MyPet> GetMyPetById(Guid id)
        {
            string sqlQuery = "SELECT * FROM myPet WHERE Pid = @Id";
            // 建立資料庫連線
            using (var connection = _dbContext.CreateConnection())
            {
                // 執行查詢
                var myPet = await
                connection.QueryFirstOrDefaultAsync<MyPet>(sqlQuery, new { Id = id });
                return myPet;
            }
        }

        // 新增 myPets 資料
        public async Task<myPetForCreationDto> CreateMyPet(myPetForCreationDto myPet)
        {
            string sqlQuery = "INSERT INTO myPet (Maccount, Pname, Pbreed, Psex, Pweight, Pborn) VALUES (@Maccount, @Pname, @Pbreed, @Psex, @Pweight, @Pborn)";
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
            string sqlQuery = "UPDATE myPet SET Pname = @Pname, Pbreed = @Pbreed, Psex=@Psex, Pweight = @Pweight, Pborn = @Pborn WHERE Pid = @Id";
            // 建立參數物件
            var parameters = new DynamicParameters();
            // 加入參數
            parameters.Add("Id", id, DbType.Guid);
            parameters.Add("Pname", myPet.Pname, DbType.String);
            parameters.Add("Pbreed", myPet.Pbreed, DbType.String);
            parameters.Add("Psex", myPet.Psex, DbType.String);
            parameters.Add("Pweight", myPet.Pweight, DbType.String);
            parameters.Add("Pborn", myPet.Pborn, DbType.String);
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
        public async Task<IEnumerable<MyPet>> GetPetsByMaccount(string maccount)
        {
            string sqlQuery = "SELECT * FROM myPet WHERE Maccount = @Maccount";

            using (var connection = _dbContext.CreateConnection())
            {
                var pets = await connection.QueryAsync<MyPet>(sqlQuery, new { Maccount = maccount });
                return pets;
            }
        }

    }
}
