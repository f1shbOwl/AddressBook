using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;

namespace AddressBook.WPF.Mvvm.ViewModels
{
    public partial class EditContactViewModel : ObservableObject
    {
        private readonly IServiceProvider _sp;

        public EditContactViewModel(IServiceProvider sp)
        {
            _sp = sp;

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
