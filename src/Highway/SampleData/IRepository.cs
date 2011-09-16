using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Highway.Models;

namespace Highway.SampleData
{
    public interface IRepository
    {
        IEnumerable<Repository> GetRepositories(string user);

        IEnumerable<Commit> GetCommitHistory(Repository repo);
    }
}
