using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task2_8
{
    public abstract class Monster : Character
    {
        public void Resolve(GameItem gi)
        {
            if (gi is Obstacle)
            {
                throw new NotImplementedException();
            }
        }
    }
}