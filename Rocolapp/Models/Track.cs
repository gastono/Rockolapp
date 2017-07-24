using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rocolapp.Models
{
    public class Track
    {
        //public string UriId { get; set; }
        public long Id { get; set; }
        public string TrackId { get; set; }
        public string Singer { get; set; }
        public string TrackName { get; set; }
        public string Token { get; set; }
    }
}