using GalaSoft.MvvmLight.Command;
using System.Windows.Input;
using Xamarin.Forms;
using System.ComponentModel;

namespace Lands.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public bool IsRunning { get; set; }

        public bool IsRemembered { get; set; }

        public bool IsEnabled { get; set; }

        public ICommand LoginCommand => new RelayCommand(Login);

        public event PropertyChangedEventHandler PropertyChanged;

        private string password;
        private bool isRunning;
        private bool isEnabled;

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
        }

        public LoginViewModel()
        {
            IsRemembered = true;
        }
    }
}

