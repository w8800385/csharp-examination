using ConsolCalculator.model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsolCalculator
{
    /// <summary>
    /// 除法
    /// </summary>
    public class OperationMul : IOperation
    {
        public double GetResult(CalculatorOperand calculatorOperand)
        {
            if (calculatorOperand.NumberB == 0)
            {
                throw new Exception("除数不能为0");
            }
            return calculatorOperand.NumberA / calculatorOperand.NumberB;
        }
    }
}
