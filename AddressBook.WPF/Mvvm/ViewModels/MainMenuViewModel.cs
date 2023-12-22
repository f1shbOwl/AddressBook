using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.WPF.Mvvm.ViewModels
{
    internal partial class MainMenuViewModel : ObservableObject
    {
        private readonly IServiceProvider _sp;

        public MainMenuViewModel(IServiceProvider sp)
        {
            _sp = sp;

        }

        [RelayCommand]
        private void NavigateToAddView()
        {
            var mainViewModel = _sp.GetRequiredService<MainViewModel>();
            mainViewModel.CurrentViewModel = _sp.GetService<ContactAddViewModel>();
        }


        [RelayCommand]
        private void NavigateToListView()
        {
            var mainViewModel = _sp.GetRequiredService<MainViewModel>();
            mainViewModel.CurrentViewModel = _sp.GetService<ContactListViewModel>();
        }

    }
}
