using System;

namespace LostRPG_MonoGame.Models.Controllers
{
    public class NumericKeyEventArgs : EventArgs
    {
        public NumericKeyEventArgs(string numericValue)
        {
            this.NumericValue = numericValue;
        }

        public string NumericValue { get; }
    }
}
