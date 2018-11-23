using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TestClass;

namespace TestClassTests
{
    [TestClass()]
    public class CalculatorServiceTestsWitchFluent
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
            actval.Should().Be(expect);
            //Assert.AreEqual(expect, actval);
        }


        [DataTestMethod()]
        [DataRow(0, 2)]
        [DataRow(3, 0)]
        [DataRow(5, 6)]
        public void Add_ManyTimes_Ok(int i, int j)
        {
            var expect = i + j;
            var actval = CalculatorService.Add(i, j);
            actval.Should().Be(expect);
            //Assert.AreEqual(expect, actval);
        }

        [TestMethod()]
        public void Multiply_InHas0_Out0()
        {
            var actval1 = CalculatorService.Multiply(0, 5);
            var actval2 = CalculatorService.Multiply(5,0);
            var actval3 = CalculatorService.Multiply(0, 0);
            actval1.Should().Be(actval2).And.Be(actval3).And.Be(0);
            //Assert.IsTrue(actval1==actval2&& actval1 == actval3&& actval1==0);
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
            action.Should().Throw<ArgumentNullException>();
            //Assert.ThrowsException<ArgumentNullException>(action);
        }

        [DataTestMethod()]
        public void Division_DivisorIs0_ThrowArgumentExpection()
        {
            Action action = new Action(() => {
                CalculatorService.Division(6, 0);
            });
            action.Should().Throw<ArgumentException>().WithMessage("除数不能为0！");
        }
    }
}
