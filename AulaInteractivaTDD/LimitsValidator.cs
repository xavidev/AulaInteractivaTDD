using System;
namespace AulaInteractivaTDD
{
    public interface LimitsValidator
    {
        void ValidateArgs(int arg1, int arg2);
        void SetLimits(int lower, int upper);
    }
}
