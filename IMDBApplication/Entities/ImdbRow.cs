using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDBApplication.Entities
{
    public class ImdbRow
    {
        public string Title { get; set; }
        public string Poster { get; set; }
        public string ImdbId { get; set; }
        public string ImdbRating { get; set; }
        public string Released { get; set; }
        public string Genre { get; set; }
        public string Country { get; set; }
        public string Writer { get; set; }
        public string Language { get; set; }
        public string ImdbVotes { get; set; }

    }
}
