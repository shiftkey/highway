using Windows.UI.Xaml.Data;

namespace Highway.Models
{
    public class Collaborator : INotifyPropertyChanged
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

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
