using FitnessTracker.DataModel;
using System.Collections.Generic;

namespace FitnessTracker.Operations.Abstraction
{
    public interface IAdminOperations
    {
        ICollection<UserModel> GetUsers(int skip, int take);
        void DeleteUser(int id);
    }
}