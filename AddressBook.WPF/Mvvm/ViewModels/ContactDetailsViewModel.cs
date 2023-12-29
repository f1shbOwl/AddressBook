using AddressBook.Shared.Interfaces;
using AddressBook.Shared.Models;
using AddressBook.Shared.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;


namespace AddressBook.WPF.Mvvm.ViewModels;

public partial class ContactDetailsViewModel : ObservableObject
{
    private readonly IServiceProvider _sp;
    private readonly ContactService _contactService;

    public ContactDetailsViewModel(IServiceProvider sp, ContactService contactService)
    {
        _sp = sp;
        _contactService = contactService;


        Contact = _contactService.SelectedContact;
        
    }




    [ObservableProperty]
    private Contacts contact = new();


    /// <summary>
    /// Får inte den här knappen att fungera som jag vill
    /// </summary>
    /// <param name="contacts"></param>
    [RelayCommand]
    private void NavigateToDeleteContactView()
    {

        var mainViewModel = _sp.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _sp.GetService<DeleteContactViewModel>();
    }

    /// <summary>
    /// Får inte den här knappen att fungera som jag vill
    /// </summary>
    /// <param name="contacts"></param>
    [RelayCommand]
    private void NavigateToEditContactView()
    {

        var mainViewModel = _sp.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _sp.GetService<EditContactViewModel>();
    }

    [RelayCommand]
    private void NavigateToListView()
    {
        var mainViewModel = _sp.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _sp.GetService<ContactListViewModel>();
    }

    [RelayCommand]

    private void NavigateToMainMenuView()
    {
        var mainViewModel = _sp.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _sp.GetRequiredService<MainMenuViewModel>();
    }
}
