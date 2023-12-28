using AddressBook.Shared.Models;
using AddressBook.Shared.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;

namespace AddressBook.WPF.Mvvm.ViewModels
{
    public partial class EditContactViewModel : ObservableObject
    {
        private readonly IServiceProvider _sp;
        private readonly ContactService _contactService;

        public EditContactViewModel(IServiceProvider sp, ContactService contactService)
        {
            _sp = sp;
            _contactService = contactService;

            contact = _contactService.SelectedContact;
        }




        [ObservableProperty]
        private Contacts contact = new();




        [RelayCommand]
        private void Update()
        {
            _contactService.Update(Contact);

            var mainViewModel = _sp.GetRequiredService<MainViewModel>();
            mainViewModel.CurrentViewModel = _sp.GetRequiredService<ContactListViewModel>();
        }

        [RelayCommand]
        private void NavigateToMainMenuView()
        {
            var mainViewModel = _sp.GetRequiredService<MainViewModel>();
            mainViewModel.CurrentViewModel = _sp.GetService<MainMenuViewModel>();
        }


        [RelayCommand]
        private void NavigateToListView()
        {
            var mainViewModel = _sp.GetRequiredService<MainViewModel>();
            mainViewModel.CurrentViewModel = _sp.GetService<ContactListViewModel>();
        }
    }
}
