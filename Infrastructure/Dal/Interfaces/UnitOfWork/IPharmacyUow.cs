using Infrastructure.Dto.Pharmacy;

namespace Infrastructure.Dal.Interfaces.UnitOfWork
{
    public interface IPharmacyUow
    {
        Task<PharmacyDto> GetPharmacyByIdAsync(Guid id);
        Task<IEnumerable<PharmacyDto>> GetAllPharmaciesAsync();
        Task<PharmacyDto> UpdatePharmacyAsync(PharmacyDto sourceDto);

    }
}
