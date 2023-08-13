using Dal.Model.Pharmacy;

namespace Dal.Interfaces
{
    public interface IPharmacyRepository
    {
        Task<Pharmacy> GetByIdAsync(Guid id);
        Task<IEnumerable<Pharmacy>> GetAllAsync();
    }
}
