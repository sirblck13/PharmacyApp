using Infrastructure.Dto.Pharmacy;

namespace Infrastructure.Interfaces.Managers
{
    public interface IPharmacyManager
    {
        Task<PharmacyDto> GetByIdAsync(Guid id);
        Task<IEnumerable<PharmacyDto>> GetAllAsync();
        Task<PharmacyDto> UpdateAsync(PharmacyDto sourceDto);
    }
}
