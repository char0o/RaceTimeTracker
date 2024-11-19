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
    private readonly LoginService _loginService;
    
    public MainWindow(UserService userService, LoginService loginService)
    {
        _userService = userService;
        _loginService = loginService;

        this.InitializeComponent();
    }

    private async void LoginButton_Click(object sender, RoutedEventArgs e)
    {
        bool success = await _loginService.Login(new User(UsernameTextBox.Text, PasswordBox.Password));

        if (!success)
        {
            FeedbackTextBlock.Text = "Wrong username or password";
            FeedbackTextBlock.Foreground = Brushes.Red;
            return;
        }
        FeedbackTextBlock.Text = "Logged in";
        FeedbackTextBlock.Foreground = Brushes.Green;
    }
}