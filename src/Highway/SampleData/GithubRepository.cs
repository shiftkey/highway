using System;
using System.Collections.Generic;
using Highway.Models;
using Windows.Security.Authentication.Web;

namespace Highway.SampleData
{
    public class GithubRepository : IRepository
    {
        public GithubRepository()
        {

        }

        public Collaborator GetCollaborator(string user)
        {
            return new Collaborator();
        }

        public IEnumerable<Commit> GetCommitHistory(Repository repo)
        {
            return new List<Commit>();
        }



        public async void Authenticate()
        {
            var uri = new Uri("https://github.com/login/oauth/authorize?client_id=");

            var response = await WebAuthenticationBroker.AuthenticateAsync(WebAuthenticationOptions.Default, uri);

            if (response.ResponseStatus != WebAuthenticationStatus.Success)
            {
                // oops
            }
            else
            {
                var text = response.ResponseData;
                var settings = Windows.Storage.ApplicationData.Current.RoamingSettings;
                var container = settings.CreateContainer("settings", Windows.Storage.ApplicationDataCreateDisposition.Always);
                if (!container.Containers.ContainsKey("key"))
                {
                    container.Values.Add("key", text);
                }
                else
                {
                    container.Values["key"] = text;
                }
            }
        }


        public bool IsAuthenticated
        {
            get { throw new NotImplementedException(); }
        }
    }

    
}
