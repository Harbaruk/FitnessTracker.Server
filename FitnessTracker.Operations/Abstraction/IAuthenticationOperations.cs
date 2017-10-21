using FitnessTracker.DataModel;

namespace FitnessTracker.Operations.Abstraction
{
    public interface IAuthenticationOperations
    {
        UserModel RegisterUser(AuthenticationModel user);
        UserModel FindUser(string username, string password);
        //UserModel ForgotPassword(ForgotPasswordModel item);
        //void UpdateToken(ExpirationTokenModel model);
    }
}
