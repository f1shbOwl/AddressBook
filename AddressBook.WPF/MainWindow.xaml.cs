using System.Windows;
using AddressBook.WPF.Mvvm.ViewModels;

namespace AddressBook.WPF
{
    public partial class MainWindow : Window
    {
        public MainWindow(MainViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }

    }
}