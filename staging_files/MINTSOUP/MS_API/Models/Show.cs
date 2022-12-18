using System;
using System.Collections.Generic;

namespace MS_API.Models;

public partial class Show
{
    public Guid Id { get; set; }

    public Guid? FkVieweridOwner { get; set; }

    public string Showname { get; set; } = null!;

    public string Showimage { get; set; } = null!;

    public int Subscribers { get; set; }

    public int Views { get; set; }

    public int Likes { get; set; }

    public int Comments { get; set; }

    public float Rating { get; set; }

    public int Rank { get; set; }

    public string Privacylevel { get; set; } = null!;

    public string Showstatus { get; set; } = null!;

    public DateTime Datecreated { get; set; }

    public DateTime Lastlive { get; set; }

    public virtual Viewer? FkVieweridOwnerNavigation { get; set; }

    public virtual ICollection<Follower> Followers { get; } = new List<Follower>();

    public virtual ICollection<Showsession> Showsessions { get; } = new List<Showsession>();

    public virtual ICollection<Subscriber> SubscribersNavigation { get; } = new List<Subscriber>();

    public virtual ICollection<WalletsShow> WalletsShows { get; } = new List<WalletsShow>();
}
