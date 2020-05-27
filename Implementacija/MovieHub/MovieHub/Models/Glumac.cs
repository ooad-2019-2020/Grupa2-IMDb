using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieHub.Models
{
    public class Glumac
    {
        [ScaffoldColumn(false)]
        public int GlumacId { get; set; }

        [StringLength(50)]
        public string ImeIPrezime { get; set; }

        public virtual ICollection<FilmGlumac> FilmGlumac { get; set; }

    }
}
