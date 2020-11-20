using System;
using System.Windows;
using System.Windows.Threading;

namespace Sous_titres_Killian_Mathursan
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow() //Fonction de la fenêtre de lecture 
		{
            DispatcherTimer timer = new DispatcherTimer //Création du timer
			{
                Interval = TimeSpan.FromSeconds(1)    //Intervalle de comptabilité du timer
			};
            timer.Tick += Timer_Tick;
			timer.Start();  //Lancement du timer
		}

        void Timer_Tick(object sender, EventArgs e)  //Fonction du compteur de minute:secondes affiché sur l'écran
		{
			if (LecteurVideo.Source != null)  //Condition qui définit si la vidéo existe ou non
			{
				if (LecteurVideo.NaturalDuration.HasTimeSpan)
					lblStatus.Content = String.Format("{0} / {1}", LecteurVideo.Position.ToString(@"mm\:ss"), LecteurVideo.NaturalDuration.TimeSpan.ToString(@"mm\:ss"));  //Initialisation du lecteur vidéo ainsi que de son contenu
			}
			else
				lblStatus.Content = "No file selected...";  //Affichage d'un texte en cas d'erreur
		}

		private void BtnPlay_Click(object sender, RoutedEventArgs e)  //Fonction avec l'ajout du bouton Play
		{
			LecteurVideo.Play();
		}

		private void BtnPause_Click(object sender, RoutedEventArgs e) //Fonction avec l'ajout du bouton Pause
		{
			LecteurVideo.Pause();
		}

		private void BtnStop_Click(object sender, RoutedEventArgs e) //Fonction avec l'ajout du bouton Stop
		{
			LecteurVideo.Stop();
		}
	}
}