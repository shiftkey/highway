using System.Collections.ObjectModel;
using Windows.UI.Xaml.Data;

namespace Highway.Models
{
    public class Collaborator : INotifyPropertyChanged, IGroupInfo
    {
        //    "owner": {
        //      "login": "octocat",
        //      "id": 1,
        //      "avatar_url": "https://github.com/images/error/octocat_happy.gif",
        //      "url": "https://api.github.com/users/octocat"
        //    },

        public int Id { get; set; }
        public string Login { get; set; }
        public string AvatarUrl { get; set; }
        public string Url { get; set; }

        public ObservableCollection<Repository> Repositories { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

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
            return Repositories.GetEnumerator();
        }
    }
}
