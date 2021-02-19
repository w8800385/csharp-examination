using ConsolCalculator.model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsolCalculator
{
    public class OperationAdd : IOperation
    {
         
        public double GetResult(CalculatorOperand calculatorOperand)
        {
            return calculatorOperand.NumberA + calculatorOperand.NumberB;
        }
    }
}
