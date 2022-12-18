using System;
using System.Collections.Generic;

namespace MS_API.Models;

public partial class WalletsShow
{
    public Guid Id { get; set; }

    public Guid? FkVieweridWalletowner { get; set; }

    public Guid? FkShowidWalletshow { get; set; }

    public int Balance { get; set; }

    public DateTime Datecreated { get; set; }

    public DateTime Dateupdated { get; set; }

    public virtual Show? FkShowidWalletshowNavigation { get; set; }

    public virtual Viewer? FkVieweridWalletownerNavigation { get; set; }

    public virtual ICollection<Showdonation> Showdonations { get; } = new List<Showdonation>();
}
