using Pets.Dtos;
using Dapper;
using Pets.Interfaces;
using Pets.Models;
using Pets.Utilities;

namespace Pets.Repositories
{
    public class CrossRepositories : ICross
    {
        private readonly DbContext _dbContext;
        public CrossRepositories(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        // 查詢會員所有登記的寵物詳細資料（依會員id）
        public async Task<PetDetailsOfMember> GetPetDetailsByMemberId(Guid id)
        {
            string sqlQuery = "SELECT Mid, MName, MAccount FROM Member WHERE Mid = @Id;" +
                "SELECT P.* FROM myPet P, memberOfMyPet MP " + "WHERE MP.Mid = @Id AND P.Pid = MP.Pid;";
            using (var connection = _dbContext.CreateConnection())
            {
                var multi = await connection.QueryMultipleAsync(sqlQuery, new { Id = id });
                var member = await multi.ReadSingleOrDefaultAsync<PetDetailsOfMember>();
                if (member != null) member.Pets = (await multi.ReadAsync<myPet>()).ToList();
                return member;
            }
        }
        // 查詢寵物所登記的疫苗詳細資料（依寵物id）
        public async Task<VaccinesDetailOfPet> GetVaccinesDetailsByPetId(Guid id)
        {
            string sqlQuery = "SELECT Pid, PName, PBreed FROM myPet WHERE Pid = @Id;" +
                "SELECT V.* FROM vaccine V, myPetOfVaccine PV " + "WHERE PV.Pid = @Id AND V.Vid = PV.Vid;";
            using (var connection = _dbContext.CreateConnection())
            {
                var multi = await connection.QueryMultipleAsync(sqlQuery, new { Id = id });
                var member = await multi.ReadSingleOrDefaultAsync<VaccinesDetailOfPet>();
                if (member != null) member.Vaccines = (await multi.ReadAsync<Vaccine>()).ToList();
                return member;
            }
        }
    }
}