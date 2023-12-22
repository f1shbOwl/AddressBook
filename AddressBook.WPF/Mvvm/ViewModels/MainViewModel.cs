using AddressBook.Shared.Interfaces;
using AddressBook.Shared.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace AddressBook.WPF.Mvvm.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableObject? _currentViewModel;

        private readonly IServiceProvider _sp;

        public MainViewModel(IServiceProvider sp) 
        {
            _sp = sp;
            CurrentViewModel = _sp.GetRequiredService<ContactListViewModel>();
        }

        
    }  
}
