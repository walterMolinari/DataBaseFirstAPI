using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DataBaseFirstAPI.Models;

public partial class Album
{
    public int? AlbumId { get; set; }

    public string? Nombre { get; set; }

    public DateTime? Lanzamiento { get; set; }

    public int? ArtistaId { get; set; }
   
    public virtual Artista? Artista { get; set; }
}
