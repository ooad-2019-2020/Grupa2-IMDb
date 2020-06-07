using System;
using System.Collections.Generic;

namespace MovieHubAPI
{
    public partial class Zanr
    {
        public Zanr()
        {
            FilmZanr = new HashSet<FilmZanr>();
        }

        public int ZanrId { get; set; }
        public string Naziv { get; set; }

        public virtual ICollection<FilmZanr> FilmZanr { get; set; }
    }
}
