namespace LostRPG_MonoGame.Controllers
{
    using System;

    public class NumericKeyEventArgs : EventArgs
    {
        public NumericKeyEventArgs(string numericValue)
        {
            this.NumericValue = numericValue;
        }

        public string NumericValue { get; }
    }
}
