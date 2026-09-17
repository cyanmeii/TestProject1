using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class AllFeaturesTest
    {
        private List<string> _testList;

        [TestInitialize]
        public void Setup()
        {
            _testList = new List<string> { "apple", "banana" };
        }

        [TestCleanup]
        public void Cleanup()
        {
            _testList = null;
        }

        [DataTestMethod]
        [DataRow(2, 3, 5)]
        [DataRow(10, -5, 5)]
        [DataRow(0, 0, 0)]
        public void Add_Numbers_ReturnsCorrectSum(int a, int b, int expected)
        {
            Assert.AreEqual(expected, a + b);
        }

        [TestMethod]
        public void CheckObjectReferencesAndTypes()
        {
            List<string> sameList = _testList;

            Assert.AreSame(_testList, sameList);
            Assert.IsInstanceOfType(_testList, typeof(List<string>));
        }

        [TestMethod]
        public void CheckNullAndBoolean()
        {
            string nullString = null;
            bool isTrue = true;

            Assert.IsNull(nullString);
            Assert.IsTrue(isTrue);
        }

        [TestMethod]
        public void CheckException()
        {
            DivideByZeroException ex = Assert.Throws<DivideByZeroException>(() =>
            {
                int x = 10;
                int y = 0;
                int result = x / y;
            });
        }
    }
}