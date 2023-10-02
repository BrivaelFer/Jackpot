using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jackpot
{
    internal class Rouleau
    {
        #region att
        private int numSymboles;
        private Random rnd = new Random();
        private List<string> symboles = new List<string> { "🍎", "🍒", "🍇", "🍋", "🍉", "🔔", "⭐", "7️⃣" };
        #endregion
        #region constr
        public Rouleau()
        {
            this.numSymboles = 0;
        }
        #endregion
        #region SG
        public string GetCurnentSymboles()
        {
            return symboles[numSymboles];
        }
        public string RollAndGetSymbole()
        {
            Roll();
            return symboles[numSymboles];
        }
        #endregion
        #region meth
        private void Roll()
        {
            this.numSymboles = rnd.Next(this.symboles.Count);
        }
        #endregion
    }
}
