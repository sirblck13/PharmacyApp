using Dal.Interfaces;
using Dal.Model.Pharmacy;
using Microsoft.EntityFrameworkCore;

namespace Dal.Repositories
{
    public class PharmacyRepository : Repository<Pharmacy>, IPharmacyRepository
    {

        #region Constructors

        public PharmacyRepository(ApplicationDbContext dbContext)
            :base(dbContext)
        {
        }

        #endregion

        #region Public Methods

        public async Task<Pharmacy> GetByIdAsync(Guid id)
        {
            var pharmacy = await Entities
                .SingleOrDefaultAsync(p => p.Id == id && p.DeletionDate == null);
            return pharmacy;
        }

        #endregion

    }
}
