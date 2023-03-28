using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;
using System.Threading;

namespace TicTacToeOnline
{
    public enum JoinGameValidationResult
    {
        Success,
        Failure,
        Cancellation
    }

    public sealed partial class JoinGame : ContentDialog
    {
        public JoinGameValidationResult Result { get; set; }
        public string IPAddress { private set; get; }
        public string Port { private set; get; }

        public JoinGame()
        {
            this.InitializeComponent();
        }

        private void OKButtonClicked(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            this.FailedValidationIPPortConfiguration.Visibility = Visibility.Collapsed;
            this.JoiningGame.Visibility = Visibility.Collapsed;
            if (Validator.ValidateIPPortInput(this.IPPortText.Text))
            {
                this.FailedValidationIPPortConfiguration.Visibility = Visibility.Visible;
                args.Cancel = true;
            }
            else
            {
                this.IPAddress = this.IPPortText.Text.Split(':')[0];
                this.Port = this.IPPortText.Text.Split(":")[1];
                Client.JoinGame(this.IPAddress, this.Port);
                this.JoiningGame.Visibility = Visibility.Visible;
                if (!Client.IsConnected)
                {
                    args.Cancel = true;
                    this.JoiningGame.Text = "Failed to join game";
                }
                else
                {
                    this.Result = JoinGameValidationResult.Success;
                }
            }
        }

        private void CancelButtonClicked(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            this.Result = JoinGameValidationResult.Cancellation;
        }
    }
}
