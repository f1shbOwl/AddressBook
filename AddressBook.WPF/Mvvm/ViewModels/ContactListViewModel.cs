using AddressBook.Shared.Interfaces;
using AddressBook.Shared.Models;
using AddressBook.Shared.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;

namespace AddressBook.WPF.Mvvm.ViewModels;

internal partial class ContactListViewModel : ObservableObject
{
    private readonly ContactService _contactService;

    /// <summary>
    /// För att komma åt dependency injection.
    /// </summary>
    private readonly IServiceProvider _sp;




    public ContactListViewModel(IServiceProvider sp, ContactService contactService)
    {
        _sp = sp;
        _contactService = contactService;

        Contacts = new ObservableCollection<Contacts>(_contactService.GetContactFromList());

    }


    [ObservableProperty]
    private ObservableCollection<Contacts> _contacts = new ObservableCollection<Contacts>();


    









    [RelayCommand]
    public void RemoveContact(Contacts contact) 
    {
        _contactService.RemoveContact(contact);
        Contacts = new ObservableCollection<Contacts>(_contactService.GetContactFromList());

    }


    /// <summary>
    ///  Navigering mellan views.
    /// </summary>
    ///
    [RelayCommand]
    private void NavigateToDetailsView(Contacts contacts)
    {
        _contactService.SelectedContact = contacts;


        var mainViewModel = _sp.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _sp.GetService<ContactDetailsViewModel>();
    }

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
