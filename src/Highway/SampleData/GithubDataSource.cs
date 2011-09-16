using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Highway.Models;

namespace Highway.SampleData
{
    public class GithubRepository : IRepository
    {
        public GithubRepository(Uri baseUrl)
        {

        }

        public IEnumerable<Repository> GetRepositories(string user)
        {
            return new List<Repository>();
        }

        public IEnumerable<Commit> GetCommitHistory(Repository repo)
        {
            return new List<Commit>();
        }
    }
}
