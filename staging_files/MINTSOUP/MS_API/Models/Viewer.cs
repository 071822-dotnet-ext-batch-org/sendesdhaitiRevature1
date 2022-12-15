using System;
using System.Collections.Generic;

namespace MS_API.Models;

public partial class Viewer
{
    public Guid Id { get; set; }

    public Guid? FkMstoken { get; set; }

    public string Fn { get; set; } = null!;

    public string Ln { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Image { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string Aboutme { get; set; } = null!;

    public string Streetaddy { get; set; } = null!;

    public string City { get; set; } = null!;

    public string State { get; set; } = null!;

    public string Country { get; set; } = null!;

    public int Areacode { get; set; }

    public string Role { get; set; } = null!;

    public string Membershipstatus { get; set; } = null!;

    public DateTime Datesignedup { get; set; }

    public DateTime Lastsignedin { get; set; }

    public virtual Mintsouptoken? FkMstokenNavigation { get; set; }

    public virtual ICollection<Follower> FollowerFkVieweridFollowerNavigations { get; } = new List<Follower>();

    public virtual ICollection<Follower> FollowerFkVieweridFollowieNavigations { get; } = new List<Follower>();

    public virtual ICollection<Friend> FriendFkVieweridFrienderNavigations { get; } = new List<Friend>();

    public virtual ICollection<Friend> FriendFkVieweridFriendieNavigations { get; } = new List<Friend>();

    public virtual ICollection<Showcommentlike> Showcommentlikes { get; } = new List<Showcommentlike>();

    public virtual ICollection<Showcomment> Showcomments { get; } = new List<Showcomment>();

    public virtual ICollection<Showdonation> Showdonations { get; } = new List<Showdonation>();

    public virtual ICollection<Showlike> Showlikes { get; } = new List<Showlike>();

    public virtual ICollection<Show> Shows { get; } = new List<Show>();

    public virtual ICollection<Showsessionjoin> Showsessionjoins { get; } = new List<Showsessionjoin>();

    public virtual ICollection<Subscriber> Subscribers { get; } = new List<Subscriber>();

    public virtual ICollection<WalletsShow> WalletsShows { get; } = new List<WalletsShow>();

    public virtual ICollection<WalletsViewer> WalletsViewers { get; } = new List<WalletsViewer>();
}
