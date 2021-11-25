using Microsoft.VisualStudio.TestTools.UnitTesting;
using PM.Algorithms;

namespace PM.Alogorithms.Test
{
    [TestClass]
    public class PrimeNumbersTest
    {
        [TestMethod]
        public void TestPrimeNumbersTo6()
        {
            var res = PrimeNumberHelper.GetPrimeNumbersTo(6);

            Assert.AreEqual(res[0], 2);
            Assert.AreEqual(res[1], 3);
            Assert.AreEqual(res[2], 5);
        }

        [TestMethod]
        public void TestPrimeNumbersTo25()
        {
            var res = PrimeNumberHelper.GetPrimeNumbersTo(25);

            Assert.AreEqual(res[0], 2);
            Assert.AreEqual(res[1], 3);
            Assert.AreEqual(res[2], 5);
            Assert.AreEqual(res[3], 7);
            Assert.AreEqual(res[4], 11);
            Assert.AreEqual(res[5], 13);
            Assert.AreEqual(res[6], 17);
            Assert.AreEqual(res[7], 19);
            Assert.AreEqual(res[8], 23);
        }

        [TestMethod]
        public void TestIsPrimeNumber6()
        {
            var res = PrimeNumberHelper.IsPrimeNumber(6);

            Assert.AreEqual(res, false);
        }

        [TestMethod]
        public void TestIsPrimeNumber23()
        {
            var res = PrimeNumberHelper.IsPrimeNumber(23);

            Assert.AreEqual(res, true);
        }
    }
}
