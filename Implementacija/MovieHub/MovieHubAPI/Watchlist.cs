using System;
using System.Collections.Generic;

namespace MovieHubAPI
{
    public partial class Watchlist
    {
        public Watchlist()
        {
            WatchlistFilm = new HashSet<WatchlistFilm>();
        }

        public int WatchlistId { get; set; }
        public string Naziv { get; set; }
        public string UserId { get; set; }
        public string RegistrovaniKorisnikId { get; set; }

        public virtual RegistrovaniKorisnik RegistrovaniKorisnik { get; set; }
        public virtual ICollection<WatchlistFilm> WatchlistFilm { get; set; }
    }
}
