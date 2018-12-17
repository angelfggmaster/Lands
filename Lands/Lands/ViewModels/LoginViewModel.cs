using System.Windows.Input;

using GalaSoft.MvvmLight.Command;
using Lands.Services;
using Lands.Views;

using Xamarin.Forms;
using Lands.Helpers;

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

        #region Services
        private ApiService apiService;
        #endregion

        #region Constructors
        public LoginViewModel()
        {
            this.IsRemembered = true;
            this.isEnabled = true;
            this.apiService = new ApiService();

            this.Email = "A";
            this.Password = "a";

        }
        #endregion

        #region Methods
        private async void Login()
        {
            if (string.IsNullOrEmpty(Email))
            {
                await Application.Current.MainPage.DisplayAlert(Languages.Error, Languages.EmailValidation, Languages.Accept);
                return;
            }
            if (string.IsNullOrEmpty(Password))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "You must enter an password", "Accept");
                return;
            }

            //var connection = await this.apiService.CheckConnection();
            //if (!connection.IsSuccess)
            //{
            //    this.IsRunning = false;
            //    this.IsEnabled = true;
            //    await Application.Current.MainPage.DisplayAlert("Error", connection.Message, "Accept");
            //    return;
            //}

            //var token = await this.apiService.GetToken("http://localhost/Lands.Backend", this.Email, this.Password);

            //if (token == null)
            //{
            //    this.IsRunning = false;
            //    this.IsEnabled = true;
            //    await Application.Current.MainPage.DisplayAlert("Error", "Something was wrong, please try later.", "Accept");
            //    return;
            //}

            //if (string.IsNullOrEmpty(token.AccessToken))
            //{
            //    this.IsRunning = false;
            //    this.IsEnabled = true;
            //    await Application.Current.MainPage.DisplayAlert("Error", token.ErrorDescription, "Accept");
            //    this.Password = string.Empty;
            //    return;
            //}

            var mainViewModel = MainViewModel.GetInstance();
            //mainViewModel.Token = token;

            mainViewModel.Lands = new LandsViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new LandsPage());

            this.IsRunning = false;
            this.IsEnabled = true;

            this.Email = string.Empty;
            this.Password = string.Empty;
        }
        #endregion
    }
}

