using Highway.SampleData;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace Highway
{
    partial class App
    {
        private static IRepository _repository;

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

            if (_repository == null)
                // _repository = new GithubRepository(); 
                _repository = new SampleRepository(page.BaseUri);

            if (!_repository.IsAuthenticated)
                _repository.Authenticate();
            
            page.Items = _repository.GetCollaborator("").Repositories;
            Window.Current.Content = page;
        }

        public static void ShowSplit(IGroupInfo collection)
        {
            var page = new SplitPage();
            if (_repository == null)
                // _repository = new GithubRepository(); 
                _repository = new SampleRepository(page.BaseUri);

            if (!_repository.IsAuthenticated)
                _repository.Authenticate();
            
            if (collection == null) 
                collection = _repository.GetCollaborator("");

            page.Items = collection;
            page.Context = collection.Key;
            Window.Current.Content = page;
        }
    }
}
