namespace Rocolapp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RocolappUser")]
    public partial class RocolappUser
    {
        public int Id { get; set; }

        public string Place { get; set; }

        public string SpotifyId { get; set; }

        public string PlaylistId { get; set; }

        public string Token { get; set; }

        public string RefreshToken { get; set; }

        public string Scope { get; set; }
    }
}
