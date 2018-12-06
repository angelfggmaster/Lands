using System.Collections.Generic;

using Lands.Models;

namespace Lands.ViewModels
{
    public class MainViewModel
    {

        #region Properties
        public List<Land> LandsList { get; set; }
        #endregion

        #region ViewModels
        public LoginViewModel Login { get; set; }
        public LandsViewModel Lands { get; set; }
        public LandViewModel Land { get; set; }
        #endregion

        #region Attributes
        private static MainViewModel instance; 
        #endregion

        #region Methods
        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                return new MainViewModel();
            }

            return instance;
        } 
        #endregion

        #region Constructors
        public MainViewModel()
        {
            instance = this;
            this.Login = new LoginViewModel();
            
        } 
        #endregion
    }
}
