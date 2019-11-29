using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_8
{
    internal abstract class Character
    {
        public int X { get; set; }
        public int Y { get; set; }
        public virtual void Move(/*game fiel borders*/) { }
    }
}
