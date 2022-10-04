using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WindowsFormsApp1;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestS1mpleNumber1()
        {
            int testnumb = 8;
            bool res = true;
            CheckS1mpleNumber S = new CheckS1mpleNumber();
            Assert.AreEqual(S.checkSimpleNumber(testnumb),res, "Ожидаемый результат не получен.");
        }

        [TestMethod]
        public void TestS1mpleNumber2()
        {
            int testnumb = 7;
            bool res = true;
            CheckS1mpleNumber S = new CheckS1mpleNumber();
            Assert.AreEqual(S.checkSimpleNumber(testnumb), res, "Ожидаемый результат не получен.");
        }

        [TestMethod]
        public void TestS1mpleNumber3()
        {
            int testnumb = 112;
            bool res = false;
            CheckS1mpleNumber S = new CheckS1mpleNumber();
            Assert.AreEqual(S.checkSimpleNumber(testnumb), res, "Ожидаемый результат не получен.");
        }

        [TestMethod]
        public void TestS1mpleNumberInterval()
        {
            int numb1 = 2;
            int numb2 = 10;
            //string res = "2, 3, 5, 7.";
            int[] res = { 2, 3, 5, 8 };
            CheckS1mpleNumber S = new CheckS1mpleNumber();
            CollectionAssert.AreEquivalent(res, S.checkSimpleNumberInterval(numb1, numb2));
        }
    }
}
