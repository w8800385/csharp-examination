using ConsolCalculator.model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsolCalculator
{
    /// <summary>
    /// 乘法
    /// </summary>
    public class OperationDiv : IOperation
    {
        public double GetResult(CalculatorOperand calculatorOperand)
        {
            return calculatorOperand.NumberA * calculatorOperand.NumberB;
        }
    }
}
