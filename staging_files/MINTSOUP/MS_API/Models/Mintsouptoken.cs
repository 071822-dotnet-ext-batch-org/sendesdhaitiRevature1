using System;
using System.Collections.Generic;

namespace MS_API.Models;

public partial class Mintsouptoken
{
    public Guid Id { get; set; }

    public string Email { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string PasswordSalt { get; set; } = null!;

    public DateTime Datesignedup { get; set; }

    public DateTime Lastsignedin { get; set; }

    public virtual ICollection<Admin> Admins { get; } = new List<Admin>();

    public virtual ICollection<Viewer> Viewers { get; } = new List<Viewer>();
}
