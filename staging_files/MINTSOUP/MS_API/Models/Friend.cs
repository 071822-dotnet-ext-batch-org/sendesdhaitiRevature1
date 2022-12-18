using System;
using System.Collections.Generic;

namespace MS_API.Models;

public partial class Friend
{
    public Guid Id { get; set; }

    public Guid? FkVieweridFriender { get; set; }

    public Guid? FkVieweridFriendie { get; set; }

    public string Friendshipstatus { get; set; } = null!;

    public DateTime Frienddate { get; set; }

    public DateTime Friendupdatedate { get; set; }

    public virtual Viewer? FkVieweridFrienderNavigation { get; set; }

    public virtual Viewer? FkVieweridFriendieNavigation { get; set; }
}
