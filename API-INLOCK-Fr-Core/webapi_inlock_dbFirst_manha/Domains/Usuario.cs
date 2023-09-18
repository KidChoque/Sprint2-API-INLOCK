using System;
using System.Collections.Generic;

namespace webapi_inlock_dbFirst_manha.Domains;

public partial class Usuario
{
    public Guid IdUsuario { get; set; }

    public Guid? IdTipoDeUsuario { get; set; }

    public string? Email { get; set; }

    public string? Senha { get; set; }

    public virtual TipoDeUsuario? IdTipoDeUsuarioNavigation { get; set; }
}
