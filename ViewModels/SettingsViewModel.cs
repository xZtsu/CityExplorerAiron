using CityExplorerAiron.Services;
using System.Windows.Input;

namespace CityExplorerAiron.ViewModels;

public class SettingsViewModel : BaseViewModel
{
    public ICommand ChangeLanguageCommand { get; }

    public SettingsViewModel()
    {

        ChangeLanguageCommand = new Command<string>((code) =>
        {
            LanguageService.ChangeLanguage(code);
        });
    }
}