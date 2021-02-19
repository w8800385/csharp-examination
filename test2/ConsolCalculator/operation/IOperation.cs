using ConsolCalculator.model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsolCalculator
{
   public interface IOperation
    {
        /// <summary>
        /// 获取结果
        /// </summary>
        /// <returns></returns>
        double GetResult(CalculatorOperand calculatorOperand);
    }
}
