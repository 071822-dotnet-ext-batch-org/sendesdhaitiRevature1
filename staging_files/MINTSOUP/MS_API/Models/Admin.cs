using System;
using System.Collections.Generic;

namespace MS_API.Models;

public partial class Admin
{
    public Guid Id { get; set; }

    public Guid? FkMstoken { get; set; }

    public string Email { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string Adminstatus { get; set; } = null!;

    public DateTime Datecreated { get; set; }

    public DateTime Lastsignedin { get; set; }

    public virtual Mintsouptoken? FkMstokenNavigation { get; set; }
}
