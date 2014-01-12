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
using Newtonsoft.Json;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace CancioneroEscolar.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SongsCover : Page
    {

       Songs ListOfSongs = new Songs();
       Songs ListOfSongsCantos = new Songs();
       Songs ListOfSongsExtras = new Songs();
        public SongsCover()
        {
            this.InitializeComponent();
        }

  

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            var folder = Windows.ApplicationModel.Package.Current.InstalledLocation;
            folder = await folder.GetFolderAsync("JsonFiles");
            var file = await folder.GetFileAsync("Songs.json");
            var json = await Windows.Storage.FileIO.ReadTextAsync(file);

            var Songs = JsonConvert.DeserializeObject<Songs>(json);
              this.ListOfSongs = Songs;

              var fileCantos = await folder.GetFileAsync("Songs2.json");
              var jsonCantos = await Windows.Storage.FileIO.ReadTextAsync(fileCantos);

              var SongsCantos = JsonConvert.DeserializeObject<Songs>(jsonCantos);
              this.ListOfSongsCantos = SongsCantos;


              var fileExtras = await folder.GetFileAsync("Extras.json");
              var jsonExtras = await Windows.Storage.FileIO.ReadTextAsync(fileExtras);

              var SongsExtras = JsonConvert.DeserializeObject<Songs>(jsonExtras);
              this.ListOfSongsExtras = SongsExtras;
         




            var folderCover = Windows.ApplicationModel.Package.Current.InstalledLocation;
            folderCover = await folderCover.GetFolderAsync("JsonFiles");
            var fileCover = await folderCover.GetFileAsync("SongsCover.json");
            var jsonCover = await Windows.Storage.FileIO.ReadTextAsync(fileCover);
           
            var covers = JsonConvert.DeserializeObject<Covers>(jsonCover);
            List<Cover> ListOfCover = new List<Cover>();
            ListOfCover = (covers as Covers).ListCovers;
            
            FlipViewImage.ItemsSource = ListOfCover;

            this.GridViewLastSongs.ItemsSource = UltimasCanciones.ListaUltimasCanciones;

            base.OnNavigatedTo(e);
        }


        private void Image_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            try
            {
                Cover coverSong = null;
                if (FlipViewImage.SelectedItem != null)
                {
                    coverSong = (FlipViewImage.SelectedItem as Cover);
                    string tipoCancion=coverSong.Title;

                    switch (tipoCancion)
                    {

                        case "Himnos de Bolivia":
                            Frame.Navigate(typeof(SongSelector), ListOfSongs);
                            break;
                        case "Cantos de Bolivia":
                            Frame.Navigate(typeof(SongSelector), ListOfSongsCantos);
                            break;
                        case"Extras":
                            Frame.Navigate(typeof(SongSelector), ListOfSongsExtras);
                            break;
                        default:
                            break;
                    }
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
                    Frame.Navigate(typeof(LastSongReaded),_objeto);

                }
                
            }
            catch (Exception ex)
            {
            }
           
        }
    }
}
