using System.Windows.Input;

using GalaSoft.MvvmLight.Command;

using Lands.Views;

using Xamarin.Forms;

namespace Lands.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        #region Properties
        public string Email
        {
            get => this.email;
            set => SetValue(ref this.email, value);
        }

        public string Password
        {
            get => this.password;
            set => SetValue(ref this.password, value);
        }

        public bool IsRunning
        {
            get => this.isRunning;
            set => SetValue(ref this.isRunning, value);
        }

        public bool IsRemembered { get; set; }

        public bool IsEnabled
        {
            get => this.isEnabled;
            set => SetValue(ref this.isEnabled, value);
        }

        public ICommand LoginCommand => new RelayCommand(Login);
        #endregion

        #region Attributes
        private string password;
        private bool isRunning;
        private bool isEnabled;
        private string email;
        #endregion

        #region Methods
        private async void Login()
        {
            if (string.IsNullOrEmpty(Email))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "You must enter an email", "Accept");
                return;
            }
            if (string.IsNullOrEmpty(Password))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "You must enter an password", "Accept");
                return;
            }

            MainViewModel.GetInstance().Lands = new LandsViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new LandsPage());
        }
        #endregion

        #region Constructors
        public LoginViewModel()
        {
            this.IsRemembered = true;
            this.isEnabled = true;

        }
        #endregion
    }
}

