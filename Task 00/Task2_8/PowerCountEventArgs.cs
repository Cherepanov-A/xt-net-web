using System;

namespace Task2_8
{
    internal class PowerCountEventArgs : EventArgs
    {
        internal PowerCountEventArgs(int c)
        {
            Count = c;
        }
        public int Count { get; set; }
    }
}
