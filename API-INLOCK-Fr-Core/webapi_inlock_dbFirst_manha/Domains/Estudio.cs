using System;
using System.Collections.Generic;

namespace webapi_inlock_dbFirst_manha.Domains;

public partial class Estudio
{
    public Guid IdEstudio { get; set; }

    public string? Nome { get; set; }

    public virtual ICollection<Jogo> Jogos { get; set; } = new List<Jogo>();
}
