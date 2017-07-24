using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rocolapp.Models
{
    public class RoclappData
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string RedirectUri { get; set; }
        public string Code { get; set; }
        public string Token { get; set; }
        public string UserId { get; set; }
        public string RefreshToken { get; set; }
        public string MainPlaylist { get; set; }
        public string Scope { get; set; }
    }
}