using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MovieHubAPI
{
    public partial class moviedbContext : DbContext
    {
        public moviedbContext()
        {
        }

        public moviedbContext(DbContextOptions<moviedbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Film> Film { get; set; }
        public virtual DbSet<FilmZanr> FilmZanr { get; set; }
        public virtual DbSet<OmiljeniFilmovi> OmiljeniFilmovi { get; set; }
        public virtual DbSet<RegistrovaniKorisnik> RegistrovaniKorisnik { get; set; }
        public virtual DbSet<Watchlist> Watchlist { get; set; }
        public virtual DbSet<WatchlistFilm> WatchlistFilm { get; set; }
        public virtual DbSet<Zanr> Zanr { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-AAU2QSM\\SQLEXPRESS;Database=moviedb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<Film>(entity =>
            {
                entity.Property(e => e.FilmId).HasColumnName("FilmID");

                entity.Property(e => e.Glumci).HasMaxLength(200);

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Ocjena).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.Opis).HasMaxLength(500);

                entity.Property(e => e.Reziser).HasMaxLength(50);

                entity.Property(e => e.Trailer).HasMaxLength(100);
            });

            modelBuilder.Entity<FilmZanr>(entity =>
            {
                entity.HasIndex(e => e.FilmId);

                entity.HasIndex(e => e.ZanrId);

                entity.Property(e => e.FilmZanrId).HasColumnName("FilmZanrID");

                entity.Property(e => e.FilmId).HasColumnName("FilmID");

                entity.HasOne(d => d.Film)
                    .WithMany(p => p.FilmZanr)
                    .HasForeignKey(d => d.FilmId);

                entity.HasOne(d => d.Zanr)
                    .WithMany(p => p.FilmZanr)
                    .HasForeignKey(d => d.ZanrId);
            });

            modelBuilder.Entity<OmiljeniFilmovi>(entity =>
            {
                entity.HasIndex(e => e.FilmId);

                entity.HasIndex(e => e.RegistrovaniKorisnikId);

                entity.Property(e => e.OmiljeniFilmoviId).HasColumnName("OmiljeniFilmoviID");

                entity.Property(e => e.FilmId).HasColumnName("FilmID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Film)
                    .WithMany(p => p.OmiljeniFilmovi)
                    .HasForeignKey(d => d.FilmId);

                entity.HasOne(d => d.RegistrovaniKorisnik)
                    .WithMany(p => p.OmiljeniFilmovi)
                    .HasForeignKey(d => d.RegistrovaniKorisnikId);
            });

            modelBuilder.Entity<Watchlist>(entity =>
            {
                entity.HasIndex(e => e.RegistrovaniKorisnikId);

                entity.Property(e => e.WatchlistId).HasColumnName("WatchlistID");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.RegistrovaniKorisnik)
                    .WithMany(p => p.Watchlist)
                    .HasForeignKey(d => d.RegistrovaniKorisnikId);
            });

            modelBuilder.Entity<WatchlistFilm>(entity =>
            {
                entity.HasIndex(e => e.FilmId);

                entity.HasIndex(e => e.WatchlistId);

                entity.Property(e => e.WatchlistFilmId).HasColumnName("WatchlistFilmID");

                entity.Property(e => e.WatchlistId).HasColumnName("WatchlistID");

                entity.HasOne(d => d.Film)
                    .WithMany(p => p.WatchlistFilm)
                    .HasForeignKey(d => d.FilmId);

                entity.HasOne(d => d.Watchlist)
                    .WithMany(p => p.WatchlistFilm)
                    .HasForeignKey(d => d.WatchlistId);
            });

            modelBuilder.Entity<Zanr>(entity =>
            {
                entity.Property(e => e.ZanrId).HasColumnName("ZanrID");

                entity.Property(e => e.Naziv).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
