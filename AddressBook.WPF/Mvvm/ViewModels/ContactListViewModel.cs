using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;

namespace AddressBook.WPF.Mvvm.ViewModels;

internal partial class ContactListViewModel : ObservableObject
{

    private readonly IServiceProvider _sp;

    public ContactListViewModel(IServiceProvider sp)
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

    private void NavigateToMain()
    {
        var mainViewModel = _sp.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _sp.GetRequiredService<MainViewModel>();
    }
}
