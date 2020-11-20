using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Linq;

namespace sous_titre
{
    class CCFile
    {

        public enum StatusLine { NLine, TimerLine, STLine, EmptyLine }; /// ensemble de constantes 
        /// 
        /// </summary>
        public List<string> allLineOfFile;
        public List<CCF> allCCF;
        public string path;

        public CCFile()
        {
        }

        private void ParseFile()
        {
            int SS_nombres = 0;
            string SS_temps = "";
            string SS_titre = "";
            StatusLine ligne = StatusLine.NLine;
            allCCF = new List<CCF>();

            foreach (string Base in allLineOfFile) ///instruction qui va execute l'element des sous-titres avec la recuperation d'une chaine de characteres qui sont ici les sous-titres
            {
                if (Base == "")
                {
                    ligne = StatusLine.EmptyLine;
                }

                switch (ligne)
                {
                    case StatusLine.NLine:
                        SS_nombres = Int32.Parse(Base);
                        ligne++;
                        break;
                    case StatusLine.TimerLine:
                        SS_temps = Base;
                        ligne++;
                        break;
                    case StatusLine.STLine:
                        SS_titre += Base + "\n";
                        break;
                    case StatusLine.EmptyLine:
                        CCF CCs = new CCF(SS_nombres, SS_temps, SS_titre);
                        if (!allCCF.Contains(CCs))
                            allCCF.Add(CCs);
                        ligne = StatusLine.NLine;
                        SS_titre = "";
                        break;
                }
            }
            CCF CCfin = new CCF(SS_nombres, SS_temps, SS_titre);
            if (!allCCF.Contains(CCfin))
                allCCF.Add(CCfin);
        }


        public void ReadFile(string path) /// lecture du fichier en utilisant le chemin d'acces depuis le fichier program.cs
        {
            try
            {
                using (StreamReader fichier = new StreamReader(path))
                {
                    allLineOfFile = new List<string>();

                    string line;

                    while ((line = fichier.ReadLine()) != null)
                        allLineOfFile.Add(line);

                    ParseFile();

                }
            }
            catch (Exception erreur)
            {
                Console.WriteLine(erreur.Message);
            }
        }



        public void GetCCF() 
        {
            foreach (CCF sub in allCCF)
            {
                Task retour = sub.AddCC();
            }
        }

    }
}
