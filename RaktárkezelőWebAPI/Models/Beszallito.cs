using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RaktárkezelőWebAPI.Models;

public partial class Beszallito
{
    public int BeszallitoId { get; set; }

    public string Nev { get; set; } = null!;
    
    public virtual ICollection<Termek> Termeks { get; set; } = new List<Termek>();
}
