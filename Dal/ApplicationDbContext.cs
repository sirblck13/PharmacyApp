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

        #region Overrides

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connString = "DefaultConnection";

            if (!string.IsNullOrEmpty(connString))
                optionsBuilder.UseMySql(connString, ServerVersion.AutoDetect(connString), opts =>
                {
                    opts.MigrationsAssembly("Dal");
                    opts.CommandTimeout((int)TimeSpan.FromHours(1).TotalSeconds);

                    opts.EnableRetryOnFailure(
                        maxRetryCount: 5,
                        maxRetryDelay: TimeSpan.FromSeconds(30),
                        errorNumbersToAdd: null
                        );
                });

            base.OnConfiguring(optionsBuilder);
        }

        #endregion
    }
}
