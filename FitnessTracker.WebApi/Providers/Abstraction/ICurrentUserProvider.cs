using FitnessTracker.DataModel.Enums;

namespace FitnessTracker.WebApi.Providers.Abstraction
{
    public interface ICurrentUserProvider
    {
        int CurrentUserId { get; }
        string CurrentUserEmail { get; }
        UserType CurrentUserRole { get; }
        bool IsAuthenticated { get; }
        bool IsAdmin { get; }
    }
}
