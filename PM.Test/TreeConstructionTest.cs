using Microsoft.VisualStudio.TestTools.UnitTesting;
using PM.Algorithms;
using System.Collections.Generic;

namespace PM.Alogorithms.Test
{
    [TestClass]
    public class TreeConstructionTest
    {
        [TestMethod]
        public void TestTreeConstruction_Success()
        {
            var input = new List<string>() { "(1,2)", "(2,4)", "(5,7)", "(7,2)", "(9,5)" };
            var res = TreeConstructionHelper.IsBinaryTree(input);

            Assert.AreEqual(res, true);
        }

        [TestMethod]
        public void TestTreeConstruction_Fail_MoreThan2Child()
        {
            var input = new List<string>() { "(1,2)", "(3,2)", "(2,12)", "(5,2)" };
            var res = TreeConstructionHelper.IsBinaryTree(input);

            Assert.AreEqual(res, false);
        }

        [TestMethod]
        public void TestTreeConstruction_Fail_MoreThan1Parent()
        {
            var input = new List<string>() { "(1,2)", "(2,4)", "(5,7)", "(7,2)", "(9,5)", "(9,6)" };
            var res = TreeConstructionHelper.IsBinaryTree(input);

            Assert.AreEqual(res, false);
        }

    }
}
