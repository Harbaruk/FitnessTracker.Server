using FitnessTracker.DataAccess;
using FitnessTracker.DataAccess.Entity;
using FitnessTracker.DataModel;
using FitnessTracker.Operations.Abstraction;
using System.Linq;

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
            var user = _unitOfWork.Repository<UserEntity>().Include(x=>x.Profile).FirstOrDefault(x=>x.Id ==currUserId);

            return new UserProfileModel
            {
                Age = user.Profile.Age,
                Height = user.Profile.Height,
                Weight = user.Profile.Weight,
                Sex = user.Profile.Sex,
                Firstname = user.Firstname,
                Lastname = user.Lastname
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
