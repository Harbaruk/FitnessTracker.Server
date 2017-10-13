using FitnessTracker.DataModel;
using System.Collections.Generic;

namespace FitnessTracker.Operations.Abstraction
{
    public interface IFitnessOperations
    {
        ICollection<FitnessModel> GetAll();
        void Add(PostFitnessModel model);
        void Update(FitnessModel model);
        void Delete(int id);

    }
}
