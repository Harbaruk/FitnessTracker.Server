using FitnessTracker.DataAccess;
using FitnessTracker.DataAccess.Entity;
using FitnessTracker.DataModel.Exercises;
using FitnessTracker.DataModel.Plan;
using FitnessTracker.Operations.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FitnessTracker.Operations.Implementation
{
    public class MyPlanOperations : IMyPlanOperations
    {
        private readonly IUnitOfWork _unitOfWork;

        public MyPlanOperations(IUnitOfWork uow)
        {
            _unitOfWork = uow;
        }

        public void AddExercise(PostExerciseModel model, int currUserId)
        {
            var user = _unitOfWork.Repository<UserEntity>().GetById(currUserId);
            var plan = _unitOfWork.Repository<PlanEntity>().GetById(model.PlanId);

            if (user != null)
            {
                _unitOfWork.Repository<ExerciseEntity>().Insert(new ExerciseEntity
                {
                    Amount = model.Amount,
                    Distance = model.Distance,
                    KindOfSport = model.KindOfSport,
                    Time = model.Time,
                    Type = model.Type,
                    Weight = model.Weight,
                    CreatedAt = DateTimeOffset.Now,
                    Plan = plan
                });
                _unitOfWork.SaveChanges();
            }
        }

        public int CreatePlan(CreatePlanModel model, int currUserId)
        {
            var user = _unitOfWork.Repository<UserProfileEntity>().GetById(currUserId);

            var entityToInsert = new PlanEntity
            {
                Duration = model.Duration,
                Excercises = new List<ExerciseEntity>(),
                Name = model.Name,
                Owner = user
            };
            _unitOfWork.SaveChanges();

            return entityToInsert.Id;
        }

        public void DeleteExercise(int planId, int ExerciseId, int currUserId)
        {
            var Exercise = _unitOfWork.Repository<ExerciseEntity>()
                .Include(x => x.Plan, x => x.Plan.Owner)
                .FirstOrDefault(x => x.Plan.Owner.UserId == currUserId
                  && x.Id == ExerciseId && x.Plan.Id == planId);

            if (Exercise != null)
            {
                _unitOfWork.Repository<ExerciseEntity>().Delete(Exercise);
                _unitOfWork.SaveChanges();
            }
        }


        public ICollection<MyExercisesModel> GetExercises(int planId, int currUserId)
        {
            var plan = _unitOfWork.Repository<PlanEntity>()
                .Include(x => x.Owner, x => x.Excercises)
                .FirstOrDefault(x => x.Owner.UserId == currUserId && x.Id == planId);

            return plan.Excercises.Select(x => new MyExercisesModel
            {
                Amount = x.Amount,
                CreatedAt = x.CreatedAt,
                Distance = x.Distance,
                KindOfSport = x.KindOfSport,
                Time = x.Time,
                Id = x.Id,
                Type = x.Type,
                Weight = x.Weight
            }).ToList();
        }

        public ICollection<MyPlanModel> GetPlans(int currUserId)
        {
            return _unitOfWork.Repository<UserProfileEntity>()
                .Include(x => x.Plans)
                .FirstOrDefault(x => x.UserId == currUserId)
                .Plans
                .Select(x => new MyPlanModel
                {
                    Duration = x.Duration,
                    Name = x.Name,
                    Id = x.Id
                }).ToList();
        }

        public void UpdateExercise(UpdateExerciseModel model, int currUserId)
        {
            var Exercise = _unitOfWork.Repository<ExerciseEntity>().GetById(model.Id);

            if (Exercise != null)
            {
                Exercise.Amount = model.Amount;
                Exercise.Distance = model.Distance;
                Exercise.KindOfSport = model.KindOfSport;
                Exercise.Time = model.Time;
                Exercise.Type = model.Type;
                Exercise.Weight = model.Weight;
                _unitOfWork.SaveChanges();
            }
        }

    }
}
