using System;
using System.Collections.Generic;
using System.Text;

namespace ConsolCalculator.Factory
{
   public class OperationFactory
    {
        public static IOperation GetOperation(String opration)
        {
            IOperation operationCalculator =null ;
            switch (opration)
            {
                case "+":
                    operationCalculator = new OperationAdd();
                    break;
                case "-":
                    operationCalculator = new OperationSub();
                    break;
                case "*":
                    operationCalculator = new OperationDiv();
                    break;
                case "/":
                    operationCalculator = new OperationMul();
                    break;
                default:
                    break;
            }
            return operationCalculator;

        }
    }
}
