using FitnessTracker.DataModel.Excersices;
using FitnessTracker.DataModel.Plan;
using System.Collections.Generic;

namespace FitnessTracker.Operations.Abstraction
{
    public interface IMyPlanOperations
    {
        ICollection<MyPlanModel> GetPlans(int currUserId);
        int CreatePlan(CreatePlanModel model, int currUserId);
        ICollection<MyExcersicesModel> GetExcersices(int planId, int currUserId);
        void AddExcersice(PostExcersiceModel model, int currUserId);
        void UpdateExcersice(UpdateExcersiceModel model, int currUserId);
        void DeleteExcersice(int planId, int excersiceId, int currUserId);
    }
}
