using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using RacetimeTrackerClient.Model;
using RacetimeTrackerClient.Services;

namespace RacetimeTrackerClient;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly UserService _userService;
    public MainWindow(UserService userService)
    {
        _userService = userService;

        this.InitializeComponent();
        this.Loaded += this.Window_Loaded;
    }

    private async void Window_Loaded(object sender, RoutedEventArgs e)
    {
        List<User> users = await this._userService.GetUsersAsync();
        this.UsersDataGrid.ItemsSource = users;
    }
}