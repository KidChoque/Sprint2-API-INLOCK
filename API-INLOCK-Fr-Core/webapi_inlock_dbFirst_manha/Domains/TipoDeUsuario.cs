using System;
using System.Collections.Generic;

namespace webapi_inlock_dbFirst_manha.Domains;

public partial class TipoDeUsuario
{
    public Guid IdTipoDeUsuario { get; set; }

    public string Titulo { get; set; } = null!;

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
