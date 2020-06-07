using System;
using System.Collections.Generic;

namespace MovieHubAPI
{
    public partial class OmiljeniFilmovi
    {
        public int OmiljeniFilmoviId { get; set; }
        public int FilmId { get; set; }
        public int UserId { get; set; }
        public string RegistrovaniKorisnikId { get; set; }

        public virtual Film Film { get; set; }
        public virtual RegistrovaniKorisnik RegistrovaniKorisnik { get; set; }
    }
}
