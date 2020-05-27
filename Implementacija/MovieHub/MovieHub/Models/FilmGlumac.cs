using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieHub.Models
{
    public class FilmGlumac
    {
        public int FilmZanrID { get; set; }
        public int FilmID { get; set; }
        public int GlumacId { get; set; }

        public virtual Film Film { get; set; }
        public virtual Glumac Glumac { get; set; }
    }
}
