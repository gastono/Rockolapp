using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rocolapp.Models
{
    public class Adverts
    {
        public int Id { get; set; }
        public int RockolapUserId { get; set; }
        public string Marquee { get; set; }
        public string ImagePath { get; set; }
        public int Laps { get; set; }


        //Navigation Properties
        public virtual RocolappUser RockolapUser { get; set; }
    }
}