using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Highway.Models;

namespace Highway.SampleData
{
    public interface IRepository
    {
        void Authenticate();

        bool IsAuthenticated { get; }

        IEnumerable<Commit> GetCommitHistory(Repository repo);

        Collaborator GetCollaborator(string name);
    }
}
