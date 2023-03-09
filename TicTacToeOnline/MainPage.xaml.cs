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

        private async void MenuFlyoutItem_Click(object sender, RoutedEventArgs e)
        {
            ContentDialog dialog = new ContentDialog();

            dialog.XamlRoot = this.XamlRoot;
            dialog.Title = "Choose nickname";
            dialog.PrimaryButtonText = "Save";
            dialog.SecondaryButtonText = "Cancel";
            dialog.DefaultButton = ContentDialogButton.Primary;
            dialog.Content = new ChooseNickName();

            var result = await dialog.ShowAsync();

            if (result == ContentDialogResult.Primary)
            {
                this.NameBlock.Text = "Hey, " + (dialog.Content as ChooseNickName).Text;
            }
        }

        private void NameBlock_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock textBlock = sender as TextBlock;
            textBlock.Text = "Hey, ";
        }
    }
}
