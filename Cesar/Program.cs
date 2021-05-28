using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cesar
{
    class Program
    {
        static void Main(string[] args)
        {
            string choix = "3";

            while (choix != "0")
            {
                choix = afficheMenu();

                if (choix == "1")
                {
                    Console.WriteLine("Saisir le mot à chiffrer");
                    string mot = Console.ReadLine().ToUpper();
                    int cle = 0;
                    bool ok = true;
                    do
                    {
                        Console.WriteLine("Choisir une clé entre 1 et 25 (-1 pour une clé aléatoire)");
                        try
                        {
                            cle = int.Parse(Console.ReadLine());
                            if (cle != -1 && (cle <= 1 && cle >= 25)) ok = false;
                        }
                        catch
                        {
                            ok = false;
                        }
                    } while (!ok);

                    if(cle == -1)
                    {
                        Random rnd = new Random();
                        cle = rnd.Next(1, 26);
                    }
                    string motCrypte = chiffre(mot, cle);
                    Console.WriteLine(motCrypte +"\n");
                }

                if(choix == "2")
                {
                    Console.WriteLine("Saisir le mot à déchiffrer");
                    string motCrypte = Console.ReadLine().ToUpper();
                    Console.WriteLine("Voici toutes les possibilité :\n");
                    for (int decalage = 1; decalage < 26; decalage++)
                    {
                        string motDecrypte = dechiffre(motCrypte, decalage);                        
                        Console.WriteLine($"{motDecrypte} (Décalage de {decalage} lettre(s))");
                    }
                    Console.WriteLine("\n");
                }
            }
        }

        /// <summary>
        /// Affiche le menu des choix retourne le choix.
        /// </summary>
        static string afficheMenu()
        {
            Console.WriteLine("Chiffrer : 1");
            Console.WriteLine("Déchiffrer : 2");
            Console.WriteLine("Sortie : 0 \n");
            return Console.ReadLine();
        }


 

        /// <summary>
        /// Chiffre un mot par la cryptographie de César.
        /// </summary>
        /// <param name="mot"></param>
        /// <returns></returns>
        static string chiffre(string mot, int cle)
        {
            string motCrypte = "";
            foreach(char lettre in mot)
            {
                if (!isSpace(lettre))
                {
                    char lettreChiffree = boucleAlphabet((char)(lettre + cle));
                    motCrypte += (lettreChiffree);
                }
                else motCrypte += " ";
            }
            return motCrypte;
        }

        /// <summary>
        /// Dechiffre
        /// </summary>
        /// <param name="motCrypte"></param>
        /// <param name="decalage"></param>
        /// <returns></returns>
        static string dechiffre(string motCrypte, int decalage)
        {
            string motDecrypte = "";
            foreach (char lettre in motCrypte)
            {
                if (!isSpace(lettre))
                {
                    char nvelleLettre = boucleAlphabet((char)(lettre + decalage));
                    motDecrypte += nvelleLettre;
                }
                else motDecrypte += " ";
            }
            return motDecrypte;
        }

        /// <summary>
        /// Vérifie si un charactère donné est un espace.
        /// </summary>
        /// <param name="character">Charactère à vérifier.</param>
        /// <returns>True s'il s'agit d'un espace, false sinon.</returns>
        static bool isSpace(char character)
        {
            return (character == 32);
        }

        /// <summary>
        /// Si la lettre passée en paramètre dépasse les bornes de l'alphabet en majuscule, boucle au début de l'alphabet.
        /// </summary>
        /// <param name="lettre"></param>
        /// <returns>Une lettre correspondant à l'écart avec la fin de l'alphabet.</returns>
        /// <example>Le caractère "/" (92) est entré, il dépasse Z(90) de 2, le caractète B est retourné.</example>
        static char boucleAlphabet(char lettre)
        {
            char nvelleLettre = lettre;
            if (lettre > 90)
            {
                nvelleLettre = ((char)(65 - (91 - lettre)));
            }
            return nvelleLettre;
        }
    }
}
