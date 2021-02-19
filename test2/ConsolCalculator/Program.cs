using ConsolCalculator.config;
using ConsolCalculator.Factory;
using ConsolCalculator.model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace ConsolCalculator
{
    public class Program
    {
        static void Main(string[] args)
        {
            //string argsStr = "input1.txt";
            if (args.Length > 0)
            {
                string strPath = args[0];
                string strExpress = GetOprationStr(strPath);
                List<string> listInfos = StrToInfixExpressionList(strExpress);
                List<string> parseSuff = GetPostfixList(listInfos);
                double result = Calculate(parseSuff);
                Console.WriteLine(result);
            }

        }

        /// <summary>
        /// 读取文件地址，获取表达式
        /// </summary>
        /// <param name="strPath"></param>
        /// <returns></returns>
        public static string GetOprationStr(string strPath)
        {
            string express = "";
            FileStream fileStream = new FileStream(strPath, FileMode.Open);
            using (StreamReader reader = new StreamReader(fileStream))
            {
                string inputTxt = reader.ReadToEnd();
                if (inputTxt.Length > 0)
                {
                    string[] arrayInputText = inputTxt.Split("\n");
                    int i = 0;
                    express = arrayInputText[0].Replace("\r", "");
                    foreach (var strRow in arrayInputText)
                    {
                        if (i > 0)
                        {
                            string[] splitRow = strRow.Replace("\r", "").Split("=");
                            if (splitRow.Length >= 1)
                            {
                                string oprationName = splitRow[0];
                                string oprationValue = splitRow[1];

                                express = express.Replace(oprationName, oprationValue);
                            }
                        }
                        i++;
                    }
                }
            }
            return express;
        }
        /// <summary>
        /// 中缀转后缀
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static List<string> GetPostfixList(List<string> oprationList)
        {

            List<string> listResult = new List<string>();
            Stack<string> statckOperation = new Stack<string>();

            foreach (var item in oprationList)
            {
                if (Regex.IsMatch(item, OperationConfig.strRegNumber))
                {
                    listResult.Add(item);
                }
                //如果是左括号，直接入符号栈
                else if (item.Equals("("))
                {
                    statckOperation.Push(item);
                }
                //如果是右括号
                else if (item.Equals(")"))
                {
                    while (!statckOperation.Peek().Equals("("))
                    {
                        listResult.Add(statckOperation.Pop());
                    }
                    statckOperation.Pop();
                }
                else //如果是操作符，要判断优先级
                {
                    while (statckOperation.Count != 0 && OperationConfig.dicPriority[statckOperation.Peek()] >= OperationConfig.dicPriority[item])
                    {
                        listResult.Add(statckOperation.Pop());
                    }
                    statckOperation.Push(item);
                }
            }

            while (statckOperation.Count != 0)
            {
                listResult.Add(statckOperation.Pop());
            }

            return listResult;
        }

        /// <summary>
        /// 根据字符串或者list
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static List<string> StrToInfixExpressionList(string oprationStr)
        {
            List<string> oprationList = new List<string>();
            int index = 0;
            string str = "";
            do
            {
                //如果不是0到9的数字以及小数点，则直接存入list
                if ((oprationStr[index] < 48 || oprationStr[index] > 57) && oprationStr[index] != '.')//ascii编码
                {
                    oprationList.Add("" + oprationStr[index]);

                    index++;
                }
                else
                {
                    str = "";

                    //是数字或者小数点，尧加起来放入list
                    while (index < oprationStr.Length && ((oprationStr[index] >= 48 && oprationStr[index] <= 57) || oprationStr[index] == '.'))
                    {

                        str += oprationStr[index];

                        index++;
                    }

                    oprationList.Add(str);
                }

            } while (index < oprationStr.Length);

            return oprationList;
        }


        /// <summary>
        /// 计算
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static double Calculate(List<string> list)
        {
            //创建栈
            Stack<string> stack = new Stack<string>();
            //循环遍历
            list.ForEach(item =>
            {
                //正则表达式判断是否是数字，匹配的是多位数
                if (Regex.IsMatch(item, OperationConfig.strRegNumber))
                {
                    //如果是数字直接入栈
                    stack.Push(item);
                }
                //如果是操作符
                else
                {
                    CalculatorOperand calculatorOperand = new CalculatorOperand();
                    calculatorOperand.NumberB = double.Parse(stack.Pop());
                    calculatorOperand.NumberA = double.Parse(stack.Pop());
                    double result = OperationFactory.GetOperation(item).GetResult(calculatorOperand);
                    stack.Push("" + result);
                }
            });

            //最后把stack中数据返回
            return double.Parse(stack.Pop());
        }

    }
}
