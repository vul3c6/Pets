using Pets.Dtos;
using Pets.Models;

namespace Pets.Interfaces
{
    public interface IVaccine
    {
        // 疫苗資料的介面
        public Task<IEnumerable<Vaccine>> GetAllVaccinePets();
        public Task<Vaccine> GetVaccineById(Guid id);
        public Task<VaccineForCreationDto> CreateVaccine(VaccineForCreationDto vaccine);
        public Task UpdateVaccine(Guid id, VaccineForUpdateDto vaccine);
        public Task DeleteVaccine(Guid id);
        //
        public Task<IEnumerable<Vaccine>> GetVaccinesByPid(Guid pid);
    }
}
