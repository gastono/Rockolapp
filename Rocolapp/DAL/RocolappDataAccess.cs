using Rocolapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rocolapp.DAL
{
    public class RocolappDataAccess
    {
        private RocolappContext context = new RocolappContext();


        public int SaveRocolapUserData(RocolappUser rocolappUser)
        {
            try
            {
                context.RocolappUsers.Add(rocolappUser);
                var id = context.SaveChanges();

                return id;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public bool CheckIfUserExists(string spotifyId)
        {
            try
            {
              
                var result = context.RocolappUsers.Where(x => x.SpotifyId.Equals(spotifyId)).Any();

                return result;
                
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public RocolappUser GetUserbyRocolappId(string id)
        {
            try
            {
                var result = context.RocolappUsers.First(x => x.Id.ToString().Equals(id));

                return result;

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public RocolappUser GetUser(string spotifyId)
        {
            try
            {
                var result = context.RocolappUsers.Where(x => x.SpotifyId.Equals(spotifyId)).FirstOrDefault();

                return result;

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public RocolappUser UpdateToken(string rocolappId, string token)
        {
            try
            {
                var result = context.RocolappUsers.First(x => x.Id.ToString().Equals(rocolappId));

                result.Token = token;

                context.SaveChanges();

                return result;

            }
            catch (Exception e)
            {

                throw e;
            }

        }


    }
}