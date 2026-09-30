using System;
using System.Collections.Generic;
using System.Text;

namespace AccesoDatos.Models
{
    public class Cancion
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public int DuracionSeg { get; set; }
        public int ArtistaId { get; set; } // clave foranea
        public Artista Artista { get; set; } // navegacion entre clases
    }
}
