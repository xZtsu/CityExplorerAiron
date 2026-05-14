using CityExplorerAiron.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CityExplorerAiron
{
    public partial class App : Application
    {
        public App(IServiceProvider serviceProvider)
        {
            InitializeComponent();

            var mainPage = serviceProvider.GetService<Views.MainTabbedPage>();
            var savedLang = Preferences.Get("AppLanguage", "et");
            LanguageService.ChangeLanguage(savedLang);

            MainPage = mainPage;
        }


    }
}