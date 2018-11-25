namespace Lands.ViewModels
{
    public class MainViewModel
    {
        public LoginViewModel Login { get; set; }
        public LandsViewModel Lands { get; set; }
        public LandViewModel Land { get; set; }

        private static MainViewModel instance;

        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                return new MainViewModel();
            }

            return instance;
        }

        public MainViewModel()
        {
            instance = this;
            this.Login = new LoginViewModel();
        }
    }
}
