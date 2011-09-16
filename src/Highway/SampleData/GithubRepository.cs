using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Highway.Models;
using Windows.UI.Xaml.Media;

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
    }

    public class GithubSampleRepository : IRepository
    {
        private Uri _baseUrl;

        public GithubSampleRepository(Uri baseUrl)
        {
            _baseUrl = baseUrl;
        }

        public Collaborator GetCollaborator(string user)
        {
            var repositories = new ObservableCollection<Repository>() { 
                new Repository() { Name = "blog", ImageUri = new Uri(_baseUrl, "Images/github-logo.png") },
                new Repository() { Name = "Highway" , ImageUri = new Uri(_baseUrl, "Images/github-logo.png") },
                new Repository() { Name = "RestSharp" , ImageUri = new Uri(_baseUrl, "Images/github-logo.png") },
                new Repository() { Name = "NSubstitute" , ImageUri = new Uri(_baseUrl, "Images/github-logo.png") },
                new Repository() { Name = "LastThursday" , ImageUri = new Uri(_baseUrl, "Images/github-logo.png") },
                new Repository() { Name = "Castle.Core" , ImageUri = new Uri(_baseUrl, "Images/github-logo.png") },
                new Repository() { Name = "IOCComparison" , ImageUri = new Uri(_baseUrl, "Images/github-logo.png") },
                new Repository() { Name = "NAppUpdate" , ImageUri = new Uri(_baseUrl, "Images/github-logo.png") },
                new Repository() { Name = "configatron" , ImageUri = new Uri(_baseUrl, "Images/github-logo.png") },
                new Repository() { Name = "Albacore" , ImageUri = new Uri(_baseUrl, "Images/github-logo.png") },
                new Repository() { Name = "rhino-mocks" , ImageUri = new Uri(_baseUrl, "Images/github-logo.png") },
            };

            return new Collaborator() { Repositories = repositories };
        }

        public IEnumerable<Commit> GetCommitHistory(Repository repo)
        {
            return new List<Commit>();
        }
    }
}
