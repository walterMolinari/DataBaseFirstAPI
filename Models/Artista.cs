using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DataBaseFirstAPI.Models;

public partial class Artista
{
    public int ArtistaId { get; set; }

    public string? Nombre { get; set; }
    [JsonIgnore]
    public virtual ICollection<Album> Albums { get; } = new List<Album>();
}
