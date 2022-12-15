using System;
using System.Collections.Generic;

namespace MS_API.Models;

public partial class Showsessionjoin
{
    public Guid Id { get; set; }

    public Guid? FkShowsessionid { get; set; }

    public Guid? FkVieweridShowviewer { get; set; }

    public DateTime Sessionjoindate { get; set; }

    public DateTime Sessionleavedate { get; set; }

    public virtual Showsession? FkShowsession { get; set; }

    public virtual Viewer? FkVieweridShowviewerNavigation { get; set; }
}
