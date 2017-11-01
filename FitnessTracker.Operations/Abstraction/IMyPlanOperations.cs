using FitnessTracker.DataModel;
using FitnessTracker.DataModel.Exercises;
using FitnessTracker.DataModel.Plan;
using System.Collections.Generic;

namespace FitnessTracker.Operations.Abstraction
{
    public interface IMyPlanOperations
    {
        ICollection<MyPlanModel> GetPlans(int currUserId);
        int CreatePlan(CreatePlanModel model, int currUserId);
        void AddExercise(PostExerciseModel model, int currUserId);
        void UpdateExercise(UpdateExerciseModel model, int currUserId);
        void DeleteExercise(int planId, int ExerciseId, int currUserId);
        ICollection<BlockExersiceModel> GetBlocks(int planId, int currUserId);
        void CreateBlock(BlockPostModel model, int currUserId);
        void UpdateBlock(UpdateBlockModel model, int currUserId);
        void DeleteBlock(int blockId, int currUserId);
    }
}
