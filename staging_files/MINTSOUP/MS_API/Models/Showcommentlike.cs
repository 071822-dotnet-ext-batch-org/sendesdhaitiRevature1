using System;
using System.Collections.Generic;

namespace MS_API.Models;

public partial class Showcommentlike
{
    public Guid Id { get; set; }

    public Guid? FkVieweridLiker { get; set; }

    public Guid? FkShowcommentid { get; set; }

    public DateTime Likedate { get; set; }

    public virtual Showcomment? FkShowcomment { get; set; }

    public virtual Viewer? FkVieweridLikerNavigation { get; set; }
}
