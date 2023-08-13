using Dal.Interfaces;
using Dal.Mapping;
using Infrastructure.Dal.Interfaces.UnitOfWork;
using Infrastructure.Dto.Pharmacy;
using Microsoft.EntityFrameworkCore;

namespace Dal.UnitsOfWork
{
    public class PharmacyUow : UnitOfWork, IPharmacyUow
    {
        #region Private Fields

        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IPharmacyRepository _pharmacyRepository;

        #endregion

        #region Constructor

        public PharmacyUow(
            ApplicationDbContext applicationDbContext, 
            IPharmacyRepository pharmacyRepository)
            :base(applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            _pharmacyRepository = pharmacyRepository;
        }

        #endregion

        #region Public Methods

        public async Task<PharmacyDto> GetPharmacyByIdAsync(Guid id)
        {
            var pharmacy = await _pharmacyRepository.GetByIdAsync(id);
            if (pharmacy == null)
            {
                throw new ArgumentOutOfRangeException(nameof(id), $"Pharmacy with id {id} does not exist");
            }

            var pharmacyDto = pharmacy.ToDto();

            return pharmacyDto;
        }

        public async Task<IEnumerable<PharmacyDto>> GetAllPharmaciesAsync()
        {
            var pharmacies = await _pharmacyRepository.GetAllAsync();
            var pharmaciesDtos = pharmacies.Select(ps => ps.ToDto());

            return pharmaciesDtos;
        }

        public async Task<PharmacyDto> UpdatePharmacyAsync(PharmacyDto sourceDto)
        {
            var pharmacy = await _pharmacyRepository.GetByIdAsync(sourceDto.Id);
            if (pharmacy == null)
            {
                throw new ArgumentOutOfRangeException(nameof(sourceDto.Id), $"Pharmacy with id {pharmacy.Id} does not exist");
            }

            var strategy = _applicationDbContext.Database.CreateExecutionStrategy();
            await strategy.ExecuteInTransactionAsync(async () =>
            {
                var timestamp = DateTime.UtcNow;
                sourceDto.ToEntity(pharmacy);
                pharmacy.UpdateDate = timestamp;
                await _applicationDbContext.SaveChangesAsync();
            }, async () =>
            {
                return await Task.FromResult(true);
            });

            var result = await _pharmacyRepository.GetByIdAsync(sourceDto.Id);
            var resultDto = result.ToDto();
            return resultDto;
        }

        #endregion

    }
}
