using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyScapperProgects
{
    class FilmRelease
    {
        public Dictionary<string,string> FilmName { get; set; }
        public int FilmMinutes { get; set; }
        public List<string> Genre { get; set; }
        public Dictionary<string,string> FilmDirector { get; set; }
        public Dictionary<string, string> FilmStars { get; set; }
        public int FilmYear { get; set; }

        public FilmRelease()
        {
            this.FilmName = new Dictionary<string, string>();
            this.Genre = new List<string>();
            this.FilmDirector = new Dictionary<string, string>();
            this.FilmStars = new Dictionary<string, string>();

        }

    }
}
