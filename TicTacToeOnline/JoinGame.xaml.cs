using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

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
            if (Validator.ValidateIPPortInput(IPPortText.Text))
            {
                args.Cancel = true;
                FailedValidationIPPortConfiguration.Visibility = Visibility.Visible;
                this.Result = JoinGameValidationResult.Failure;
            }
            else
            {
                this.Result = JoinGameValidationResult.Success;
                this.IPAddress = this.IPPortText.Text.Split(':')[0];
                this.Port = this.IPPortText.Text.Split(":")[1];
            }
        }

        private void CancelButtonClicked(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            this.Result = JoinGameValidationResult.Cancellation;
        }
    }
}
