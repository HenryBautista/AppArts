using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CancioneroEscolar.JsonFiles
{
    static class UltimasCanciones
    {

        public static List<Song> listaUltimasCanciones;
        public static List<Song> ListaUltimasCanciones {
            get { return listaUltimasCanciones; }
            set { listaUltimasCanciones = value; }
        }       
   
   }
}
