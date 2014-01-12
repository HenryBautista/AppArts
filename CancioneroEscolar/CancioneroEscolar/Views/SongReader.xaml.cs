using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using CancioneroEscolar.JsonFiles;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace CancioneroEscolar.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SongReader : Page
    {
        Song getSong = null;
        public SongReader()
        {
            this.InitializeComponent();
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            getSong = e.Parameter as Song;
            GridViewLastSongs.ItemsSource= UltimasCanciones.ListaUltimasCanciones;
            LoadData(getSong);
        }

        void LoadData(Song song)
        {

            this.TextBlockNameSong.Text = song.SongName;
            List<Song> listaInutil = new List<Song>();
            listaInutil.Add(song);

            this.TextBlockSongLyrics.Text = song.SongLyric;
            this.TextBlockAuthor.Text = song.SongAuthors;
            this.FlipViewImagenCancion.ItemsSource = listaInutil;
            Song lastSong = new Song { SongAuthors = song.SongAuthors, SongImage = song.SongImage, SongLyric = song.SongLyric, SongName = song.SongName };
            bool sw = false;
            foreach(var repeatSong in UltimasCanciones.ListaUltimasCanciones){

                if (repeatSong.SongName.Equals(song.SongName))
                    sw = true;
            }

            if (!sw)
                UltimasCanciones.ListaUltimasCanciones.Add(song);
        }

        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }

        private void GridViewLastSongs_Tapped(object sender, TappedRoutedEventArgs e)
        {
            try
            {
               Song _objeto = null;

                if (GridViewLastSongs.SelectedItem != null)
                {
                    _objeto = (GridViewLastSongs.SelectedItem as Song);
                    Frame.Navigate(typeof(LastSongReaded), _objeto);

                }
            }
            catch (Exception ex)
            {
            }
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SongsCover));
        }
    }
}
