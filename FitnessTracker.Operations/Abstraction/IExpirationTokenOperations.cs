using FitnessTracker.DataModel;

namespace FitnessTracker.Operations.Abstraction
{
    public interface IExpirationTokenOperations
    {
        bool CheckExpiration(int currentUserId);
        void Update(ExpirationTokenModel item);
    }
}
