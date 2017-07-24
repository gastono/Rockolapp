using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Rocolapp.Models;

namespace Rocolapp.DAL
{
    public static class DataAccess
    {
        
        public static RoclappData GetRocolappData()
        {
            RoclappData rd = new RoclappData();

            rd.ClientId = "6a5c69fc50be4f11996e54d18ce95843";
            rd.ClientSecret = "60822879f8a64ccca934974909daa0bd";
            //rd.RedirectUri = "http://138.36.238.199/MainPage/Main";//"http://localhost/Rocolapp/MainPage/Main";//"http://www.google.com.ar";
            rd.RedirectUri = "http://localhost/Rocolapp/MainPage/Main";
            rd.UserId = "gaston.spotfy";
            rd.MainPlaylist = "7Ckc7mWQuXizALdqeJAjWw";
            //rd.Scope = "playlist-modify-public&scope=playlist-modify-private&scope=playlist-read-private&scope=playlist-read-collaborative&scope=user-library-read&scope=user-library-modify&scope=user-read-private&scope=user-read-birthdate&scope=user-read-email&scope=user-follow-read&scope=user-follow-modify&scope=user-top-read&scope=user-read-playback-state&scope=user-read-recently-played&scope=user-read-currently-playing&scope=user-modify-playback-state";
            rd.Scope = "playlist-read-private playlist-read-collaborative playlist-modify-public playlist-modify-private user-library-read user-library-modify user-read-private user-read-birthdate user-read-email user-follow-read user-follow-modify user-top-read user-read-playback-state user-read-recently-played user-read-currently-playing user-modify-playback-state";

            return rd;
        }

        public static PubUser GetPubUserData()
        {
            return new PubUser { Id = "gaston.spotfy", Name = "GastonPub", Token = "BQAOA_0lWi5hNmdF6lQ_M5vOOCZGB6CGXugAIkgdYEwFAks1Mrqec2SUBs5UgJWskBMZXmZ0x6OiT6rsSUZwWfi00GhpAYupCE8XTlWxqGav43YeCjvH5nYHDWQxaYXf1Sb26rVAw4rFWdL9zdd3Z75E8gaI-2hwE3U" } ;
        }
        
    }
}