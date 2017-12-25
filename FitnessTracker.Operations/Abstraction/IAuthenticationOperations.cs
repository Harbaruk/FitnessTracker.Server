using FitnessTracker.DataModel;
using FitnessTracker.DataModel.Auth;

namespace FitnessTracker.Operations.Abstraction
{
    public interface IAuthenticationOperations
    {
        UserModel RegisterUser(AuthenticationModel user);
        UserModel FindUser(string username, string password);
        SaltModel GenerateSalt(string password);
        //void UpdateToken(ExpirationTokenModel model);
    }
}
