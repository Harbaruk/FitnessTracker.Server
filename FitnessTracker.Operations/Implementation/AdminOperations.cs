using FitnessTracker.Operations.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessTracker.DataModel;
using FitnessTracker.DataAccess;
using FitnessTracker.DataAccess.Entity;
using FitnessTracker.DataModel.Auth;

namespace FitnessTracker.Operations.Implementation
{
    public class AdminOperations : IAdminOperations
    {
        private readonly IUnitOfWork _unitOfWork;

        public AdminOperations(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Approve(int userId)
        {
            var user = _unitOfWork.Repository<UserEntity>().Set.FirstOrDefault(x => x.Id == userId);
            user.IsApproved = true;
            _unitOfWork.SaveChanges();
        }

        public void DeleteIndustry(int userId, int industry)
        {
            var user = _unitOfWork.Repository<UserEntity>().Include(x => x.Industries).FirstOrDefault(x => x.Id == userId);

            var entityToDelete = user.Industries.FirstOrDefault(x => x.Id == industry);

            user.Industries.Remove(entityToDelete);
            _unitOfWork.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            _unitOfWork.Repository<UserProfileEntity>().DeleteById(id);
            _unitOfWork.Repository<PlanEntity>().RemoveRange(_unitOfWork.Repository<PlanEntity>().Set.Where(x => x.Owner.Id == id));
            _unitOfWork.Repository<UserEntity>().DeleteById(id);
            _unitOfWork.SaveChanges();
        }

        public ICollection<ApproveModel> GetApproveList()
        {
            return _unitOfWork.Repository<UserEntity>()
                .Include(x => x.Industries)
                .Where(x => !x.IsApproved)
                .Select(x => new ApproveModel
                {
                    Id = x.Id,
                    Email = x.Email,
                    Firstname = x.Firstname,
                    Lastname = x.Lastname,
                    Industries = x.Industries.Select(y => new IndustryModel { Id = y.Id, Name = y.Name }).ToList()
                }).ToList();
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

        public void Reject(int userId)
        {
            _unitOfWork.Repository<UserEntity>().DeleteById(userId);
            _unitOfWork.SaveChanges();
        }
    }
}