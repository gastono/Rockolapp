using Rocolapp.DAL;
using SpotifyAPI.Web.Auth;
using SpotifyAPI.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rocolapp.Helpers
{
    public static class TokenUtils
    {
        private static AutorizationCodeAuth auth;

        public static Token CreateNewToken(string refreshToken, string userId)
        {
            AutorizationCodeAuth auth = new AutorizationCodeAuth();
          
            auth.ClientId = DataAccess.GetRocolappData().ClientId;
            auth.RedirectUri = DataAccess.GetRocolappData().RedirectUri;
            string clientSecret = DataAccess.GetRocolappData().ClientSecret;

            Token newToken = auth.RefreshToken(refreshToken, DataAccess.GetRocolappData().ClientSecret);

            return newToken;
            
        }

        //public static void GetAllAccess()
        //{
        //    auth = new AutorizationCodeAuth()
        //    {
        //        //Your client Id
        //        ClientId = DataAccess.GetRocolappData().ClientId,
        //        //Set this to localhost if you want to use the built-in HTTP Server
        //        RedirectUri = DataAccess.GetRocolappData().RedirectUri,
        //        //How many permissions we need?
        //        Scope = SpotifyAPI.Web.Enums.Scope.UserLibraryModify,
        //    };
        //    //This will be called, if the user cancled/accept the auth-request
        //    auth.OnResponseReceivedEvent += auth_OnResponseReceivedEvent;
        //    //a local HTTP Server will be started (Needed for the response)
        //    auth.StartHttpServer();
        //    //This will open the spotify auth-page. The user can decline/accept the request
        //    auth.DoAuth();

        //    Thread.Sleep(60000);
        //    auth.StopHttpServer();
        //    Console.WriteLine("Too long, didnt respond, exiting now...");

        //}
    }
}