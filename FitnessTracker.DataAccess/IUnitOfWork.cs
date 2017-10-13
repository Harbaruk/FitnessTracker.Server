namespace FitnessTracker.DataAccess
{
    public interface IUnitOfWork
    {
        Repository<T> Repository<T>() where T : class;
        void SaveChanges();
    }
}
