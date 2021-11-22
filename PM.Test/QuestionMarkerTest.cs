using Microsoft.VisualStudio.TestTools.UnitTesting;
using PM.Algorithms;


namespace PM.Test
{
    [TestClass]
    public class QuestionMarkerTest
    {
        [TestMethod]
        public void TestWithTrueResult()
        {
            var res = QuestionMarksHelper.QuestionsMarks("arrb6???4xxbl5???eee5");

            Assert.AreEqual(res, true);
        }

        [TestMethod]
        public void Test2WithTrueResult()
        {
            var res = QuestionMarksHelper.QuestionsMarks("6???4hghhh5???5??5???5");

            Assert.AreEqual(res, true);
        }

        [TestMethod]
        public void TestWithFalseResult()
        {
            var res = QuestionMarksHelper.QuestionsMarks("aa6?9");

            Assert.AreEqual(res, false);
        }
    }
}
