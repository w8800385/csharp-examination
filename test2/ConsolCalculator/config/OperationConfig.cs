using System;
using System.Collections.Generic;
using System.Text;

namespace ConsolCalculator.config
{
    public static class OperationConfig
    {

        /// <summary>
        /// 
        /// </summary>
        public static Dictionary<string, int> dicPriority = new Dictionary<string, int>();

        static OperationConfig()
        {
            dicPriority.Add("+", 1);
            dicPriority.Add("-", 1);
            dicPriority.Add("*", 2);
            dicPriority.Add("/", 2);
            dicPriority.Add("(", 0);
            dicPriority.Add(")", 0);
        }

        /// <summary>
        /// 数字正则表达式
        /// </summary>
        public static string strRegNumber = @"^(\-|\+)?\d+(\.\d+)?$";

    }
}
