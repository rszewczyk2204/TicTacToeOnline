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
                ShowNickNameWindow(true);
                comText.Focus(FocusState.Programmatic);
            };
        }

        private void comText_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            textBox.Background = new SolidColorBrush(Colors.White);
        }

        private void comText_PointerEntered(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            textBox.Focus(FocusState.Programmatic);
        }

        private void IpTextBlock_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock textBlock = sender as TextBlock;
            textBlock.Text = "I'll be displaying your public ip address and port I'll be listening on like this: XXXX.XXXX.XXXX.XXXX:XXXX";
        }

        private void MenuFlyoutItem_Click(object sender, RoutedEventArgs e)
        {
            ShowNickNameWindow(false);
        }

        private void NameBlock_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock textBlock = sender as TextBlock;
            textBlock.Text = "Hey, ";
        }

        private async void ShowNickNameWindow(bool isCalledOnLoaded = false)
        {
            ChooseNickName dialog = new ChooseNickName();

            dialog.XamlRoot = this.XamlRoot;
            dialog.IsSecondaryButtonEnabled = !isCalledOnLoaded;

            await dialog.ShowAsync();

            if (dialog.Result == ValidationResult.Success)
            {
                this.NameBlock.Text = "Hey, " + dialog.Text;
            }
        }

        private void HostGameButtonClicked(object sender, RoutedEventArgs e)
        {
            bool hasServerStarted = false;
            Thread t = new Thread(() => Server.StartServer(ref ipAddress, ref port, out hasServerStarted));
            t.Start();
            t.Join();

            if (hasServerStarted)
            {
                this.IpTextBlock.Text = ipAddress + ":" + port;
                this.IpTextBlock.Visibility = Visibility.Visible;
                LeaveGameButton.IsEnabled = true;
                JoinGameButton.IsEnabled = false;
            }
        }

        private async void JoinGameButtonClicked(object sender, RoutedEventArgs e)
        {
            JoinGame dialog = new JoinGame();

            dialog.XamlRoot = this.XamlRoot;

            await dialog.ShowAsync();

            if (dialog.Result == JoinGameValidationResult.Success)
            {
                Client.JoinGame(dialog.IPAddress, dialog.Port);
                HostGameButton.IsEnabled = false;
                LeaveGameButton.IsEnabled = true;
            }
        }

        private void LeaveGameButtonClicked(object sender, RoutedEventArgs e)
        {
            LeaveGameButton.IsEnabled = false;
            Server.CloseServer();
            Client.LeaveGame();
        }

        private void EnterKeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Enter)
            {
                this.ComTextBlock.Text += Functional.TransformMessage(this.NameBlock.Text, this.comText.Text);
                this.comText.Text = String.Empty;
            }
        }
    }
}
