using Dal.Model.Pharmacy;
using Microsoft.EntityFrameworkCore;

namespace Dal
{
    public class ApplicationDbContext : DbContext
    {

        #region private Fields



        #endregion

        #region Public Fields

        public virtual DbSet<Pharmacy> Pharmacy { get; set;}

        #endregion

        #region Constructor

        public ApplicationDbContext()
            : base()
        {
        }

        #endregion
    }
}
