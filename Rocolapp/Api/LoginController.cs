using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SpotifyAPI.Web; //Base Namespace
using SpotifyAPI.Web.Auth; //All Authentication-related classes
using SpotifyAPI.Web.Enums; //Enums
using SpotifyAPI.Web.Models; //Models for the JSON-responses
using Rocolapp.Models;
using Rocolapp.DAL;
using System.Threading.Tasks;

namespace Rocolapp.Api
{
    public class LoginController : ApiController
    {

        RocolappDataAccess dataAccess = new RocolappDataAccess();

        // GET: api/Login
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Login/5
        public HttpResponseMessage Singin(List<string> scopes)
        {


            string clientId = "6a5c69fc50be4f11996e54d18ce95843";
            string clientSecret = "60822879f8a64ccca934974909daa0bd";
            string redirectUri = "http://localhost/Rocolapp/callback";
            string scope = string.Empty;

            scopes.ForEach(item => scope += item + "%20");

            #region borrar
            //foreach (string item in scopes)
            //{
            //    if (item.Selected)
            //        scope += item + "%20";
            //}
            #endregion
            scope = scope.Substring(0, scope.Length - 3);

            // save the values for later, these would normally be stored in your web config in this type of project
            #region guardarenbase?
            //Session["clientid"] = clientId;
            //Session["clientsecret"] = clientSecret;
            //Session["redirectUri"] = redirectUri;
            //Session["scope"] = scope;
            #endregion

            // redirect to spotify to authenticate


            //Response.Redirect("https://accounts.spotify.com/authorize/?" +
            //    "client_id=" + clientId +
            //    "&response_type=code" +
            //    "&redirect_uri=" + redirectUri +
            //    "&scope=" + scope);

            var response = Request.CreateResponse(HttpStatusCode.Moved);

            response.Headers.Location = new Uri("https://accounts.spotify.com/authorize/?" +
                "client_id=" + clientId +
                "&response_type=code" +
                "&redirect_uri=" + redirectUri +
                "&scope=" + scope
                );

            return response;
        }

        //public async Task<AuthenticationToken> GetAccessToken()
        //{
        //    RoclappData data = DataAccess.GetRocolappData();

        //    SpotifyWebAPI.Authentication.ClientId = data.ClientId;
        //    SpotifyWebAPI.Authentication.ClientSecret = data.ClientSecret ;
        //    SpotifyWebAPI.Authentication.RedirectUri = data.RedirectUri;

        //    // before you can access an authenticated method, you'll need to retrieve an access token
        //    // this token must be passed to each method that requires authentication
        //    // also, im storing this in the view state so i can retrieve it again later
        //   AuthenticationToken authenticationToken = await SpotifyWebAPI.Authentication.GetAccessToken(data.Code);

        //    return authenticationToken;
        //}

        public async void GetAccessToken()
        {

            RoclappData data = DataAccess.GetRocolappData();

            //var auth = new ClientCredentialsAuth()
            //{
            //    //Your client Id
            //    ClientId = data.ClientId,
            //    //Your client secret UNSECURE!!
            //    ClientSecret = data.ClientSecret,               
            //    //How many permissions we need?
            //    Scope = Scope.UserReadPrivate,
            //};

            //Token token = auth.DoAuth();

            var spotify = new SpotifyWebAPI()
            {
                TokenType = "Bearer",
                AccessToken = "BQAhqScodO_NRSiu1V4S8eeeEuLZK-Y8CWahzAQ9GmuS14K6wATxn_jTjCgmMF62BJ9vOXnpkmp2aVwxJ5FJ-w",
                UseAuth = true
            };

            FullTrack track = spotify.GetTrack("3Hvu1pq89D4R0lyPBoujSv");

        }

        //[HttpGet]
        //public async Task<HttpResponseMessage> AddTrack(List<string> trackIds)
        //{
        //    var client = new HttpClient();
        //    PubUser usr = DataAccess.GetPubUserData();
        //    string path = string.Format("https://api.spotify.com/v1/users/{0}/playlists/{1}/tracks", usr.Id, usr.RocolappPlaylistId);


        //    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", usr.Token);
        //    HttpResponseMessage response = await client.PostAsJsonAsync(path, trackIds);

        //    return response;
        //}

        [HttpGet]
        public async void FindTrack([FromBody] string name)
        {
            //var trackpage = await SpotifyWebAPI.Track.Search(name);

            SpotifyWebAPI _spotify;


            //var output = await SpotifyWebAPI.Track.Search("Ties that bind", "Blackbird", "Alter Bridge");

            _spotify = new SpotifyWebAPI()
            {
                AccessToken = "BQAIWrLtmpTL-qVluLFqCcIxSj_YF0kxMnMkxWUb1ZuBKh7IYKqIoW7mDmZR2Fw1kT_NqgSvoQuq7ZM8TTPscQ"
            };

            FullTrack track = _spotify.GetTrack("3Hvu1pq89D4R0lyPBoujSv");

            var a = "asdf";
        }

