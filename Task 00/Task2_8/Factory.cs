using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task2_8
{
    internal class Factory
    {
        
        internal Character[] GetCharacters()
        {
            return new Character[]{new Hero(), new Bear(), new Wolf()};
        }

        internal GameItem[] GetItems()
        {
            return new GameItem[]{new Obstacle(), new Apple(), new Cherry()};
        }

    }
}