using System;
using System.Collections.Generic;

namespace MS_API.Models;

public partial class Showsession
{
    public Guid Id { get; set; }

    public Guid? FkShowid { get; set; }

    public int Views { get; set; }

    public int Likes { get; set; }

    public int Comments { get; set; }

    public DateTime Sessionstartdate { get; set; }

    public DateTime Sessionenddate { get; set; }

    public virtual Show? FkShow { get; set; }

    public virtual ICollection<Showcomment> Showcomments { get; } = new List<Showcomment>();

    public virtual ICollection<Showlike> Showlikes { get; } = new List<Showlike>();

    public virtual ICollection<Showsessionjoin> Showsessionjoins { get; } = new List<Showsessionjoin>();
}
