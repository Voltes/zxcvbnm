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
        public List<string> FilmNameList { get; set; }
        public List<string> FilmAddressList { get; set; }
        public string Certification { get; set; }
        public string FilmMinutes { get; set; }
        public List<string> Genre { get; set; }
        public string Description { get; set; }
        public Dictionary<string,string> FilmDirector { get; set; }
        public Dictionary<string, string> FilmStars { get; set; }
        public string FilmYear { get; set; }

        public FilmRelease()
        {
            this.FilmName = new Dictionary<string, string>();
            this.FilmNameList = new List<string>();
            this.FilmAddressList = new List<string>();
            this.Genre = new List<string>();
            this.FilmDirector = new Dictionary<string, string>();
            this.FilmStars = new Dictionary<string, string>();

        }

    }
}
