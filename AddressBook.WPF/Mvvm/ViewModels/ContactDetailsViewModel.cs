using AddressBook.Shared.Models;
using AddressBook.Shared.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.WPF.Mvvm.ViewModels
{
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
