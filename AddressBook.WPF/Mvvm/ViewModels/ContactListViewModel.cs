using AddressBook.Shared.Models;
using AddressBook.Shared.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;

namespace AddressBook.WPF.Mvvm.ViewModels;

public partial class ContactListViewModel : ObservableObject
{
    private readonly ContactService _contactService;

    private readonly IServiceProvider _sp;




    public ContactListViewModel(IServiceProvider sp, ContactService contactService)
    {
        _sp = sp;
        _contactService = contactService;

        Contacts = new ObservableCollection<Contacts>(_contactService.GetContactFromList());

    }


    [ObservableProperty]
    private ObservableCollection<Contacts> _contacts = new ObservableCollection<Contacts>();




    /// <summary>
    ///  Navigering mellan views.
    /// </summary>
    ///


    [RelayCommand]
    private void NavigateToDeleteContactView(Contacts contacts)
    {
        _contactService.SelectedContact = contacts;

        var mainViewModel = _sp.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _sp.GetService<DeleteContactViewModel>();
    }

    [RelayCommand]
    private void NavigateToEditContactView(Contacts contacts)
    {
        _contactService.SelectedContact = contacts;

        var mainViewModel = _sp.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _sp.GetService<EditContactViewModel>();
    }

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
