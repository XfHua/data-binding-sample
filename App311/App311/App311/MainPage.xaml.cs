using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace App311
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        MasterPostsViewModel ViewModel;

        protected override void OnAppearing()
        {
            base.OnAppearing();

            BindingContext = ViewModel = new MasterPostsViewModel(Navigation);

        }
    }

    class MasterPostsViewModel 
    {
        public PostViewModel postViewModel { get; set; }

        public MasterPostsViewModel(INavigation navigation)
        {
            postViewModel = new PostViewModel();
        }

    }

    class PostViewModel : INotifyPropertyChanged
    {
        string _selectedPhoto;

        public ICommand NewCommand { private set; get; }

        public event PropertyChangedEventHandler PropertyChanged;

        public PostViewModel()
        {
            SelectedPhoto = "default text";
            NewCommand = new Command(TakePicture);
        }

        private void TakePicture()
        {
            SelectedPhoto = "test text After click button";
        }

        public string SelectedPhoto
        {
            set
            {
                if (_selectedPhoto != value)
                {
                    _selectedPhoto = value;

                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("SelectedPhoto"));
                    }
                }
            }
            get
            {
                return _selectedPhoto;
            }
        }
    }
}
