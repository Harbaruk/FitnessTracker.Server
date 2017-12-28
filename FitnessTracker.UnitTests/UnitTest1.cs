using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using FitnessTracker.Operations.Abstraction;
using FitnessTracker.DataModel.Plan;
using System.Collections.Generic;

namespace FitnessTracker.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Mock<IMyPlanOperations> mock1 = new Mock<IMyPlanOperations>();

            mock1.Setup(x => x.GetPlans(1)).Returns(new List<MyPlanModel> { new MyPlanModel { } });

            Assert.AreEqual(mock1.Object.GetPlans(1).Count, 1);
        }
    }
}