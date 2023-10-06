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
        /// <summary>
        ///     Table de rouleaus
        /// </summary>
        private Rouleau[] rouleaux = new Rouleau[3];
        #endregion

        #region ctor
        /// <summary>
        ///     Contructeur de la Class.
        ///     Génaire et ajoute 3 Objet Rouleau dans rouleaux.
        /// </summary>
        public SlotMachin()
        {
            rouleaux[0] = new Rouleau();
            rouleaux[1] = new Rouleau();
            rouleaux[2] = new Rouleau();
        }
        #endregion

        #region GS
        /// <summary>
        ///     Recupaire le symbole actuel des 3 rouleau de rouleaux
        /// </summary>
        /// <returns>retourne une table string</returns>
        public string[] GetCurrentRouleaus()
        {
            string[] r = { this.rouleaux[0].GetCurnentSymboles(), this.rouleaux[1].GetCurnentSymboles(), this.rouleaux[2].GetCurnentSymboles() }; 
            return r;
        }

        #endregion

        #region meth
        /// <summary>
        ///     Lance un tirage affiche resulta et compare les valeur du tirage.
        /// </summary>
        /// <returns>
        ///     un entier entre 0 et 2
        ///         0 : 0 symbole indentique
        ///         1 : 2 symbole indentique
        ///         2 : 3 symbole indentique
        /// </returns>
        public int Jouer()
        {
            //tirage
            string[] res =
            {
                rouleaux[0].RollAndGetSymbole(),
                rouleaux[1].RollAndGetSymbole(),
                rouleaux[2].RollAndGetSymbole()
            };
            //affichage
            Console.WriteLine($"|{res[0]}|{res[1]}|{res[2]}|");

            //comparaison
            if (res[0] == res[1] || res[0] == res[2] || res[1] == res[2])
            {
                if (res[0] == res[1] && res[1] == res[2]) { return 2; }
                else { return 1; }
            }
            else
            {
                return 0;
            }
        }
        
        #endregion

    }
}
