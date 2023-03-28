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
        private string nickname;
        private Thread server = null;

        public MainPage()
        {
            this.InitializeComponent();

            CoreApplicationViewTitleBar coreTitleBar =
                CoreApplication.GetCurrentView().TitleBar;
            coreTitleBar.ExtendViewIntoTitleBar = true;

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
                this.nickname = dialog.Text;
                this.NameBlock.Text = "Hey, " + nickname;
            }
        }

        private void HostGameButtonClicked(object sender, RoutedEventArgs e)
        {
            bool hasServerStarted = false;
            string ip = null;
            string port = null;
            string message = String.Empty;

            server = new Thread(() => Server.StartServer(out ip, out port, out hasServerStarted));
            server.Start();
            Server.Listen(ref message);

            if (hasServerStarted)
            {
                LeaveGameButton.IsEnabled = true;
                JoinGameButton.IsEnabled = false;
                HostGameButton.IsEnabled = false;
                this.IPPortBlock.Text = ip + ":" + port;
                this.IPPortBlock.Visibility = Visibility.Visible;
            }
        }

        private async void JoinGameButtonClicked(object sender, RoutedEventArgs e)
        {
            JoinGame dialog = new JoinGame();

            dialog.XamlRoot = this.XamlRoot;

            await dialog.ShowAsync();

            if (dialog.Result == JoinGameValidationResult.Success)
            {
                HostGameButton.IsEnabled = false;
                LeaveGameButton.IsEnabled = true;
            }
        }

        private void LeaveGameButtonClicked(object sender, RoutedEventArgs e)
        {
            LeaveGameButton.IsEnabled = false;
            HostGameButton.IsEnabled = true;
            JoinGameButton.IsEnabled = true;
            Server.CloseServer();
            Client.LeaveGame();
            IPPortBlock.Visibility = Visibility.Collapsed;
        }

        private void EnterKeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Enter && Client.IsConnected)
            {
                String tMessage = Functional.TransformMessage(this.nickname, this.comText.Text);
                this.ComTextBlock.Text += tMessage;
                this.comText.Text = String.Empty;
                Functional.SendMessage(Client.client, tMessage);
            }
        }
    }
}
