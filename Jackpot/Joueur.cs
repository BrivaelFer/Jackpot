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
        public void Miser(int mise)
        {
            solde -= mise;
        }
        public void AddGain(int gain)
        {
            solde += gain;
        }
        #endregion
    }
}
