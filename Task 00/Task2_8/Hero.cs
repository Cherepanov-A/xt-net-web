using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_8
{
    class Hero:Character
    {
        internal Hero()
        {
            Health = 10;
        }
        internal int Health
        {
            get => default(int);
            set
            {
            }
        }
        internal int Stat1 { get; set; }
        internal int Stat2 { get; set; }

        internal void HealsDown(Monster m)
        {
            if (m is Wolf)
            {
                Health--;
            }
            if (m is Bear)
            {
                Health -= 2;
            }
        }

        internal void Stats(PowerUp pw)
        {
            if (pw is Apple)
            {
                Stat1++;
                PowerCount(this, new PowerCountEventArgs(-1));
            }
            if (pw is Cherry)
            {
                Stat2++;
                PowerCount(this, new PowerCountEventArgs(-1));
            }
            
        }

        internal event PowerCountEventHandler PowerCount;

        
    }

    internal delegate void PowerCountEventHandler(object sender, PowerCountEventArgs args);
}
