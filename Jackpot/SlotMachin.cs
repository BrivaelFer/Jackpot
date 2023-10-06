using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jackpot
{
    internal class SlotMachin
    {
        #region att
        private Rouleau[] rouleaus = new Rouleau[3];
        #endregion

        #region ctor
        public SlotMachin()
        {
            rouleaus[0] = new Rouleau();
            rouleaus[1] = new Rouleau();
            rouleaus[2] = new Rouleau();
        }
        #endregion

        #region GS
        public string[] GetCurrentRouleaus()
        {
            string[] r = { this.rouleaus[0].GetCurnentSymboles(), this.rouleaus[1].GetCurnentSymboles(), this.rouleaus[2].GetCurnentSymboles() }; 
            return r;
        }
        
        #endregion

        #region meth
        public int Jouer()
        {
            string[] res =
            {
                rouleaus[0].RollAndGetSymbole(),
                rouleaus[1].RollAndGetSymbole(),
                rouleaus[2].RollAndGetSymbole()
            };
            Console.WriteLine($"|{res[0]}|{res[1]}|{res[2]}|");

            if (res[0] == res[1])
            {
                if (res[2] == res[3])
                {
                    return 2;
                }
                else
                {
                    return 1;
                }
            }
            else
            {
                return 0;
            }
        }
        
        #endregion

    }
}
