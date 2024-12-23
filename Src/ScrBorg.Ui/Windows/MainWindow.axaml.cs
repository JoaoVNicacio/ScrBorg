
using ScrBorg.Ui.ViewModels;

namespace ScrBorg.Ui.Windows;

public partial class MainWindow : Window
{
    private readonly MainViewModel _viewModel;

    public MainWindow(MainViewModel viewModel)
    {
        _viewModel = viewModel;
        DataContext = viewModel;

        InitializeComponent();
    }

    public MainWindow()
    {
        InitializeComponent();
    }
}
