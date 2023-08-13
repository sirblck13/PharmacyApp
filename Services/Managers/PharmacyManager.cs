using Infrastructure.Dal.Interfaces.UnitOfWork;
using Infrastructure.Dto.Pharmacy;
using Infrastructure.Interfaces.Managers;

namespace Services.Managers
{
    public class PharmacyManager : IPharmacyManager
    {
        #region Private Fields

        private readonly IPharmacyUow _pharmacyUow;

        #endregion

        #region Constructor

        public PharmacyManager(IPharmacyUow pharmacyUow)
        {
            _pharmacyUow = pharmacyUow;
        }

        #endregion

        #region Public Method

        public async Task<PharmacyDto> GetByIdAsync(Guid id)
        {
            var pharmacyDto = await _pharmacyUow.GetPharmacyByIdAsync(id);
            return pharmacyDto;
        }

        public async Task<IEnumerable<PharmacyDto>> GetAllAsync()
        {
            var pharmacies = await _pharmacyUow.GetAllPharmaciesAsync();
            return pharmacies;
        }

        public async Task<PharmacyDto> UpdateAsync(PharmacyDto sourceDto)
        {
            var pharmacyDto = await _pharmacyUow.UpdatePharmacyAsync(sourceDto);
            return pharmacyDto;
        }

        #endregion
    }
}
