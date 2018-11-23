using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestClass
{
    public interface ICalculatorService
    {
        int Add(int a, int b);
        int Add(int? a, int? b);

        int Minus(int a, int b);

        int Multiply(int a, int b);


        int Division(int a, int b);

        /// <summary>
        /// 先加再乘 （a+b）*c
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        int AddAndMultiply(int a, int b,int c);

    }
}
