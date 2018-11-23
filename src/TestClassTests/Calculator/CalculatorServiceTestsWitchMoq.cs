using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using TestClass;

namespace TestClassTests
{
    [TestClass()]
    public class CalculatorServiceTestsWitchMoq
    {
        [TestMethod]
        public void AddAndMp()
        {
            var mockCalculator = new Mock<ICalculator>();
            //mockCalculator.Setup(x => x.Add(1, 2)).Returns(4);
            mockCalculator.Setup(x => x.Add(It.IsAny<int>(), It.IsAny<int>())).Returns(4);
            //mockCalculator.Verify(x => x.Add(1, 2), Times.AtMostOnce());
            var actval = mockCalculator.Object.Add(5, 2);
            actval.Should().Be(4);

        }

        [TestMethod]
        public void Add_InNull_ThrowArgmentNullExpection()
        {
            var mockCalculatorService = new Mock<ICalculatorService>();
            mockCalculatorService.Setup(x => x.Add(null, It.IsAny<int>())).Throws<ArgumentNullException>();
            var action = new Action(() =>
            {
                mockCalculatorService.Object.Add(null, 2);
            });
            action.Should().Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void AddAndMultiply_Mock()
        {
            var expect = 5;
            var mockCalculatorService = new Mock<CalculatorService>();
            mockCalculatorService.Setup(x => x.AddAndMultiply(1, 2, 3)).Returns(expect);
            var actval = mockCalculatorService.Object.AddAndMultiply(1, 2, 3);
            actval.Should().Be(expect);
        }

        [TestMethod]
        public void ServiceName()
        {
            var expectname = "Hellow";
            var mockCalculatorService = new Mock<CalculatorService>();
            mockCalculatorService.Setup(x => x.ServiceName).Returns(expectname);
            var actname = mockCalculatorService.Object.ServiceName;
            actname.Should().Be(expectname);
        }
    }
}
