using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Expression.Blend.SampleData.SampleDataSource;
using Highway.SampleData;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace Highway.Models
{
    public class Repository : INotifyPropertyChanged, IGroupInfo
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        //        [
        //  {
        //    "url": "https://api.github.com/repos/octocat/Hello-World",
        //    "html_url": "https://github.com/octocat/Hello-World",
        //    "clone_url": "https://github.com/octocat/Hello-World.git",
        //    "git_url": "git://github.com/octocat/Hello-World.git",
        //    "ssh_url": "git@github.com:octocat/Hello-World.git",
        //    "svn_url": "https://svn.github.com/octocat/Hello-World",
        //    "owner": {
        //      "login": "octocat",
        //      "id": 1,
        //      "avatar_url": "https://github.com/images/error/octocat_happy.gif",
        //      "url": "https://api.github.com/users/octocat"
        //    },
        //    "name": "Hello-World",
        //    "description": "This your first repo!",
        //    "homepage": "https://github.com",
        //    "language": null,
        //    "private": false,
        //    "fork": false,
        //    "forks": 9,
        //    "watchers": 80,
        //    "size": 108,
        //    "master_branch": "master",
        //    "open_issues": 0,
        //    "pushed_at": "2011-01-26T19:06:43Z",
        //    "created_at": "2011-01-26T19:01:12Z"
        //  }
        //]

        public string Name { get; set; }
        public string Description { get; set; }
        public string HomePage { get; set; }
        public string CreatedAt { get; set; }
        public string PushedAt { get; set; }
        public int Forks { get; set; }
        public int Watchers { get; set; }
        public bool IsFork { get; set; }
        public Collaborator Owner { get; set; }

        private ImageSource _image = null;
        private Uri _imageBaseUri = null;
        private String _imagePath = null;
        public ImageSource Image
        {
            get
            {
                if (_image == null && _imageBaseUri != null && _imagePath != null)
                {
                    _image = new BitmapImage(new Uri(_imageBaseUri, _imagePath));
                }
                return _image;
            }

            set
            {
                if (_image != value)
                {
                    _image = value;
                    _imageBaseUri = null;
                    _imagePath = null;
                    OnPropertyChanged("Image");
                }
            }
        }

        public void SetImage(Uri baseUri, String path)
        {
            _image = null;
            _imageBaseUri = baseUri;
            _imagePath = path;
            OnPropertyChanged("Image");
        }

        public object Key
        {
            get { return this; }
        }

        public IEnumerator<object> GetEnumerator()
        {
            return null;   
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
