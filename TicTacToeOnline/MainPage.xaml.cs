using Windows.ApplicationModel.Core;
using Windows.UI.ViewManagement;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using System;

namespace TicTacToeOnline
{
    public sealed partial class MainPage : Page
    {
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
    }
}
