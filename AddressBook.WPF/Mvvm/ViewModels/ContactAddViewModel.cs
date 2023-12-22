using AddressBook.Shared.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;


namespace AddressBook.WPF.Mvvm.ViewModels
{
    public partial class ContactAddViewModel : ObservableObject
    {

        [ObservableProperty]
        public Contacts _contactForm = new("firstname", "lastname", "email", "phonenumber", "address", "city", "postalcode");

        [ObservableProperty]
        public ObservableCollection<Contacts> _contacts = new ObservableCollection<Contacts>();

        private readonly IServiceProvider _sp;

        public ContactAddViewModel(IServiceProvider sp)
        {
            _sp = sp;
        }

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
