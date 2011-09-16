using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Highway.Models;

namespace Highway.SampleData
{
    public interface IRepository
    {
        IEnumerable<Commit> GetCommitHistory(Repository repo);

        Collaborator GetCollaborator(string name);
    }
}
