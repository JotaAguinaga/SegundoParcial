using System;
using System.Collections.Generic;
using System.Text;

namespace AccesoDatos.Models
{
    public class Artista
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public List<Cancion> Canciones { get; set; } = new(); // un artista puede tener varias canciones pero canciones solo 1 artista
    }
}

