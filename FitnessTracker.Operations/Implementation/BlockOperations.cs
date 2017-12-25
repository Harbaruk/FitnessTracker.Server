using FitnessTracker.DataAccess;
using FitnessTracker.DataAccess.Entity;
using FitnessTracker.DataModel;
using FitnessTracker.DataModel.Exercises;
using FitnessTracker.Operations.Abstraction;
using System.Collections.Generic;
using System.Linq;

namespace FitnessTracker.Operations.Implementation
{
    public class BlockOperations : IBlockOperations
    {
        private readonly IUnitOfWork _unitOfWork;

        public BlockOperations(IUnitOfWork uow)
        {
            _unitOfWork = uow;
        }

        public ICollection<BlockExersiceModel> GetBlocks(int planId, int currUserId)
        {
            return _unitOfWork.Repository<BlockExersiceEntity>()
                .Include(x => x.Plan, x => x.Plan.Owner)
                .Where(x => x.Plan.Id == planId && x.Plan.Owner.Id == currUserId).ToList()
                .Select(x => new BlockExersiceModel
                {
                    Exersices = x.Exersices.Select(y => new MyExercisesModel
                    {
                        Amount = y.Amount,
                        CreatedAt = y.CreatedAt,
                        Distance = y.Distance,
                        Time = y.Time,
                        Id = y.Id,
                        Weight = y.Weight
                    }).ToList(),
                    Id = x.Id,
                    Name = x.Name
                }).ToList();
        }

        public void UpdateBlock(UpdateBlockModel model, int currUserId)
        {
            var block = _unitOfWork.Repository<BlockExersiceEntity>()
                .Include(x => x.Plan.Owner)
                .FirstOrDefault(x => x.Plan.Owner.Id == currUserId && x.Id == model.Id);

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
                FirstOrDefault(x => x.Owner.Id == currUserId && x.Id == model.PlanId);

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
                .FirstOrDefault(x => x.Plan.Owner.Id == currUserId && x.Id == blockId);

            _unitOfWork.Repository<BlockExersiceEntity>().Delete(block);
            _unitOfWork.SaveChanges();
        }
    }
}