        [HttpPost]
        public async void AddTrack()
        {
            string trackUri = "1ri6UZpjPLmTCswIXZ6Uq1";

            RoclappData data = DataAccess.GetRocolappData();


            var spotify = new SpotifyWebAPI()
            {
                TokenType = "Bearer",
                AccessToken = "BQDHN3zZDp36gkpGfuWlyJyxdBYkWDSmTNobRvL_eGFMA-0mUWhhThFXioKJwMfOGaCO3xmnwUOoatL5RfOd29zNex3LFVq2cad01NfdK93TWlVTX9PpM3m9U6mdvQwltMdtIYNmHd4KTENqotEyBLE2wX8SQxrycx1z7lFRy52V9PagVECMgq-m8CA5d2FQcN1QFrc6YxALvG-nqGe4VjrScTBVVl8",
                UseAuth = true
            };

           

            string trackPrefix = "spotify:track:";

            ErrorResponse response  = spotify.AddPlaylistTrack(data.UserId, data.MainPlaylist, trackPrefix + trackUri);
           

        }

        [HttpPost]
        public void AddTrackToPlayList([FromBody]Track track)
        {
            RoclappData data = DataAccess.GetRocolappData();

            string token;

            RocolappUser user = GetUserbyRocolappId(track.Token);
            token = user.Token;

            var spotify = new SpotifyWebAPI()
            {
                TokenType = "Bearer",
                AccessToken = user.Token,
                UseAuth = true,
            };
            //Agregar la posibilidad de que se aparezca la letra de la cancion



            string trackPrefix = "spotify:track:";


            ErrorResponse response = spotify.AddPlaylistTrack(user.SpotifyId, user.PlaylistId, trackPrefix + track.TrackId);


            if (response.HasError() && response.Error.Status == 401)
            {
                AutorizationCodeAuth auth = new AutorizationCodeAuth();
                //Datos de mi aplicacion Rocolapp
                auth.ClientId = DataAccess.GetRocolappData().ClientId;
                auth.RedirectUri = DataAccess.GetRocolappData().RedirectUri;
                string clientSecret = DataAccess.GetRocolappData().ClientSecret;

                Token newToken = auth.RefreshToken(user.RefreshToken, DataAccess.GetRocolappData().ClientSecret);
                

                UpdateToken(user.Id.ToString(), newToken.AccessToken);

                token = newToken.AccessToken;

                var withRefreshedToken = new SpotifyWebAPI()
                {
                    TokenType = "Bearer",
                    AccessToken = newToken.AccessToken,
                    UseAuth = true
                };

                response = withRefreshedToken.AddPlaylistTrack(user.SpotifyId, user.PlaylistId, trackPrefix + track.TrackId);
            }


            PlaybackContext context = GetCurrentPlayBack(token);

            if (context!=null && !context.IsPlaying)
            {
                try
                {
                    ResumePlayback(token);
                }
                catch (Exception)
                {
                    throw;
                }
                
            }

        }

        private ErrorResponse ResumePlayback(string token)
        {
          

            var spotify = new SpotifyWebAPI()
            {
                TokenType = "Bearer",
                AccessToken = token,
                UseAuth = true
            };

            ErrorResponse error = spotify.ResumePlayback();

            return error;
        }


        private PlaybackContext GetCurrentPlayBack(string token)
        {
            RoclappData data = DataAccess.GetRocolappData();          

            var spotify = new SpotifyWebAPI()
            {
                TokenType = "Bearer",
                AccessToken = token,
                UseAuth = true
            };

            PlaybackContext context = spotify.GetPlayingTrack();

            return context;
        }

        [HttpGet]
        public async Task<SearchItem> SearchTrack(string query,string tk)
        {

            RoclappData data = DataAccess.GetRocolappData();

            RocolappUser user = GetUserbyRocolappId(tk);

            var spotify = new SpotifyWebAPI()
            {
                TokenType = "Bearer",
                AccessToken = user.Token,
                UseAuth = true
            };

            SearchItem searchItem = spotify.SearchItems(query, SearchType.Track);

            if (searchItem.Error != null && searchItem.Error.Status == 401)
            {
                AutorizationCodeAuth auth = new AutorizationCodeAuth();
                //Datos de mi aplicacion Rocolapp
                auth.ClientId = DataAccess.GetRocolappData().ClientId;
                auth.RedirectUri = DataAccess.GetRocolappData().RedirectUri;
                string clientSecret = DataAccess.GetRocolappData().ClientSecret;

                Token token = auth.RefreshToken(user.RefreshToken, DataAccess.GetRocolappData().ClientSecret);

                UpdateToken(user.Id.ToString(), token.AccessToken);

                var withRefreshedToken = new SpotifyWebAPI()
                {
                    TokenType = "Bearer",
                    AccessToken = token.AccessToken,
                    UseAuth = true
                };

                searchItem = withRefreshedToken.SearchItems(query, SearchType.Track);
            }

            return searchItem;

        }

        private RocolappUser GetUserbyRocolappId(string id)
        {
            var user = dataAccess.GetUserbyRocolappId(id);

            return user;
        }


        private RocolappUser UpdateToken(string id, string token)
        {
            var user = dataAccess.UpdateToken(id, token);

            return user;
        }


    }
}
