using System;
using System.Collections.Generic;

namespace MovieHubAPI
{
    public partial class WatchlistFilm
    {
        public int WatchlistFilmId { get; set; }
        public int WatchlistId { get; set; }
        public int FilmId { get; set; }

        public virtual Film Film { get; set; }
        public virtual Watchlist Watchlist { get; set; }
    }
}
