namespace Rocolapp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Screen")]
    public partial class Screen
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string RocolappUserName { get; set; }

        public string SpotifyUserId { get; set; }

        public string ConnectionId { get; set; }

        public bool Connected { get; set; }

        public string ScreenCode { get; set; }
    }
}
