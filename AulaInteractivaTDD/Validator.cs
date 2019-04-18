using System;
namespace AulaInteractivaTDD
{
    public class Validator : LimitsValidator
    {
        private int upperLimit;
        private int lowerLimit;

        public Validator(int lowerLimit, int upperLimit)
        {
            SetLimits(lowerLimit, upperLimit);
        }

        public int LowerLimit
        {
            get { return lowerLimit; }
            set { lowerLimit = value; }
        }

        public int UpperLimit
        {
            get { return upperLimit; }
            set { upperLimit = value; }
        }


        public void ValidateArgs(int v1, int v2)
        {
            this.breakIfOverflow(v1, "First argument exceeds limits");
            this.breakIfOverflow(v2, "Second argument exceeds limits");
        }

        private void breakIfOverflow(int arg, string msg)
        {
            if (ValueExceedLimits(arg))
                throw new OverflowException(msg);
        }

        public bool ValueExceedLimits (int arg)
        {
            if (arg > upperLimit)
            {
                return true;
            }
                
            if (arg < lowerLimit)
            {
                return true;
            }

            return false;
        }

        public void SetLimits(int lower, int upper)
        {
            this.lowerLimit = lower;
            this.upperLimit = upper;
        }

        public void ValidateResult(int result)
        {
            this.breakIfOverflow(result, "Result exceeds limits");
        }
    }
}
