using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rocolapp.Models
{
    public class PubUser
    {
        public string Name { get; set; }
        public string Id { get; set; } 
        public string RocolappPlaylistId { get; set; }
        public string Token { get; set; }
    }
}