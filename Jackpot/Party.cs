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
        /// <summary>
        /// List des joueurs
        /// </summary>
        private List<Joueur> joueurs = new List<Joueur>();
        private SlotMachin machin = new SlotMachin();
        #endregion

        #region ctor
        public Party()
        {
            int nj;
            while (true)
            {
                try
                {
                    Console.Write("Entrez le nombre de joueurs :");
                    nj = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch 
                {
                    Console.WriteLine("Vous devez entre un nombre entier > 0.");
                }
            }
            for (int i = 0; i < nj; i++)
            {
                while (true)
                {
                    Console.Write($"Entrez le nom du joueur{i + 1} : ");
                    string nameJ = Console.ReadLine();
                    if(nameJ != ""  && !JoueurExist(nameJ))
                    {
                        joueurs.Add(new Joueur(nameJ));
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Vous devez au moins un caractère");
                    }
                }
                
            }
            Play();
        }
        #endregion

        #region meth
        /// <summary>
        /// Gère le déroulé de la parti
        /// </summary>
        private void Play()
        {
            bool continueGame = true;
            int tourn = 0;

            //Tour tous les joueurs
            while(continueGame)
            {
                tourn++;
                //Elimine les joueurs
                RemoveJoueur();

                //Vérifi si il reste au moins 1 joueur
                if (joueurs.Count <= 0)
                {
                    //passe la condition de la bouble à false
                    continueGame = false;
                }
                else
                {
                    Console.WriteLine($"Début tour {tourn} :");
                    //Tour de chaque joueur
                    foreach (Joueur joueur in joueurs)
                    {
                        Console.WriteLine($"\tTour {joueur.GetNom()}");
                        Console.WriteLine($"\t\t{joueur.GetNom()}" +
                            $"\n\t\tSolde : {joueur.GetSolde()}");

                        while(true)
                        {
                            try
                            {
                                Console.Write($"\t\tentrez votre mise : ");
                                //Demande une mise au joueur
                                string m = Console.ReadLine();
                                //Utilise la machine
                                this.PlayerUserMachin(joueur, Convert.ToInt32(m));
                                break;
                            }
                            catch
                            {
                                Console.WriteLine("Vous devez entrer un nombre entrier.");
                            }
                        }
                       
                        
                    }
                }
            }
        }
        /// <summary>
        /// Gérer une mise et un tirage
        /// </summary>
        /// <param name="joueur">Objet Joueur effectuent un tirage</param>
        /// <param name="mise">Quantiter</param>
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
        /// <summary>
        /// Supprime de joueurs le joueur dont le est tomber à 0 ou en dessous.
        /// </summary>
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
        /// <summary>
        ///     Vérifi si un nom de joueur est déjà utiliser dans un joueurs de la list joueurs 
        /// </summary>
        /// <param name="nom">Nom a donné aux joueur</param>
        /// <returns>
        ///     True : nom déja utiliser
        ///     False : nom non utiliser
        /// </returns>
        private bool JoueurExist(string nom)
        {
            foreach (Joueur j in joueurs)
            {
                if (j.GetNom() == nom)
                    return true;
            }
            return false;
        }
        #endregion

    }
}