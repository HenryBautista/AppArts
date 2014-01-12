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
    public sealed partial class SongSelector : Page
    {
        List<Song> lastSongs = new List<Song>();

        Songs getSong = new Songs();
        public SongSelector()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            lastSongs=UltimasCanciones.ListaUltimasCanciones;
            getSong = e.Parameter as Songs;
            GridViewVistaPrincipal.ItemsSource = getSong.ListSongs;
            this.TextBlockTitulo.Text = getSong.TypeOfSongs;
            this.GridViewLastSongs.ItemsSource = lastSongs;
            
        }

        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SongsCover));
        }
        private void GridViewVistaPrincipal_Tapped(object sender, TappedRoutedEventArgs e)
        {
            try
            {
               
                Song _objeto = null;
          
                if (GridViewVistaPrincipal.SelectedItem != null)
                {
                    _objeto = (GridViewVistaPrincipal.SelectedItem as Song);
                    Frame.Navigate(typeof(SongReader), _objeto);
          

                }
                else
                {

                }
            }
            catch (Exception ex)
            {
            }

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
                else
                {

                }
            }
            catch (Exception ex)
            {
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SongsCover));
        }
       

    }
}
