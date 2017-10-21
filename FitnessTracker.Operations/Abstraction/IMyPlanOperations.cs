using FitnessTracker.DataModel.Exercises;
using FitnessTracker.DataModel.Plan;
using System.Collections.Generic;

namespace FitnessTracker.Operations.Abstraction
{
    public interface IMyPlanOperations
    {
        ICollection<MyPlanModel> GetPlans(int currUserId);
        int CreatePlan(CreatePlanModel model, int currUserId);
        ICollection<MyExercisesModel> GetExercises(int planId, int currUserId);
        void AddExercise(PostExerciseModel model, int currUserId);
        void UpdateExercise(UpdateExerciseModel model, int currUserId);
        void DeleteExercise(int planId, int ExerciseId, int currUserId);
    }
}
