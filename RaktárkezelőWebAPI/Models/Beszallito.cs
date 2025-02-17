using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RaktárkezelőWebAPI.Models;

public partial class Beszallito
{
    [Key]
    public int BeszallitoId { get; set; }

    public string Nev { get; set; } = null!;
}
