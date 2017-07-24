using Rocolapp.DAL;
using Rocolapp.Models;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;
using SpotifyAPI.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rocolapp.Controllers
{
    public class MainPageController : Controller
    {
        RocolappDataAccess dataAccess = new RocolappDataAccess();

        // GET: MainPage
        public ActionResult Main(string code)
        {           
            AutorizationCodeAuth auth = new AutorizationCodeAuth();

            RocolappUser rocolapUser;

            //Datos de mi aplicacion Rocolapp
            auth.ClientId = DataAccess.GetRocolappData().ClientId;
            auth.RedirectUri = DataAccess.GetRocolappData().RedirectUri;
            string clientSecret = DataAccess.GetRocolappData().ClientSecret;

            Token token = auth.ExchangeAuthCode(code, clientSecret);
                     

            PrivateProfile privateProfile = GetUserProfile(token.AccessToken);

            var existence = CheckIfUserExists(privateProfile.Id);

            if (existence)
            {
                var user = GetUser(privateProfile.Id);

                rocolapUser = new RocolappUser() { Id = user.Id, SpotifyId = user.SpotifyId ,Token = user.Token, RefreshToken = user.RefreshToken, PlaylistId = user.PlaylistId, Place = user.Place };
            }
            else
            {
                FullPlaylist playList = CreatePlayList(privateProfile.Id, token.AccessToken);

                int ok = CreateUser(token.AccessToken, token.RefreshToken, privateProfile.Id, playList.Id);

                rocolapUser = new RocolappUser() { Id = ok, SpotifyId = privateProfile.Id, Token = token.AccessToken, RefreshToken = token.RefreshToken, PlaylistId = playList.Id };
            }          

            ViewData["pubUser"] = rocolapUser;

            return View();
        }


        private bool CheckIfUserExists(string spotifyId)
        {
            var exist = dataAccess.CheckIfUserExists(spotifyId);

            return exist;
        }

        private RocolappUser GetUser(string spotifyId)
        {
            var user = dataAccess.GetUser(spotifyId);

            return user;
        }
        private int CreateUser(string token, string refreshToken, string spotifyId, string playlistId)
        {
            RocolappUser newUser = new RocolappUser();
            newUser.PlaylistId = playlistId;
            newUser.Token = token;
            newUser.RefreshToken = refreshToken;
            newUser.SpotifyId = spotifyId;

            var userId = dataAccess.SaveRocolapUserData(newUser);

            return userId;
        }
        
        private PrivateProfile GetUserProfile(string token)
        {
            RoclappData data = DataAccess.GetRocolappData();

            var spotify = new SpotifyWebAPI()
            {
                TokenType = "Bearer",
                AccessToken = token,
                UseAuth = true
            };

            PrivateProfile privateProfile = spotify.GetPrivateProfile();

            return privateProfile;
        }


        private FullPlaylist CreatePlayList(string spotifyId, string token)
        {
            var spotify = new SpotifyWebAPI()
            {
                TokenType = "Bearer",
                AccessToken = token,
                UseAuth = true
            };

            FullPlaylist newPlaylist = spotify.CreatePlaylist(spotifyId, "Rocolapp", true);

            return newPlaylist;
        }

        // GET: MainPage/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MainPage/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: MainPage/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MainPage/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: MainPage/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MainPage/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
