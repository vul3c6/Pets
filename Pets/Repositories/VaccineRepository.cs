using Dapper;
using Pets.Interfaces;
using Pets.Dtos;
using Pets.Models;
using Pets.Utilities;
using System.Data;

namespace Pets.Repositories
{
    public class VaccineRepository : IVaccine
    {
        private readonly DbContext _dbContext;
        // 在建構子中初始化DbContext 服務
        public VaccineRepository(DbContext dbContext)
        {
            // 注入DbContext 服務
            _dbContext = dbContext;
        }
        // 查詢所有疫苗資料的實作
        public async Task<IEnumerable<Vaccine>> GetAllVaccinePets()
        {
            // 設定查詢用的SQL 語法
            string sqlQuery = "SELECT * FROM vaccine";
            // 建立資料庫連線
            using (var connection = _dbContext.CreateConnection())
            {
                // 執行查詢
                var vaccine = await connection.QueryAsync<Vaccine>(sqlQuery);

                return vaccine.ToList();
            }
        }
        // 查詢指定id 的疫苗資料
        public async Task<Vaccine> GetVaccineById(Guid id)
        // 新增走失寵物資料
        {
            string sqlQuery = "SELECT * FROM vaccine WHERE Vid = @Id";
            // 建立資料庫連線
            using (var connection = _dbContext.CreateConnection())
            {
                // 執行查詢
                var vaccine = await connection.QueryFirstOrDefaultAsync<Vaccine>(sqlQuery, new { Id = id });
                return vaccine;
            }
        }
        public async Task<VaccineForCreationDto> CreateVaccine(VaccineForCreationDto vaccine)
        {
            string sqlQuery = "INSERT INTO vaccine (Pid,Vname,Vdate) VALUES (@Pid,@Vname,@Vdate)";
            // 建立資料庫連線
            using (var connection = _dbContext.CreateConnection())
            {
                // 執行新增
                await connection.ExecuteAsync(sqlQuery, vaccine);
                return vaccine;
            }
        }
        public async Task UpdateVaccine(Guid id, VaccineForUpdateDto vaccine)
        {
            string sqlQuery = "UPDATE vaccine SET Vname = @Vname, Vdate = @Vdate, Vremarks = @Vremarks WHERE Vid = @Id";
            // 建立參數物件
            var parameters = new DynamicParameters();
            // 加入參數
            parameters.Add("Id", id, DbType.Guid);
            parameters.Add("Vname", vaccine.Vname, DbType.String);
            parameters.Add("Vdate", vaccine.Vdate, DbType.DateTime);
            parameters.Add("Vremarks", vaccine.Vremarks, DbType.String);
            // 建立資料庫連線
            using (var connection = _dbContext.CreateConnection())
            {
                // 執行更新
                await connection.ExecuteAsync(sqlQuery, parameters);
            }
        }
        public async Task DeleteVaccine(Guid id)
        {
            string sqlQuery = "DELETE FROM vaccine WHERE Vid = @Id";
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
        public async Task<IEnumerable<Vaccine>> GetVaccinesByPid(string pid)
        {
            string sqlQuery = "SELECT * FROM vaccine WHERE Pid = @Pid";

            // 建立資料庫連線
            using (var connection = _dbContext.CreateConnection())
            {
                // 執行查詢
                var vaccine = await connection.QueryAsync<Vaccine>(sqlQuery, new { Pid = pid });
                return vaccine.ToList();
            }
        }
    }
}
