using System.Globalization;
using CityExplorerAiron.Resources.Strings;

namespace CityExplorerAiron.Services
{
    public static class LanguageService
    {
        public static event Action? LanguageChanged;

        public static void ChangeLanguage(string languageCode)
        {
            // TEST: Application.Current.MainPage.DisplayAlert("Debug", $"Valiti keel: {languageCode}", "OK");

            var culture = new CultureInfo(languageCode);
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;
            CityExplorerAiron.Resources.Strings.AppResources.Culture = culture;

            LanguageChanged?.Invoke(); // See rida ütleb MainTabbedPage-le: "Uuenda end!"
        }
    }
}