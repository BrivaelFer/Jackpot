using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Jackpot
{
    public class Party
    {
        #region att
        private List<Joueur> joueurs = new List<Joueur>();
        private SlotMachin machin = new SlotMachin();
        #endregion

        #region ctor
        public Party()
        {
            Console.Write("Entrez le nombre de joueurs :");
            int nj = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < nj; i++)
            {
                Console.Write($"Entrez le nom du joueur{i + 1} : ");
                string nameJ = Console.ReadLine();
                joueurs.Add(new Joueur(nameJ));
            }
        }
        #endregion

        #region meth
        private void Play()
        {
            bool continueGame = true;
            int tourn = 0;

            while(continueGame)
            {
                tourn++;
                Console.WriteLine($"Début tour {tourn} :");
                if(joueurs.Count == 0)
                    continueGame = false;
                else
                {
                    foreach (Joueur joueur in joueurs)
                    {
                        Console.WriteLine($"\rTour {joueur.GetNom()}");
                        Console.Write($"\r\r{joueur.GetNom()}" +
                            $"\n\r\rSolde : {joueur.GetSolde()} " +
                            $"\n\r\rentrez votre mise : ");
                        string m = Console.ReadLine();
                        this.PlayerUserMachin(joueur, Convert.ToInt32(m));
                    }
                }
            }
        }
        private void PlayerUserMachin(Joueur joueur, int mise)
        {
            int rm = machin.Jouer();
            joueur.Miser(mise);
            if(rm == 1)
            {
                int g = Convert.ToInt32(mise * 1.5);
                joueur.AddGain(g);
                Console.WriteLine($"{joueur.GetNom} gagne {g}");
                
            }
            else if(rm == 2)
            {
                int g = Convert.ToInt32(mise * 2);
                joueur.AddGain(g);
                Console.WriteLine($"{joueur.GetNom} gagne {g}");
            }
            else 
            { 
                Console.WriteLine($"{joueur.GetNom} à predu !"); 
            }
        }
        #endregion

    }
}
