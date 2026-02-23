using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WinFormsApp1.Data.Models;

public partial class FootballManagerContext : DbContext
{
    private readonly string _connectionString;

    public FootballManagerContext(string connectionString)
    {
        _connectionString = connectionString;
    }

    public FootballManagerContext(DbContextOptions<FootballManagerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Card> Cards { get; set; }

    public virtual DbSet<Club> Clubs { get; set; }

    public virtual DbSet<Foul> Fouls { get; set; }

    public virtual DbSet<Goal> Goals { get; set; }

    public virtual DbSet<League> Leagues { get; set; }

    public virtual DbSet<Match> Matches { get; set; }

    public virtual DbSet<Player> Players { get; set; }

    public virtual DbSet<Transfer> Transfers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(_connectionString);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Card>(entity =>
        {
            entity.HasKey(e => e.CardId).HasName("PK__Cards__55FECDAED0BBDA87");

            entity.ToTable(tb =>
                {
                    tb.HasTrigger("TR_Cards_AutoAssignClub");
                    tb.HasTrigger("TR_Cards_PlayerClubValidation");
                });

            entity.Property(e => e.Type).HasMaxLength(16);

            entity.HasOne(d => d.Club).WithMany(p => p.Cards).HasForeignKey(d => d.ClubId);

            entity.HasOne(d => d.Match).WithMany(p => p.Cards)
                .HasForeignKey(d => d.MatchId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Player).WithMany(p => p.Cards)
                .HasForeignKey(d => d.PlayerId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Club>(entity =>
        {
            entity.HasKey(e => e.ClubId).HasName("PK__Clubs__D35058E7B6A5AC75");

            entity.HasIndex(e => e.Name, "UQ__Clubs__737584F6CFAF6592").IsUnique();

            entity.Property(e => e.City).HasMaxLength(64);
            entity.Property(e => e.Name).HasMaxLength(64);
            entity.Property(e => e.Stadium).HasMaxLength(64);
        });

        modelBuilder.Entity<Foul>(entity =>
        {
            entity.HasKey(e => e.FoulId).HasName("PK__Fouls__464FA21903BDC407");

            entity.ToTable(tb =>
                {
                    tb.HasTrigger("TR_Fouls_AutoAssignClub");
                    tb.HasTrigger("TR_Fouls_PlayerClubValidation");
                });

            entity.Property(e => e.Type).HasMaxLength(64);

            entity.HasOne(d => d.Club).WithMany(p => p.Fouls).HasForeignKey(d => d.ClubId);

            entity.HasOne(d => d.Match).WithMany(p => p.Fouls)
                .HasForeignKey(d => d.MatchId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Player).WithMany(p => p.Fouls)
                .HasForeignKey(d => d.PlayerId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Goal>(entity =>
        {
            entity.HasKey(e => e.GoalId).HasName("PK__Goals__8A4FFFD1E41D38DE");

            entity.ToTable(tb =>
                {
                    tb.HasTrigger("TR_Goals_AutoAssignClub");
                    tb.HasTrigger("TR_Goals_PlayerClubValidation");
                });

            entity.HasOne(d => d.Club).WithMany(p => p.Goals).HasForeignKey(d => d.ClubId);

            entity.HasOne(d => d.Match).WithMany(p => p.Goals)
                .HasForeignKey(d => d.MatchId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Player).WithMany(p => p.Goals)
                .HasForeignKey(d => d.PlayerId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<League>(entity =>
        {
            entity.HasKey(e => e.LeagueId).HasName("PK__Leagues__10ABBCF4B101909F");

            entity.Property(e => e.Name).HasMaxLength(64);
            entity.Property(e => e.Season).HasMaxLength(16);

            entity.HasMany(d => d.Clubs).WithMany(p => p.Leagues)
                .UsingEntity<Dictionary<string, object>>(
                    "LeagueTeam",
                    r => r.HasOne<Club>().WithMany()
                        .HasForeignKey("ClubId")
                        .OnDelete(DeleteBehavior.ClientSetNull),
                    l => l.HasOne<League>().WithMany()
                        .HasForeignKey("LeagueId")
                        .OnDelete(DeleteBehavior.ClientSetNull),
                    j =>
                    {
                        j.HasKey("LeagueId", "ClubId");
                        j.ToTable("LeagueTeams");
                    });
        });

        modelBuilder.Entity<Match>(entity =>
        {
            entity.HasKey(e => e.MatchId).HasName("PK__Matches__4218C8170EFA9698");

            entity.HasOne(d => d.AwayClub).WithMany(p => p.MatchAwayClubs)
                .HasForeignKey(d => d.AwayClubId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Matches_Clubs_AwayClub");

            entity.HasOne(d => d.HomeClub).WithMany(p => p.MatchHomeClubs)
                .HasForeignKey(d => d.HomeClubId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Matches_Clubs_HomeClub");

            entity.HasOne(d => d.League).WithMany(p => p.Matches)
                .HasForeignKey(d => d.LeagueId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Player>(entity =>
        {
            entity.HasKey(e => e.PlayerId).HasName("PK__Players__4A4E74C893DCFCFC");

            entity.ToTable(tb => tb.HasTrigger("TR_Players_ValidateAge"));

            entity.Property(e => e.DominantFoot).HasMaxLength(16);
            entity.Property(e => e.FullName).HasMaxLength(64);
            entity.Property(e => e.Nationality).HasMaxLength(64);
            entity.Property(e => e.Position).HasMaxLength(32);
            entity.Property(e => e.Status).HasMaxLength(16);

            entity.HasOne(d => d.Club).WithMany(p => p.Players)
                .HasForeignKey(d => d.ClubId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Transfer>(entity =>
        {
            entity.HasKey(e => e.TransferId).HasName("PK__Transfer__954900910852E9DE");

            entity.Property(e => e.Comment).HasMaxLength(255);
            entity.Property(e => e.Type).HasMaxLength(16);

            entity.HasOne(d => d.ClubFromNavigation).WithMany(p => p.TransferClubFromNavigations)
                .HasForeignKey(d => d.ClubFrom)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.ClubToNavigation).WithMany(p => p.TransferClubToNavigations)
                .HasForeignKey(d => d.ClubTo)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Player).WithMany(p => p.Transfers)
                .HasForeignKey(d => d.PlayerId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4C4819C857");

            entity.HasIndex(e => e.UserName, "UQ__Users__C9F284561AD0FFF1").IsUnique();

            entity.Property(e => e.Password).HasMaxLength(32);
            entity.Property(e => e.Type).HasMaxLength(16);
            entity.Property(e => e.UserName).HasMaxLength(32);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
