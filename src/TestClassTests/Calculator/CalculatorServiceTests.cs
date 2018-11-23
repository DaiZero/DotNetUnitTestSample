using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TestClass;

namespace TestClassTests
{
    [TestClass()]
    public class CalculatorServiceTests
    {
        private ICalculatorService calculatorService;

        public ICalculatorService CalculatorService
        {
            get { return calculatorService ?? (calculatorService = new CalculatorService(new Calculator())); }
            set { calculatorService = value; }
        }


        [TestMethod()]
        public void Add_Ok()
        {
            var i = 1;
            var j = 2;
            var expect = 3;
            var actval = CalculatorService.Add(1, 2);
            Assert.AreEqual(expect, actval);
        }


        [DataTestMethod()]
        [DataRow(0, 2)]
        [DataRow(3, 0)]
        [DataRow(5, 6)]
        public void Add_ManyTimes_Ok(int i, int j)
        {
            var expect = i + j;
            var actval = CalculatorService.Add(i, j);
            Assert.AreEqual(expect, actval);
        }

        [DataTestMethod()]
        [DataRow(1, 2)]
        [DataRow(5, 4)]
        [DataRow(5, 6)]
        public void Add_InNotNull_Ok(int? i, int? j)
        {
            var expect = i + j;
            var result = CalculatorService.Add(i, j);
            Assert.AreEqual(result, expect);
        }

        [DataTestMethod()]
        [DataRow(null, 2)]
        [DataRow(5, null)]
        [DataRow(null, null)]
        public void Add_InNull_ThrowArgmentNullExpection(int? i, int? j)
        {
            Action action = new Action(() => {
                CalculatorService.Add(i, j);
            });
            Assert.ThrowsException<ArgumentNullException>(action);
        }

        [DataTestMethod()]
        public void Division_DivisorIs0_ThrowArgumentExpection()
        {
            Action action = new Action(() => {
                CalculatorService.Division(6, 0);
            });
            Assert.ThrowsException<ArgumentException>(action);
        }

    }
}