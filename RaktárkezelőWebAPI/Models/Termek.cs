using System;
using System.Collections.Generic;

namespace RaktárkezelőWebAPI.Models;

public partial class Termek
{
    public int TermekId { get; set; }

    public string Nev { get; set; } = null!;

    public int Ar { get; set; }

    public int BeszallitoId { get; set; }
}
