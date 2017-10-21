using FitnessTracker.DataAccess;
using FitnessTracker.DataAccess.Entity;
using FitnessTracker.DataModel;
using FitnessTracker.Operations.Abstraction;
using System;
using System.Linq;

namespace FitnessTracker.Operations.Implementation
{
    public class ExpirationTokenOperations : IExpirationTokenOperations
    {
        private readonly IUnitOfWork _unitOfWork;

        public ExpirationTokenOperations(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool CheckExpiration(int currentUserId)
        {
            var expirationToken = _unitOfWork.Repository<ExpirationTokenEntity>().GetById(currentUserId);
            return expirationToken == null;
        }

        public void Update(ExpirationTokenModel item)
        {
            var user = _unitOfWork.Repository<UserEntity>().Include(x => x.Token).FirstOrDefault(x => x.Id == item.UserId);

            if (user != null)
            {
                user.Token = new ExpirationTokenEntity
                {
                    LastActivityDateTime = DateTimeOffset.Now
                };
                _unitOfWork.SaveChanges();
            }
        }
    }
}
