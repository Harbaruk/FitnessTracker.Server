using FitnessTracker.DataAccess;
using FitnessTracker.DataAccess.Entity;
using FitnessTracker.DataModel;
using FitnessTracker.Operations.Abstraction;

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
            var user = _unitOfWork.Repository<UserProfileEntity>().GetById(currUserId);

            return new UserProfileModel
            {
                Age = user.Age,
                Height = user.Height,
                Weight = user.Weight,
                Sex = user.Sex
            };
        }

        public void UpdateProfile(UserProfileModel model, int currUserId)
        {
            var user = _unitOfWork.Repository<UserProfileEntity>().GetById(currUserId);

            user.Age = model.Age;
            user.Height = model.Height;
            user.Sex = model.Sex;
            user.Weight = model.Weight;
            _unitOfWork.SaveChanges();
        }
    }
}
