using FitnessTracker.DataAccess;
using FitnessTracker.DataModel;
using FitnessTracker.Operations.Abstraction;
using System;

namespace FitnessTracker.Operations.Implementation
{
    public class UserProfileOperations : IUserProfileOperations
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserProfileOperations(IUnitOfWork uow)
        {
            _unitOfWork = uow;
        }

        public UserProfileModel GetProfile(int currUserId)
        {
            throw new NotImplementedException();
        }

        public void UpdateProfile(UserProfileModel model, int currUserId)
        {
            throw new NotImplementedException();
        }
    }
}
