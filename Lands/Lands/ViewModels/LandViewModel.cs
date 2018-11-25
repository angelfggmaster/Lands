using Lands.Models;

namespace Lands.ViewModels
{
    public class LandViewModel
    {
        public Land Land { get; set; }

        public LandViewModel(Land land)
        {
            this.Land = land;
        }
    }
}
