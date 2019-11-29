using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_8
{
    class Hero : Character
    {
        public int Health { get; set; }
        public int Stat { get; set; }
        public override void Move()
        {
            base.Move();
        }
    }
}
