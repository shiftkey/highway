using System;
using System.Linq;
using Highway.SampleData;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace Highway
{
    partial class App
    {
        private static IRepository _sampleData;

        public App()
        {
            InitializeComponent();
        }

        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            ShowSplit(null);
            Window.Current.Activate();
        }

        public static void ShowCollection()
        {
            var page = new CollectionPage();

            if (_sampleData == null) 
                _sampleData = new SampleRepository(page.BaseUri);

            if (!_sampleData.IsAuthenticated)
                _sampleData.Authenticate();
            
            page.Items = _sampleData.GetCollaborator("").Repositories;
            Window.Current.Content = page;
        }

        public static void ShowSplit(IGroupInfo collection)
        {
            var page = new SplitPage();
            if (_sampleData == null)
                _sampleData = new SampleRepository(page.BaseUri);

            if (!_sampleData.IsAuthenticated)
                _sampleData.Authenticate();
            
            if (collection == null) 
                collection = _sampleData.GetCollaborator("");

            page.Items = collection;
            page.Context = collection.Key;
            Window.Current.Content = page;
        }
    }
}
