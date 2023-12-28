using AddressBook.Shared.Models;
using AddressBook.Shared.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;


namespace AddressBook.WPF.Mvvm.ViewModels
{
    internal partial class ContactDetailsViewModel : ObservableObject
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


        [ObservableProperty]
        private ObservableCollection<Contacts> _contacts = new ObservableCollection<Contacts>();
        


        [RelayCommand]
        private void NavigateToDeleteContactView(Contacts contacts)
        {
            _contactService.SelectedContact = contacts;

            var mainViewModel = _sp.GetRequiredService<MainViewModel>();
            mainViewModel.CurrentViewModel = _sp.GetService<DeleteContactViewModel>();
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
}
