using FitnessTracker.DataModel;
using FitnessTracker.DataModel.Auth;
using System.Collections.Generic;

namespace FitnessTracker.Operations.Abstraction
{
    public interface IAuthenticationOperations
    {
        UserModel RegisterUser(AuthenticationModel user);
        UserModel FindUser(string username, string password);
        SaltModel GenerateSalt(string password);
        UserAuthModel GetMe(int userId);
        ICollection<IndustryModel> GetIndustries();
        void CreateAdmin();
        //void UpdateToken(ExpirationTokenModel model);
    }
}