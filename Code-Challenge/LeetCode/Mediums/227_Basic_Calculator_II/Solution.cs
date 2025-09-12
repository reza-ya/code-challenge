using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Code_Challenge.LeetCode.Mediums._227_Basic_Calculator_II
{
    public class Solution
    {
        public int Calculate(string s)
        {
            var resultNode = EvaluateExpression(s);
            var result = int.Parse(resultNode.Value);
            return result;
        }


        private Stack<Node> StringToStackNode(string str)
        {
            var resultStack = new Stack<Node>();
            int currentStartIndex = 0;
            int currentLenght = 0;
            for(int i = 0; i < str.Length; i++)
            {
                if (!IsOperator(str[i]))
                {
                    currentLenght += 1;
                    if (i == str.Length - 1)
                    {
                        var subStr = str.Substring(currentStartIndex, currentLenght);
                        resultStack.Push(new Node(false, subStr.Trim()));
                        break;
                    }
                    continue;
                }
                else
                {
                    var subStr = str.Substring(currentStartIndex, currentLenght);
                    resultStack.Push(new Node(false, subStr.Trim()));
                    currentStartIndex += currentLenght + 1;
                    currentLenght = 0;

                    resultStack.Push(new Node(true, str[i].ToString()));
                }
            }

            return resultStack;
        }

        private bool IsOperator(char c)
        {
            if (c == '/' || c == '*' || c == '+' || c == '-')
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private Node EvaluateExpression(string str)
        {
            Stack<Node> currentStack;
            currentStack = StringToStackNode(str);
            var nodeResult = EvaluateOperators(currentStack);
            return nodeResult;
            //var operatorList = new List<string>() { "/", "*", "-", "+" };
            //bool isReverse = true;
            //foreach (var optor in operatorList)
            //{
            //    if (isReverse == true)
            //    {
            //        var newStack = new Stack<Node>();
            //        while(currentStack.Count != 0)
            //        {
            //            newStack.Push(currentStack.Pop());
            //        }
            //        currentStack = newStack;
            //    }

            //    currentStack = InterperateByOperator(currentStack, optor);
            //}
            //var root = currentStack.Pop();


            //return root;

        }

        private Node EvaluateOperators(Stack<Node> stack)
        {
            var resultStack = new Stack<Node>();
            var sortedStack = new Stack<Node>();
            while (stack.Count != 0)
            {
                sortedStack.Push(stack.Pop());
            }
            while (sortedStack.Count != 0)
            {
                var currentNode = sortedStack.Pop();
                if (currentNode.IsOperator && currentNode.Value == "*")
                {
                    var leftOperand = resultStack.Pop();
                    var rightOperand = sortedStack.Pop();
                    var r = BinaryEvaluate(leftOperand.Value, rightOperand.Value, "*");
                    sortedStack.Push(new Node(false, r.ToString()));
                }
                else if (currentNode.IsOperator && currentNode.Value == "/")
                {
                    var leftOperand = resultStack.Pop();
                    var rightOperand = sortedStack.Pop();
                    var r = BinaryEvaluate(leftOperand.Value, rightOperand.Value, "/");
                    sortedStack.Push(new Node(false, r.ToString()));
                }
                else
                {
                    resultStack.Push(currentNode);
                }
            }

            while (resultStack.Count != 0)
            {
                sortedStack.Push(resultStack.Pop());
            }

            while (sortedStack.Count != 0)
            {
                var currentNode = sortedStack.Pop();
                if (currentNode.IsOperator && currentNode.Value == "+")
                {
                    var leftOperand = resultStack.Pop();
                    var rightOperand = sortedStack.Pop();
                    var r = BinaryEvaluate(leftOperand.Value, rightOperand.Value, "+");
                    sortedStack.Push(new Node(false, r.ToString()));
                }
                else if (currentNode.IsOperator && currentNode.Value == "-")
                {
                    var leftOperand = resultStack.Pop();
                    var rightOperand = sortedStack.Pop();
                    var r = BinaryEvaluate(leftOperand.Value, rightOperand.Value, "-");
                    sortedStack.Push(new Node(false, r.ToString()));
                }
                else
                {
                    resultStack.Push(currentNode);
                }
            }
            return resultStack.Pop();
        }

        private int BinaryEvaluate(string operand1, string operand2, string optor)
        {
            int intOperand1 = int.Parse(operand1);
            int intOperand2 = int.Parse(operand2);
            switch(optor)
            {
                case "/":
                    return intOperand1 / intOperand2;
                case "*":
                    return intOperand1 * intOperand2;
                case "+":
                    return intOperand1 + intOperand2;
                case "-":
                    return intOperand1 - intOperand2;
                default:
                    throw new Exception();
            }
        }

        private Stack<Node> InterperateByOperator(Stack<Node> stack, string optor)
        {
            var resultStack = new Stack<Node>();

            while(stack.Count != 0)
            {
                var currentNode = stack.Pop();
                if (currentNode.IsOperator && currentNode.Value == optor)
                {
                    var leftOperand = resultStack.Pop();
                    var rightOperand = stack.Pop();
                    var r = BinaryEvaluate(leftOperand.Value, rightOperand.Value, optor);
                    resultStack.Push(new Node(false, r.ToString()));
                }
                else
                {
                    resultStack.Push(currentNode);
                }
            }
            return resultStack;
        }
    }

    public class Node
    {
        public Node(bool isOperator, string value)
        {
            IsOperator = isOperator;
            Value = value;
        }
        public bool IsOperator { get; init; }
        public string Value { get; init; }
        public Node? Left { get; set; }
        public Node? Right { get; set; }
    }
}
