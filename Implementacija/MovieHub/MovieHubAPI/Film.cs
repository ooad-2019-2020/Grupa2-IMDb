using System;
using System.Collections.Generic;

namespace MovieHubAPI
{
    public partial class Film
    {
        public Film()
        {
            FilmZanr = new HashSet<FilmZanr>();
            OmiljeniFilmovi = new HashSet<OmiljeniFilmovi>();
            WatchlistFilm = new HashSet<WatchlistFilm>();
        }

        public int FilmId { get; set; }
        public string Naziv { get; set; }
        public decimal Ocjena { get; set; }
        public string Trailer { get; set; }
        public string Opis { get; set; }
        public string Reziser { get; set; }
        public string Poster { get; set; }
        public DateTime DatumIzlaska { get; set; }
        public string Glumci { get; set; }
        public bool Popularan { get; set; }

        public virtual ICollection<FilmZanr> FilmZanr { get; set; }
        public virtual ICollection<OmiljeniFilmovi> OmiljeniFilmovi { get; set; }
        public virtual ICollection<WatchlistFilm> WatchlistFilm { get; set; }
    }
}
