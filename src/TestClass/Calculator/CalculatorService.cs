using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestClass
{
    public class CalculatorService : ICalculatorService
    {
        public virtual string ServiceName { get; set; }

        private readonly ICalculator Calculator;

        public CalculatorService()
        {
        }

        public CalculatorService(ICalculator calculator)
        {
            Calculator = calculator;
        }

        public int Add(int a, int b)
        {
            return Calculator.Add(a, b);
        }

        public int Add(int? a, int? b)
        {
            if (a == null)
            {
                throw new ArgumentNullException(nameof(a));
            }
            if (b == null)
            {
                throw new ArgumentNullException(nameof(b));
            }
            return Calculator.Add((int)a,(int) b);
        }

        public virtual int AddAndMultiply(int a, int b, int c)
        {
            var r = Calculator.Add(a, b);
            return Calculator.Multiply(r,c); ;
        }

        public int Division(int a, int b)
        {
            if (b == 0)
            {
                throw new ArgumentException("除数不能为0！");
            }
            return Calculator.Division(a, b);
        }

        public int Minus(int a, int b)
        {
            return Calculator.Minus(a, b);
        }

        public int Multiply(int a, int b)
        {
            return Calculator.Multiply(a, b);
        }
    }
}
