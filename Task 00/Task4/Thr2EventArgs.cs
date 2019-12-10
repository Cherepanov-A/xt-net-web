using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
