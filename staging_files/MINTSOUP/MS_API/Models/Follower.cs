using System;
using System.Collections.Generic;

namespace MS_API.Models;

public partial class Follower
{
    public Guid Id { get; set; }

    public Guid? FkVieweridFollower { get; set; }

    public Guid? FkVieweridFollowie { get; set; }

    public Guid? FkShowidFollowie { get; set; }

    public string Followerstatus { get; set; } = null!;

    public DateTime Followdate { get; set; }

    public DateTime Statusupdatedate { get; set; }

    public virtual Show? FkShowidFollowieNavigation { get; set; }

    public virtual Viewer? FkVieweridFollowerNavigation { get; set; }

    public virtual Viewer? FkVieweridFollowieNavigation { get; set; }
}
