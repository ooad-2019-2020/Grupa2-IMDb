using System;
using System.Collections.Generic;

namespace MovieHubAPI
{
    public partial class RegistrovaniKorisnik
    {
        public RegistrovaniKorisnik()
        {
            OmiljeniFilmovi = new HashSet<OmiljeniFilmovi>();
            Watchlist = new HashSet<Watchlist>();
        }

        public string Id { get; set; }
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string AppUsername { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string SlikaProfila { get; set; }
        public DateTime RokPretplate { get; set; }

        public virtual ICollection<OmiljeniFilmovi> OmiljeniFilmovi { get; set; }
        public virtual ICollection<Watchlist> Watchlist { get; set; }
    }
}
