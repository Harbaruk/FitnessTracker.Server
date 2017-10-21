using FitnessTracker.DataModel;

namespace FitnessTracker.Operations.Abstraction
{
    public interface IUserProfileOperations
    {
        UserProfileModel GetProfile(int currUserId);
        void UpdateProfile(UserProfileModel model, int currUserId);
    }
}
