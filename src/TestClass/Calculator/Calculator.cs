using System;

namespace TestClass
{
    public class Calculator : ICalculator
    {

        public int Add(int a, int b)
        {
            return a + b;
        }

        public int Division(int a, int b)
        {
            if (b == 0)
            {
                throw new ArgumentException("除数不能为0！");
            }
            return a / b;
        }

        public int Minus(int a, int b)
        {
            return a - b;
        }

        public int Multiply(int a, int b)
        {
            return a * b;
        }
    }
}
