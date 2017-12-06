using FitnessTracker.DataModel;
using System.Collections.Generic;

namespace FitnessTracker.Operations.Abstraction
{
    public interface INewsOperations
    {
        ICollection<NewsModel> GetNews();
    }
}
