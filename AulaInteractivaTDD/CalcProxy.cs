using System;
using System.Reflection;
namespace AulaInteractivaTDD
{
    public class CalcProxy
    {
        private Calculator calculator;
        private Validator validator;

        public delegate int SingleBinaryOperation(int a, int b);

        public CalcProxy(Calculator calculator)
        {
            this.calculator = calculator;
        }

        public CalcProxy (Validator validator, Calculator calculator)
        {
            this.calculator = calculator;
            this.validator = validator;
        }

        public int BinaryOperation(
            SingleBinaryOperation operation,
            int arg1, int arg2)
        {
            validator.ValidateArgs(arg1, arg2);

            int result = 0;
            MethodInfo[] calculatorMethods =
                calculator.GetType().GetMethods(BindingFlags.Public |
                                                BindingFlags.Instance);
            foreach (MethodInfo method in calculatorMethods)
            {
                if(method == operation.Method)
                {
                    result = (int)method.Invoke(
                        calculator, new Object[] { arg1, arg2 });
                }
            }

            validator.ValidateResult(result);
            return result;
        }
    }
}
