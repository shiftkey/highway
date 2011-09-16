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
                    OnPropertyChanged("Image");
                }
            }

        }
    }
}
