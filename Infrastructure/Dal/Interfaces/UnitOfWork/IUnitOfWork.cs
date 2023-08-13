namespace Infrastructure.Dal.Interfaces.UnitsOfWork
{
    public interface IUnitOfWork
    {
        void Save();

        Task SaveAsync();

        void CancelChanges();
    }
}
