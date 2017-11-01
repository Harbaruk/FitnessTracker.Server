using FitnessTracker.DataModel.Exercises;
using System.Collections.Generic;

namespace FitnessTracker.DataModel
{
    public class BlockExersiceModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<MyExercisesModel> Exersices { get; set; }
    }
}
