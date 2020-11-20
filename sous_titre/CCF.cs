using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Linq;

namespace sous_titre
{
    class CCF
    {
        public int CCnumbers;
        public TimeSpan debut;
        public TimeSpan fin;
        public string CC;

        public CCF(int number, string timer, string cc) /// modification de la variable, obtention de chaine de characteres 
        {
            CCnumbers = number;
            CC = cc;
            ParseTimer(timer);
        }
        private TimeSpan GetTimer(string timer) ///expression regulier qui permets de traiter le texte 
        {
            char[] charsplitOn = { ':', ',' };
            string[] splitTimer = timer.Split(charsplitOn);

            return new TimeSpan(0, Int32.Parse(splitTimer[0]), Int32.Parse(splitTimer[1]), Int32.Parse(splitTimer[2]), Int32.Parse(splitTimer[3]));
        }
        private void ParseTimer(string timer)
        {
            Regex lecture = new Regex(@"\d{2}:\d{2}:\d{1,2},\d{3} ?--> ?\d{2}:\d{2}:\d{1,2},\d{3}"); ///expression regulier qui permets de traiter le texte 

            if (lecture.IsMatch(timer))
            {
                string[] splitOn = { "-->", " --> " };
                string[] timerSplit = timer.Split(splitOn, StringSplitOptions.None);
                debut = GetTimer(timerSplit[0]);
                fin = GetTimer(timerSplit[1]);
            }
        }

        public async Task AddCC()
        {
            await TimeToAdd();
            Console.WriteLine(CC); ///affichage des sous-titres
            await TimeToDisplay();
            Console.Clear();
        }

        public async Task TimeToAdd()
        {
            await Task.Delay(debut);
        }

        public async Task TimeToDisplay()
        {
            await Task.Delay(fin - debut);
        }

        public async Task TimeToRemove()
        {
            await Task.Delay(fin);
        }

    }
}
