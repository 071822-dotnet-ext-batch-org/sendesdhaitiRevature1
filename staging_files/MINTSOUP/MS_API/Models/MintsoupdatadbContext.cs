using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MS_API.Models;

public partial class MintsoupdatadbContext : DbContext
{
    public MintsoupdatadbContext()
    {
    }

    public MintsoupdatadbContext(DbContextOptions<MintsoupdatadbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Follower> Followers { get; set; }

    public virtual DbSet<Friend> Friends { get; set; }

    public virtual DbSet<Mintsouptoken> Mintsouptokens { get; set; }

    public virtual DbSet<Show> Shows { get; set; }

    public virtual DbSet<Showcomment> Showcomments { get; set; }

    public virtual DbSet<Showcommentlike> Showcommentlikes { get; set; }

    public virtual DbSet<Showdonation> Showdonations { get; set; }

    public virtual DbSet<Showlike> Showlikes { get; set; }

    public virtual DbSet<Showsession> Showsessions { get; set; }

    public virtual DbSet<Showsessionjoin> Showsessionjoins { get; set; }

    public virtual DbSet<Subscriber> Subscribers { get; set; }

    public virtual DbSet<Userdatum> Userdata { get; set; }

    public virtual DbSet<Viewer> Viewers { get; set; }

    public virtual DbSet<WalletsShow> WalletsShows { get; set; }

    public virtual DbSet<WalletsViewer> WalletsViewers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=mintsoupdatadb;Username=msadmin;Password=@Arcade30");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("uuid-ossp");

        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("admins_pkey");

            entity.ToTable("admins");

            entity.HasIndex(e => e.Email, "admins_email_key").IsUnique();

            entity.HasIndex(e => e.Username, "admins_username_key").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.Adminstatus)
                .HasMaxLength(100)
                .HasDefaultValueSql("'Admin'::character varying")
                .HasColumnName("adminstatus");
            entity.Property(e => e.Datecreated)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("datecreated");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.FkMstoken)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("fk_mstoken");
            entity.Property(e => e.Lastsignedin)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("lastsignedin");
            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .HasColumnName("username");

            entity.HasOne(d => d.FkMstokenNavigation).WithMany(p => p.Admins)
                .HasForeignKey(d => d.FkMstoken)
                .HasConstraintName("fk_mstoken_admin");
        });

        modelBuilder.Entity<Follower>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("followers_pkey");

            entity.ToTable("followers");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.FkShowidFollowie)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("fk_showid_followie");
            entity.Property(e => e.FkVieweridFollower)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("fk_viewerid_follower");
            entity.Property(e => e.FkVieweridFollowie)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("fk_viewerid_followie");
            entity.Property(e => e.Followdate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("followdate");
            entity.Property(e => e.Followerstatus)
                .HasMaxLength(30)
                .HasDefaultValueSql("'Follower'::character varying")
                .HasColumnName("followerstatus");
            entity.Property(e => e.Statusupdatedate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("statusupdatedate");

            entity.HasOne(d => d.FkShowidFollowieNavigation).WithMany(p => p.Followers)
                .HasForeignKey(d => d.FkShowidFollowie)
                .HasConstraintName("fk_showid_followie");

            entity.HasOne(d => d.FkVieweridFollowerNavigation).WithMany(p => p.FollowerFkVieweridFollowerNavigations)
                .HasForeignKey(d => d.FkVieweridFollower)
                .HasConstraintName("fk_viewerid_follower");

            entity.HasOne(d => d.FkVieweridFollowieNavigation).WithMany(p => p.FollowerFkVieweridFollowieNavigations)
                .HasForeignKey(d => d.FkVieweridFollowie)
                .HasConstraintName("fk_viewerid_followie");
        });

        modelBuilder.Entity<Friend>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("friends_pkey");

            entity.ToTable("friends");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.FkVieweridFriender)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("fk_viewerid_friender");
            entity.Property(e => e.FkVieweridFriendie)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("fk_viewerid_friendie");
            entity.Property(e => e.Frienddate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("frienddate");
            entity.Property(e => e.Friendshipstatus)
                .HasMaxLength(30)
                .HasDefaultValueSql("'PendingFriend'::character varying")
                .HasColumnName("friendshipstatus");
            entity.Property(e => e.Friendupdatedate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("friendupdatedate");

            entity.HasOne(d => d.FkVieweridFrienderNavigation).WithMany(p => p.FriendFkVieweridFrienderNavigations)
                .HasForeignKey(d => d.FkVieweridFriender)
                .HasConstraintName("fk_viewerid_friender");

            entity.HasOne(d => d.FkVieweridFriendieNavigation).WithMany(p => p.FriendFkVieweridFriendieNavigations)
                .HasForeignKey(d => d.FkVieweridFriendie)
                .HasConstraintName("fk_viewerid_friendie");
        });

        modelBuilder.Entity<Mintsouptoken>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("mintsouptokens_pkey");

            entity.ToTable("mintsouptokens");

            entity.HasIndex(e => e.Email, "mintsouptokens_email_key").IsUnique();

            entity.HasIndex(e => e.Username, "mintsouptokens_username_key").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.Datesignedup)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("datesignedup");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Lastsignedin)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("lastsignedin");
            entity.Property(e => e.PasswordHash).HasColumnName("password_hash");
            entity.Property(e => e.PasswordSalt).HasColumnName("password_salt");
            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .HasColumnName("username");
        });

        modelBuilder.Entity<Show>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("shows_pkey");

            entity.ToTable("shows");

            entity.HasIndex(e => e.Showname, "shows_showname_key").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.Comments).HasColumnName("comments");
            entity.Property(e => e.Datecreated)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("datecreated");
            entity.Property(e => e.FkVieweridOwner)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("fk_viewerid_owner");
            entity.Property(e => e.Lastlive)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("lastlive");
            entity.Property(e => e.Likes).HasColumnName("likes");
            entity.Property(e => e.Privacylevel)
                .HasMaxLength(30)
                .HasColumnName("privacylevel");
            entity.Property(e => e.Rank).HasColumnName("rank");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.Showimage)
                .HasMaxLength(200)
                .HasColumnName("showimage");
            entity.Property(e => e.Showname)
                .HasMaxLength(100)
                .HasColumnName("showname");
            entity.Property(e => e.Showstatus)
                .HasMaxLength(30)
                .HasDefaultValueSql("'Great'::character varying")
                .HasColumnName("showstatus");
            entity.Property(e => e.Subscribers).HasColumnName("subscribers");
            entity.Property(e => e.Views).HasColumnName("views");

            entity.HasOne(d => d.FkVieweridOwnerNavigation).WithMany(p => p.Shows)
                .HasForeignKey(d => d.FkVieweridOwner)
                .HasConstraintName("fk_viewerid_owner");
        });

        modelBuilder.Entity<Showcomment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("showcomments_pkey");

            entity.ToTable("showcomments");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.Comment)
                .HasMaxLength(200)
                .HasColumnName("comment");
            entity.Property(e => e.Commentdate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("commentdate");
            entity.Property(e => e.Commentupdatedate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("commentupdatedate");
            entity.Property(e => e.FkShowsessionid)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("fk_showsessionid");
            entity.Property(e => e.FkVieweridCommenter)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("fk_viewerid_commenter");
            entity.Property(e => e.Likes).HasColumnName("likes");

            entity.HasOne(d => d.FkShowsession).WithMany(p => p.Showcomments)
                .HasForeignKey(d => d.FkShowsessionid)
                .HasConstraintName("fk_showsessionid");

            entity.HasOne(d => d.FkVieweridCommenterNavigation).WithMany(p => p.Showcomments)
                .HasForeignKey(d => d.FkVieweridCommenter)
                .HasConstraintName("fk_viewerid_commenter");
        });

        modelBuilder.Entity<Showcommentlike>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("showcommentlikes_pkey");

            entity.ToTable("showcommentlikes");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.FkShowcommentid)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("fk_showcommentid");
            entity.Property(e => e.FkVieweridLiker)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("fk_viewerid_liker");
            entity.Property(e => e.Likedate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("likedate");

            entity.HasOne(d => d.FkShowcomment).WithMany(p => p.Showcommentlikes)
                .HasForeignKey(d => d.FkShowcommentid)
                .HasConstraintName("fk_showcommentid");

            entity.HasOne(d => d.FkVieweridLikerNavigation).WithMany(p => p.Showcommentlikes)
                .HasForeignKey(d => d.FkVieweridLiker)
                .HasConstraintName("fk_viewerid_liker");
        });

        modelBuilder.Entity<Showdonation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("showdonations_pkey");

            entity.ToTable("showdonations");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.Amount).HasColumnName("amount");
            entity.Property(e => e.Donationdate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("donationdate");
            entity.Property(e => e.FkVieweridDonater)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("fk_viewerid_donater");
            entity.Property(e => e.FkWalletsShowid)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("fk_wallets_showid");
            entity.Property(e => e.FkWalletsViewerid)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("fk_wallets_viewerid");
            entity.Property(e => e.Note)
                .HasMaxLength(200)
                .HasColumnName("note");

            entity.HasOne(d => d.FkVieweridDonaterNavigation).WithMany(p => p.Showdonations)
                .HasForeignKey(d => d.FkVieweridDonater)
                .HasConstraintName("fk_viewerid_donater");

            entity.HasOne(d => d.FkWalletsShow).WithMany(p => p.Showdonations)
                .HasForeignKey(d => d.FkWalletsShowid)
                .HasConstraintName("fk_wallets_showid");

            entity.HasOne(d => d.FkWalletsViewer).WithMany(p => p.Showdonations)
                .HasForeignKey(d => d.FkWalletsViewerid)
                .HasConstraintName("fk_wallets_viewerid");
        });

        modelBuilder.Entity<Showlike>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("showlikes_pkey");

            entity.ToTable("showlikes");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.FkShowsessionid)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("fk_showsessionid");
            entity.Property(e => e.FkVieweridLiker)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("fk_viewerid_liker");
            entity.Property(e => e.Likedate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("likedate");

            entity.HasOne(d => d.FkShowsession).WithMany(p => p.Showlikes)
                .HasForeignKey(d => d.FkShowsessionid)
                .HasConstraintName("fk_showsessionid");

            entity.HasOne(d => d.FkVieweridLikerNavigation).WithMany(p => p.Showlikes)
                .HasForeignKey(d => d.FkVieweridLiker)
                .HasConstraintName("fk_viewerid_liker");
        });

        modelBuilder.Entity<Showsession>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("showsessions_pkey");

            entity.ToTable("showsessions");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.Comments).HasColumnName("comments");
            entity.Property(e => e.FkShowid)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("fk_showid");
            entity.Property(e => e.Likes).HasColumnName("likes");
            entity.Property(e => e.Sessionenddate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("sessionenddate");
            entity.Property(e => e.Sessionstartdate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("sessionstartdate");
            entity.Property(e => e.Views).HasColumnName("views");

            entity.HasOne(d => d.FkShow).WithMany(p => p.Showsessions)
                .HasForeignKey(d => d.FkShowid)
                .HasConstraintName("fk_showid_sessionshow");
        });

        modelBuilder.Entity<Showsessionjoin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("showsessionjoins_pkey");

            entity.ToTable("showsessionjoins");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.FkShowsessionid)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("fk_showsessionid");
            entity.Property(e => e.FkVieweridShowviewer)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("fk_viewerid_showviewer");
            entity.Property(e => e.Sessionjoindate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("sessionjoindate");
            entity.Property(e => e.Sessionleavedate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("sessionleavedate");

            entity.HasOne(d => d.FkShowsession).WithMany(p => p.Showsessionjoins)
                .HasForeignKey(d => d.FkShowsessionid)
                .HasConstraintName("fk_showsessionid_sessionjoined");

            entity.HasOne(d => d.FkVieweridShowviewerNavigation).WithMany(p => p.Showsessionjoins)
                .HasForeignKey(d => d.FkVieweridShowviewer)
                .HasConstraintName("fk_viewerid_showviewer");
        });

        modelBuilder.Entity<Subscriber>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("subscribers_pkey");

            entity.ToTable("subscribers");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.FkShowidSubscribie)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("fk_showid_subscribie");
            entity.Property(e => e.FkVieweridSubscriber)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("fk_viewerid_subscriber");
            entity.Property(e => e.Membershipstatus)
                .HasMaxLength(30)
                .HasDefaultValueSql("'Subscriber'::character varying")
                .HasColumnName("membershipstatus");
            entity.Property(e => e.Subscribedate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("subscribedate");
            entity.Property(e => e.Subscriptionupdatedate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("subscriptionupdatedate");

            entity.HasOne(d => d.FkShowidSubscribieNavigation).WithMany(p => p.SubscribersNavigation)
                .HasForeignKey(d => d.FkShowidSubscribie)
                .HasConstraintName("fk_showid_subscribie");

            entity.HasOne(d => d.FkVieweridSubscriberNavigation).WithMany(p => p.Subscribers)
                .HasForeignKey(d => d.FkVieweridSubscriber)
                .HasConstraintName("fk_viewerid_subscriber");
        });

        modelBuilder.Entity<Userdatum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("userdata_pkey");

            entity.ToTable("userdata");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Lastmodified)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("lastmodified");
            entity.Property(e => e.Usercount).HasColumnName("usercount");
        });

        modelBuilder.Entity<Viewer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("viewers_pkey");

            entity.ToTable("viewers");

            entity.HasIndex(e => e.Email, "viewers_email_key").IsUnique();

            entity.HasIndex(e => e.Username, "viewers_username_key").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.Aboutme)
                .HasMaxLength(200)
                .HasDefaultValueSql("''::character varying")
                .HasColumnName("aboutme");
            entity.Property(e => e.Areacode).HasColumnName("areacode");
            entity.Property(e => e.City)
                .HasMaxLength(100)
                .HasDefaultValueSql("''::character varying")
                .HasColumnName("city");
            entity.Property(e => e.Country)
                .HasMaxLength(100)
                .HasDefaultValueSql("''::character varying")
                .HasColumnName("country");
            entity.Property(e => e.Datesignedup)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("datesignedup");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.FkMstoken)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("fk_mstoken");
            entity.Property(e => e.Fn)
                .HasMaxLength(100)
                .HasDefaultValueSql("''::character varying")
                .HasColumnName("fn");
            entity.Property(e => e.Image)
                .HasMaxLength(150)
                .HasDefaultValueSql("''::character varying")
                .HasColumnName("image");
            entity.Property(e => e.Lastsignedin)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("lastsignedin");
            entity.Property(e => e.Ln)
                .HasMaxLength(100)
                .HasDefaultValueSql("''::character varying")
                .HasColumnName("ln");
            entity.Property(e => e.Membershipstatus)
                .HasMaxLength(30)
                .HasDefaultValueSql("'Viewer'::character varying")
                .HasColumnName("membershipstatus");
            entity.Property(e => e.Role)
                .HasMaxLength(30)
                .HasDefaultValueSql("'Viewer'::character varying")
                .HasColumnName("role");
            entity.Property(e => e.State)
                .HasMaxLength(100)
                .HasDefaultValueSql("''::character varying")
                .HasColumnName("state");
            entity.Property(e => e.Streetaddy)
                .HasMaxLength(100)
                .HasDefaultValueSql("''::character varying")
                .HasColumnName("streetaddy");
            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .HasColumnName("username");

            entity.HasOne(d => d.FkMstokenNavigation).WithMany(p => p.Viewers)
                .HasForeignKey(d => d.FkMstoken)
                .HasConstraintName("fk_mstoken_viewer");
        });

        modelBuilder.Entity<WalletsShow>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("wallets_show_pkey");

            entity.ToTable("wallets_show");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.Balance).HasColumnName("balance");
            entity.Property(e => e.Datecreated)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("datecreated");
            entity.Property(e => e.Dateupdated)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("dateupdated");
            entity.Property(e => e.FkShowidWalletshow)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("fk_showid_walletshow");
            entity.Property(e => e.FkVieweridWalletowner)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("fk_viewerid_walletowner");

            entity.HasOne(d => d.FkShowidWalletshowNavigation).WithMany(p => p.WalletsShows)
                .HasForeignKey(d => d.FkShowidWalletshow)
                .HasConstraintName("fk_showid_walletshow");

            entity.HasOne(d => d.FkVieweridWalletownerNavigation).WithMany(p => p.WalletsShows)
                .HasForeignKey(d => d.FkVieweridWalletowner)
                .HasConstraintName("fk_viewerid_walletowner");
        });

        modelBuilder.Entity<WalletsViewer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("wallets_viewer_pkey");

            entity.ToTable("wallets_viewer");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.Balance).HasColumnName("balance");
            entity.Property(e => e.Datecreated)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("datecreated");
            entity.Property(e => e.Dateupdated)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("dateupdated");
            entity.Property(e => e.FkVieweridWalletowner)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("fk_viewerid_walletowner");

            entity.HasOne(d => d.FkVieweridWalletownerNavigation).WithMany(p => p.WalletsViewers)
                .HasForeignKey(d => d.FkVieweridWalletowner)
                .HasConstraintName("fk_viewerid_walletowner");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
