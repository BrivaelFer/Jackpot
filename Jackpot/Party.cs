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
            Play();
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

                RemoveJoueur();

                if (joueurs.Count == 0)
                    continueGame = false;
                else
                {
                    Console.WriteLine($"Début tour {tourn} :");
                    foreach (Joueur joueur in joueurs)
                    {
                        Console.WriteLine($"\tTour {joueur.GetNom()}");
                        Console.Write($"\t\t{joueur.GetNom()}" +
                            $"\n\t\tSolde : {joueur.GetSolde()} " +
                            $"\n\t\tentrez votre mise : ");
                        string m = Console.ReadLine();
                        this.PlayerUserMachin(joueur, Convert.ToInt32(m));
                        
                    }
                }
            }
        }
        private void PlayerUserMachin(Joueur joueur, int mise)
        {
            int rm = machin.Jouer();
            mise = joueur.Miser(mise);
            if(rm == 1)
            {
                int g = Convert.ToInt32(mise * 1.5);
                joueur.AddGain(g);
                Console.WriteLine($"{joueur.GetNom()} gagne {g}");
                
            }
            else if(rm == 2)
            {
                int g = Convert.ToInt32(mise * 2);
                joueur.AddGain(g);
                Console.WriteLine($"{joueur.GetNom()} gagne {g}");
            }
            else 
            { 
                Console.WriteLine($"{joueur.GetNom()} à predu !"); 
            }
        }

        private void RemoveJoueur()
        {
            List<Joueur> rm = new List<Joueur>();
            foreach (var j in joueurs)
            {
                if (j.GetSolde() <= 0)
                {
                    rm.Add(j);
                }
            }
            foreach (var j in rm)
            {
                Console.WriteLine($"Le joueur {j.GetNom()} est perdu tout solde.\n" +
                    "Il est donc éliminer.");
                joueurs.Remove(j);
            }
        }
        #endregion

    }
}
