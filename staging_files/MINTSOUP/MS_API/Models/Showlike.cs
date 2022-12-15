using System;
using System.Collections.Generic;

namespace MS_API.Models;

public partial class Showlike
{
    public Guid Id { get; set; }

    public Guid? FkVieweridLiker { get; set; }

    public Guid? FkShowsessionid { get; set; }

    public DateTime Likedate { get; set; }

    public virtual Showsession? FkShowsession { get; set; }

    public virtual Viewer? FkVieweridLikerNavigation { get; set; }
}
