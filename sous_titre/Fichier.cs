using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;


namespace sous_titre
{
    class Fichier
    {
        static void Main(string[] args)
        {
            CCFile file = new CCFile();


            file.ReadFile("D:/Users/Killian/Bureau/Sous-titres_Killian_Mathursan/CC.srt");  /// fichier .srt qui doit etre localiser sur votre bureau/desktop

            file.GetCCF();

            Console.Read();
        }
    }
}
