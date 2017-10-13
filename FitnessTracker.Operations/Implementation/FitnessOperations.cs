using FitnessTracker.DataAccess;
using FitnessTracker.DataAccess.Entity;
using FitnessTracker.DataModel;
using FitnessTracker.Operations.Abstraction;
using System.Collections.Generic;
using System.Linq;

namespace FitnessTracker.Operations.Implementation
{
    public class FitnessOperations : IFitnessOperations
    {
        private readonly IUnitOfWork _unitOfWork;

        public FitnessOperations(IUnitOfWork uow)
        {
            _unitOfWork = uow;
        }

        public void Add(PostFitnessModel model)
        {
            _unitOfWork.Repository<FitnessProfileEntity>().Insert(new FitnessProfileEntity
            {
                CaloriesBurned = model.CaloriesBurned,
                DaysOnDiet = model.DaysOnDiet,
                KilometersRun = model.KilometersRun,
                TypeOfDiet = model.TypeOfDiet
            });
            _unitOfWork.SaveChanges();
        }

        public void Delete(int id)
        {
            _unitOfWork.Repository<FitnessProfileEntity>().DeleteById(id);
            _unitOfWork.SaveChanges();
        }

        public ICollection<FitnessModel> GetAll()
        {
            return _unitOfWork.Repository<FitnessProfileEntity>().Set.Select(model => new FitnessModel
            {
                Id = model.Id,
                CaloriesBurned = model.CaloriesBurned,
                DaysOnDiet = model.DaysOnDiet,
                KilometersRun = model.KilometersRun,
                TypeOfDiet = model.TypeOfDiet
            }).ToList();
        }

        public void Update(FitnessModel model)
        {
            var profile = _unitOfWork.Repository<FitnessProfileEntity>().GetById(model.Id);

            profile.CaloriesBurned = model.CaloriesBurned;
            profile.DaysOnDiet = model.DaysOnDiet;
            profile.KilometersRun = model.KilometersRun;
            profile.TypeOfDiet = model.TypeOfDiet;

            _unitOfWork.SaveChanges();
        }
    }
}
