using Microsoft.VisualStudio.TestTools.UnitTesting;
using PM.Algorithms;
using System.Collections.Generic;

namespace PM.Alogorithms.Test
{
    [TestClass]
    public class FactorialTest
    {
        [TestMethod]
        public void TestFactorial7()
        {
            var res = FactorialHelper.CalacFactorial(7);

            Assert.AreEqual(res, 5040);
        }

        [TestMethod]
        public void TestFactorial8()
        {
            var res = FactorialHelper.CalacFactorial(8);

            Assert.AreEqual(res, 40320);
        }

    }
}
