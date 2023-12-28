using AddressBook.Shared.Interfaces;
using AddressBook.Shared.Models;
using AddressBook.Shared.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;


namespace AddressBook.WPF.Mvvm.ViewModels
{
    public partial class ContactAddViewModel : ObservableObject
    {
        
        /// <summary>
        /// För att komma åt dependency injection.
        /// </summary>
        private readonly IServiceProvider _sp;
        private readonly ContactService _contactService;

        public ContactAddViewModel(IServiceProvider sp, ContactService contactService)
        {
            _sp = sp;
            _contactService = contactService;
        }

        

        [ObservableProperty]
        private Contacts contacts = new Contacts();




        [RelayCommand]
        private void AddContactToList()
        {
            _contactService.AddContactToList(Contacts);

            var mainViewModel = _sp.GetRequiredService<MainViewModel>();
            mainViewModel.CurrentViewModel = _sp.GetRequiredService<ContactListViewModel>();
        }

        
        /// <summary>
        /// För att kunna navigaera mellan vyer.
        /// </summary>
        [RelayCommand]

        private void NavigateToList()
        {
            var mainViewModel = _sp.GetRequiredService<MainViewModel>();
            mainViewModel.CurrentViewModel = _sp.GetRequiredService<ContactListViewModel>();
        }

        [RelayCommand]

        private void NavigateToMainMenuView()
        {
            var mainViewModel = _sp.GetRequiredService<MainViewModel>();
            mainViewModel.CurrentViewModel = _sp.GetRequiredService<MainMenuViewModel>();
        }
    }
}
