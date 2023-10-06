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
        /// <summary>
        ///     index du dernier symbole tirer
        /// </summary>
        private int numSymboles;
        private Random rnd = new Random();
        /// <summary>
        ///     List sympoles.
        /// </summary>
        private List<string> symboles = new List<string> { "P", "C", "R", "F", "M", "C", "*", "7" };
        #endregion
        #region constr
        public Rouleau()
        {
            this.numSymboles = 0;
        }
        #endregion
        #region SG
        /// <returns>retourne le symole correspondant index numSymboles</returns>
        public string GetCurnentSymboles()
        {
            return symboles[numSymboles];
        }
        /// <summary>
        ///     Lance un tirage de numSymboles
        /// </summary>
        /// <returns>retourne le symole correspondant index numSymboles</returns>
        public string RollAndGetSymbole()
        {
            Roll();
            return symboles[numSymboles];
        }
        #endregion
        #region meth
        /// <summary>
        ///     Change la valueur de numSymboles entre 0 et le nombre d'entre dans symboles -1 inclu
        /// </summary>
        private void Roll()
        {
            this.numSymboles = rnd.Next(this.symboles.Count);
        }
        #endregion
    }
}
