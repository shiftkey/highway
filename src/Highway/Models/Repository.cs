using System;
using System.Collections.Generic;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace Highway.Models
{
    public class Repository : INotifyPropertyChanged
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
        public ImageSource Image
        {
            get
            {
                if (_image == null && _imageUri != null)
                {
                    _image = new BitmapImage(_imageUri);
                }
                return _image;
            }

            set
            {
                if (_image != value)
                {
                    _image = value;
                    OnPropertyChanged("Image");
                }
            }
        }

        private Uri _imageUri;
        public Uri ImageUri
        {
            get { return _imageUri; }
            set
            {
                if (_imageUri != value)
                {
                    _imageUri = value;
                    Image = null;
                    OnPropertyChanged("ImageUri");
                }
            }

        }
    }
}
