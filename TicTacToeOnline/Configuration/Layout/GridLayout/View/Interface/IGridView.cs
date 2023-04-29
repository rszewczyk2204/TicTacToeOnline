using Windows.UI.Xaml;

namespace TicTacToeOnline.Configuration.Layout.GridLayout.View.Interface
{
    public interface IGridView : IGridEvents
    {
        void ButtonClicked(object sender, RoutedEventArgs e);
    }
}
