using AddressBook.Shared.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;

namespace AddressBook.WPF.Mvvm.ViewModels;

internal partial class ContactListViewModel : ObservableObject
{

    /// <summary>
    /// För att komma åt dependency injection.
    /// </summary>
    private readonly IServiceProvider _sp;

    public ContactListViewModel(IServiceProvider sp)
    {
        _sp = sp;
    }


    [ObservableProperty]
    private ObservableCollection<ContactService> _contacts = [];



    /// <summary>
    /// För att komma åt dependency injection - så att navigering fungerar mellan views.
    /// </summary>
    [RelayCommand]
    private void NavigateToAddView()
    {
        var mainViewModel = _sp.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _sp.GetService<ContactAddViewModel>();
    }

    [RelayCommand]

    private void NavigateToMainMenuView()
    {
        var mainViewModel = _sp.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _sp.GetRequiredService<MainMenuViewModel>();
    }
}
