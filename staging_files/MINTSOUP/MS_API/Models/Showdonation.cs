using System;
using System.Collections.Generic;

namespace MS_API.Models;

public partial class Showdonation
{
    public Guid Id { get; set; }

    public Guid? FkVieweridDonater { get; set; }

    public Guid? FkWalletsViewerid { get; set; }

    public Guid? FkWalletsShowid { get; set; }

    public int Amount { get; set; }

    public string? Note { get; set; }

    public DateTime Donationdate { get; set; }

    public virtual Viewer? FkVieweridDonaterNavigation { get; set; }

    public virtual WalletsShow? FkWalletsShow { get; set; }

    public virtual WalletsViewer? FkWalletsViewer { get; set; }
}
