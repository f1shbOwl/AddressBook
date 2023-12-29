using AddressBook.Shared.Models;
using AddressBook.Shared.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;
using System.Diagnostics;


namespace AddressBook.WPF.Mvvm.ViewModels
{
    public partial class DeleteContactViewModel : ObservableObject
    {
        private readonly IServiceProvider _sp;
        private readonly ContactService _contactService;
        

        public DeleteContactViewModel(IServiceProvider sp, ContactService contactService)
        {
            _sp = sp;
            _contactService = contactService;

            Contact = _contactService.SelectedContact;
        }


        public string ConfirmationEmail { get; set; } = null!;
        
        [ObservableProperty]
        private Contacts contact = new();








        /// <summary>
        /// Delete contact by by confirming contact email
        /// </summary>
        /// <param name="contacts"></param>

        [RelayCommand]
        private void ConfirmDeleteContact(Contacts contacts)
        {
            try
            {
                _contactService.RemoveContactInWpf(ConfirmationEmail);

                var mainViewModel = _sp.GetRequiredService<MainViewModel>();
                mainViewModel.CurrentViewModel = _sp.GetService<ContactListViewModel>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Cancel delete and go back to List View.
        /// </summary>

        [RelayCommand]
        public void CancelDelete()
        {

            var mainViewModel = _sp.GetRequiredService<MainViewModel>();
            mainViewModel.CurrentViewModel = _sp.GetService<ContactListViewModel>();
        }

    }
}
