using System;

namespace Task4
{
    internal class Thr2EventArgs : EventArgs
    {
        public string Message { get; }
        public Thr2EventArgs(string m)
        {
            Message = m;
        }
    }
}
