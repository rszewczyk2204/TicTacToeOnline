using Windows.ApplicationModel.Core;
using Windows.UI.ViewManagement;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using System;
using System.Threading;
using Windows.UI.Xaml.Input;
using Windows.System;
using Windows.UI.Xaml.Shapes;

namespace TicTacToeOnline
{
    public sealed partial class MainPage : Page
    {
        private String port;
        private String ipAddress;

        public MainPage()
        {
            this.InitializeComponent();

            CoreApplicationViewTitleBar coreTitleBar =
                CoreApplication.GetCurrentView().TitleBar;
            coreTitleBar.ExtendViewIntoTitleBar = true;

            // Set caption buttons background to transparent.
            ApplicationViewTitleBar titleBar =
                ApplicationView.GetForCurrentView().TitleBar;
            titleBar.ButtonBackgroundColor = Colors.Transparent;

            Window.Current.SetTitleBar(bkgTitleBar);

            this.Loaded += (object sender, RoutedEventArgs e) =>
            {
                comText.Focus(FocusState.Programmatic);
            };
        }

        //private void comText_LostFocus(object sender, RoutedEventArgs e)
        //{
        //    TextBox textBox = sender as TextBox;

        //    textBox.Background = new SolidColorBrush(Colors.White);
        //}

        //private void comText_PointerEntered(object sender, PointerRoutedEventArgs e)
        //{
        //    TextBox textBox = sender as TextBox;
        //    textBox.Focus(FocusState.Programmatic);
        //}

        //private void MenuFlyoutItem_Click(object sender, RoutedEventArgs e)
        //{
        //    ShowNickNameWindow(false);
        //}

        //private async void ShowNickNameWindow(bool isCalledOnLoaded = false)
        //{
        //    ChooseNickName dialog = new ChooseNickName();

        //    dialog.XamlRoot = this.XamlRoot;
        //    dialog.IsSecondaryButtonEnabled = !isCalledOnLoaded;

        //    await dialog.ShowAsync();
        //}

        //private void HostGameButtonClicked(object sender, RoutedEventArgs e)
        //{
        //    bool hasServerStarted = false;
        //    Thread t = new Thread(() => Server.StartServer(ref ipAddress, ref port, out hasServerStarted));
        //    t.Start();
        //    t.Join();

        //    if (hasServerStarted)
        //    {
        //        LeaveGameButton.IsEnabled = true;
        //        JoinGameButton.IsEnabled = false;
        //    }
        //}

        //private async void JoinGameButtonClicked(object sender, RoutedEventArgs e)
        //{
        //    JoinGame dialog = new JoinGame();

        //    dialog.XamlRoot = this.XamlRoot;

        //    await dialog.ShowAsync();

        //    if (dialog.Result == JoinGameValidationResult.Success)
        //    {
        //        Client.JoinGame(dialog.IPAddress, dialog.Port);
        //        HostGameButton.IsEnabled = false;
        //        LeaveGameButton.IsEnabled = true;
        //    }
        //}

        //private void LeaveGameButtonClicked(object sender, RoutedEventArgs e)
        //{
        //    LeaveGameButton.IsEnabled = false;
        //    Server.CloseServer();
        //    Client.LeaveGame();
        //}

        //private void EnterKeyDown(object sender, KeyRoutedEventArgs e)
        //{
        //    if (e.Key == VirtualKey.Enter)
        //    {
        //        //this.ComTextBlock.Text += Functional.TransformMessage(this.NameBlock.Text, this.comText.Text);
        //        this.comText.Text = String.Empty;
        //    }
        //}

        //private void UpperLeft_Click(object sender, RoutedEventArgs e)
        //{
        //    var ellipse = new Ellipse
        //    {
        //        Stroke = new SolidColorBrush(Colors.White),
        //        Width = 200,
        //        Height = 200
        //    };

        //    var xShape = new Canvas
        //    {
        //        Width = 200,
        //        Height = 200
        //    };

        //    var line1 = new Line
        //    {
        //        X1 = 0,
        //        Y1 = 0,
        //        X2 = 200,
        //        Y2 = 200,
        //        Stroke = new SolidColorBrush(Colors.White),
        //        StrokeThickness = 2
        //    };

        //    var line2 = new Line
        //    {
        //        X1 = 200,
        //        Y1 = 0,
        //        X2 = 0,
        //        Y2 = 200,
        //        Stroke = new SolidColorBrush(Colors.White),
        //        StrokeThickness = 2
        //    };

        //    xShape.Children.Add(line1);
        //    xShape.Children.Add(line2);


        //    this.UpperLeftButton.IsEnabled = false;
        //    this.UpperLeft.Children.Add(xShape);
        //}
    }
}
