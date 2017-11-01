using FitnessTracker.DataAccess;
using FitnessTracker.DataAccess.Entity;
using FitnessTracker.DataModel;
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
            var block = _unitOfWork.Repository<BlockExersiceEntity>().GetById(model.BlockId);

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
                    Block = block
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
                Blocks = new List<BlockExersiceEntity>(),
                Name = model.Name,
                Owner = user
            };
            _unitOfWork.SaveChanges();

            return entityToInsert.Id;
        }

        public void DeleteExercise(int blockId, int exerciseId, int currUserId)
        {
            var exercise = _unitOfWork.Repository<ExerciseEntity>()
                .Include(x => x.Block, x => x.Block.Plan.Owner)
                .FirstOrDefault(x => x.Block.Plan.Owner.UserId == currUserId
                  && x.Id == exerciseId && x.Block.Id == blockId);

            if (exercise != null)
            {
                _unitOfWork.Repository<ExerciseEntity>().Delete(exercise);
                _unitOfWork.SaveChanges();
            }
        }

        public ICollection<BlockExersiceModel> GetBlocks(int planId, int currUserId)
        {
            return _unitOfWork.Repository<BlockExersiceEntity>()
                .Include(x => x.Plan, x => x.Plan.Owner)
                .Where(x => x.Plan.Id == planId && x.Plan.Owner.UserId == currUserId).ToList()
                .Select(x => new BlockExersiceModel
                {
                    Exersices = x.Exersices.Select(y => new MyExercisesModel
                    {
                        Amount = y.Amount,
                        CreatedAt = y.CreatedAt,
                        Distance = y.Distance,
                        KindOfSport = y.KindOfSport,
                        Time = y.Time,
                        Id = y.Id,
                        Type = y.Type,
                        Weight = y.Weight
                    }).ToList(),
                    Id = x.Id,
                    Name = x.Name
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
            var exercise = _unitOfWork.Repository<ExerciseEntity>().GetById(model.Id);

            if (exercise != null)
            {
                exercise.Amount = model.Amount;
                exercise.Distance = model.Distance;
                exercise.KindOfSport = model.KindOfSport;
                exercise.Time = model.Time;
                exercise.Type = model.Type;
                exercise.Weight = model.Weight;
                _unitOfWork.SaveChanges();
            }
        }

        public void UpdateBlock(UpdateBlockModel model, int currUserId)
        {
            var block = _unitOfWork.Repository<BlockExersiceEntity>()
                .Include(x => x.Plan.Owner)
                .FirstOrDefault(x => x.Plan.Owner.UserId == currUserId && x.Id == model.Id);

            if (block != null)
            {
                block.Name = model.Name;
            }
            _unitOfWork.SaveChanges();
        }

        public void CreateBlock(BlockPostModel model, int currUserId)
        {
            var plan = _unitOfWork.Repository<PlanEntity>()
                .Include(x => x.Owner).
                FirstOrDefault(x => x.Owner.UserId == currUserId && x.Id == model.PlanId);

            _unitOfWork.Repository<BlockExersiceEntity>().Insert(new BlockExersiceEntity
            {
                Exersices = new List<ExerciseEntity>(),
                Name = model.Name,
                Plan = plan
            });
            _unitOfWork.SaveChanges();
        }

        public void DeleteBlock(int blockId, int currUserId)
        {
            var block = _unitOfWork.Repository<BlockExersiceEntity>().Include(x => x.Plan.Owner)
                .FirstOrDefault(x => x.Plan.Owner.UserId == currUserId && x.Id == blockId);

            _unitOfWork.Repository<BlockExersiceEntity>().Delete(block);
            _unitOfWork.SaveChanges();
        }
    }
}
