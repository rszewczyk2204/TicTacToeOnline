using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace TicTacToeOnline
{
    public enum ValidationResult
    {
        Success, 
        Failure,
        Cancellation
    }

    public sealed partial class ChooseNickName : ContentDialog
    {
        public ValidationResult Result { get; set; }

        public ChooseNickName()
        {
            this.InitializeComponent();
        }

        public string Text
        {
            get => this.NickNameBox.Text;
        }

        public void ShowFailedValidationText()
        {
            this.FailedValidationTextBox.Visibility = Visibility.Visible;
        }

        private void OK_Button_Clicked(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            if (Validator.ValidateNickName(NickNameBox.Text))
            {
                args.Cancel = true;
                FailedValidationTextBox.Visibility = Visibility.Visible;
                this.Result = ValidationResult.Failure;
            }
            else
            {
                this.Result = ValidationResult.Success;
            }    
        }

        private void CancellButtonClicked(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            this.Result = ValidationResult.Cancellation;
        }
    }
}
