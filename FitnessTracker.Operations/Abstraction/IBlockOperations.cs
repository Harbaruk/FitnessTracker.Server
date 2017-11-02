using FitnessTracker.DataModel;
using System.Collections.Generic;

namespace FitnessTracker.Operations.Abstraction
{
    public interface IBlockOperations
    {
        ICollection<BlockExersiceModel> GetBlocks(int planId, int currUserId);
        void CreateBlock(BlockPostModel model, int currUserId);
        void UpdateBlock(UpdateBlockModel model, int currUserId);
        void DeleteBlock(int blockId, int currUserId);
    }
}
