using Pets.Models;
using Pets.Utilities;
using Pets.Dtos;
using Pets.Interfaces;
using Dapper;

namespace Pets.Repositories
{
    public class Cross2Repositories : ICross2
    {
        private readonly DbContext _dbContext;
        public Cross2Repositories(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        // 查詢Calendar 和參與的所有Member 的詳細資料（依指定id）
        public async Task<PetDetailsOfVaccine> GetPetDetailsByVaccineId(Guid id)
        {
            string sqlQuery = "SELECT Mid, Mname, Mphone FROM Member WHERE Mid = @Id;" + "SELECT C.* FROM Calendar C, CalendarJoin J " + "WHERE J.Mid = @Id AND C.Cid = J.Cid;";
            using (var connection = _dbContext.CreateConnection())
            {
                var multi = await connection.QueryMultipleAsync(sqlQuery, new { Id = id });
                var member = await multi.ReadSingleOrDefaultAsync<PetDetailsOfVaccine>();
                if (member != null) member.myPets = (await multi.ReadAsync<myPet>()).ToList();
                return member;
            }
        }
        // 查詢Member 和他/她參與的所有Calendars 的詳細資料（依指定id）
        public async Task<VaccinesDetailsOfPet> GetVaccinesDetailsByPetId(Guid id)
        {
            string sqlQuery = "SELECT Cid, Cname FROM Calendar WHERE Cid = @Id;" + "SELECT M.* FROM Member M, CalendarJoin J " + "WHERE J.Cid = @Id AND M.Mid = J.Mid;";
            using (var connection = _dbContext.CreateConnection())
            {
                var multi = await connection.QueryMultipleAsync(sqlQuery, new { Id = id });
                var calendar = await multi.ReadSingleOrDefaultAsync<VaccinesDetailsOfPet>();
                if (calendar != null) calendar.Vaccines = (await multi.ReadAsync<Vaccine>()).ToList();
                return calendar;
            }
        }
    }
}
