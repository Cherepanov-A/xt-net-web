using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_8
{
    class Program
    {
        private static int _powUpCount = 5;
        static void Main(string[] args)
        {
            Factory fact = new Factory();
            GameField field = new GameField();
            field.Characters = fact.GetCharacters();
            field.GameItems = fact.GetItems();
            var hero = (Hero)field.Characters[0];
            hero.PowerCount += PwrCount;
            if (hero.Health<=0)
            {
                Console.WriteLine("GameOver");
            }
            if (_powUpCount<=0)
            {
                Console.WriteLine("Level comlete");
            }
        }

        private static void PwrCount(object sender, PowerCountEventArgs args)
        {
            _powUpCount += args.Count;
        }

       
    }
}
