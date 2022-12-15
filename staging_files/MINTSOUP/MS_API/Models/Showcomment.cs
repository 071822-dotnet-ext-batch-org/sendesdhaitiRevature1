using System;
using System.Collections.Generic;

namespace MS_API.Models;

public partial class Showcomment
{
    public Guid Id { get; set; }

    public Guid? FkVieweridCommenter { get; set; }

    public Guid? FkShowsessionid { get; set; }

    public string Comment { get; set; } = null!;

    public int Likes { get; set; }

    public DateTime Commentdate { get; set; }

    public DateTime Commentupdatedate { get; set; }

    public virtual Showsession? FkShowsession { get; set; }

    public virtual Viewer? FkVieweridCommenterNavigation { get; set; }

    public virtual ICollection<Showcommentlike> Showcommentlikes { get; } = new List<Showcommentlike>();
}
