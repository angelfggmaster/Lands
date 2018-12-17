using Lands.Interfaces;
using Lands.Resources;
using Xamarin.Forms;

namespace Lands.Helpers
{
    public class Languages
    {
        static Languages()
        {
            var ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
            Resource.Culture = ci;
            DependencyService.Get<ILocalize>().SetLocale(ci);
        }

        public static string Accept => Resource.Accept;

        public static string EmailValidation => Resource.EmailValidation;

        public static string Error => Resource.Error;

        public static string EmailPlaceHolder => Resource.EmailPlaceHolder;

        public static string Rememberme => Resource.Rememberme;
    }
}
