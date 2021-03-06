﻿using System.Collections.ObjectModel;
using Windows.UI.Xaml.Data;

namespace Highway.Models
{
    public class Collaborator : PropertyChangedBase, IGroupInfo
    {
        //    "owner": {
        //      "login": "octocat",
        //      "id": 1,
        //      "avatar_url": "https://github.com/images/error/octocat_happy.gif",
        //      "url": "https://api.github.com/users/octocat"
        //    },

        public Collaborator()
        {
            Repositories = new ObservableCollection<Repository>();
        }

        public int Id { get; set; }
        public string Login { get; set; }
        public string AvatarUrl { get; set; }
        public string Url { get; set; }

        public ObservableCollection<Repository> Repositories { get; set; }

        public object Key
        {
            get { return this; }
        }

        public System.Collections.Generic.IEnumerator<object> GetEnumerator()
        {
            return Repositories.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
