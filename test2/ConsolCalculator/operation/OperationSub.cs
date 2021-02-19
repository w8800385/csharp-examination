using ConsolCalculator.model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsolCalculator
{
    public class OperationSub : IOperation
    {
        public double GetResult(CalculatorOperand calculatorOperand)
        {
            return calculatorOperand.NumberA - calculatorOperand.NumberB;
        }
    }
}
