using FitnessTracker.Operations.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessTracker.DataModel;
using FitnessTracker.DataAccess;
using FitnessTracker.DataAccess.Entity;

namespace FitnessTracker.Operations.Implementation
{
    public class AdminOperations : IAdminOperations
    {
        private readonly IUnitOfWork _unitOfWork;

        public AdminOperations(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ICollection<UserModel> GetUsers(int skip = 0, int take = 10)
        {
            return _unitOfWork.Repository<UserEntity>().Set.Select(x => new UserModel
            {
                Id = x.Id,
                Email = x.Email,
                Firstname = x.Firstname,
                Lastname = x.Lastname,
                UserType = x.Role
            }).OrderByDescending(x => x.Id).Skip(skip).Take(take).ToList();
        }
    }
}