using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jackpot
{
    public class Joueur
    {
        #region att
        private string nom;
        private int solde;
        #endregion

        #region const
        /// <summary>
        /// Contruteur de la Class Joueur 
        /// Set les attribu nom et solde
        /// </summary>
        /// <param name="nom">nom du joueur</param>
        /// <param name="solde">valeur de la solde, valeur 100 si non rensaigné</param>
        public Joueur(string nom, int solde = 100)
        {
            this.nom = nom;
            this.solde = solde;
        }
        #endregion

        #region SG
        public string GetNom() { return nom; }
        public int GetSolde() {  return solde; }
        #endregion

        #region Meth
        /// <summary>
        /// Vérifi que la mise n'est pas supérieur la solde du joueur.
        /// Si mise trop haute donne à la mise la valeur de la solde.
        /// 
        /// Retire la valeur de la mise de la solde du joueur.
        /// </summary>
        /// <param name="mise"></param>
        /// <returns>retourn la valeur final de la mise</returns>
        public int Miser(int mise)
        {
            if(solde - mise < 0)
            {
                mise = solde;
                Console.WriteLine($"Solde insufisante.\n La mise est niveau de la solde({solde})");
            }
            solde -= mise;
            return mise;
        }
        /// <summary>
        /// Ajout gain à la mise
        /// </summary>
        /// <param name="gain"></param>
        public void AddGain(int gain)
        {
            solde += gain;
        }
        #endregion
    }
}
