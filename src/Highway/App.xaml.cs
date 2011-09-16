using Expression.Blend.SampleData.SampleDataSource;
using System;
using System.Linq;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
using Highway.SampleData;

namespace Highway
{
    partial class App
    {
        private static GithubRepository _sampleData;

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
                _sampleData = new GithubRepository(page.BaseUri);

            page.Items = _sampleData.GetRepositories("").Select((obj) => (Object)obj);
            Window.Current.Content = page;
        }

        public static void ShowSplit(IGroupInfo collection)
        {
            var page = new SplitPage();
            if (_sampleData == null)
                _sampleData = new GithubRepository(page.BaseUri);

            if (collection == null) 
                collection = _sampleData.GetRepositories("").First();

            page.Items = collection;
            page.Context = collection.Key;
            Window.Current.Content = page;
        }
    }
}
