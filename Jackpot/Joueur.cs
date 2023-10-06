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
        public void AddGain(int gain)
        {
            solde += gain;
        }
        #endregion
    }
}
