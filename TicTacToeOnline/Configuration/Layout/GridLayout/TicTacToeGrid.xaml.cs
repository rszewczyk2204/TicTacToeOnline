using TicTacToeOnline.Configuration.Layout.GridLayout.Presenter.Implementation;
using TicTacToeOnline.Configuration.Layout.GridLayout.View.Interface;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace TicTacToeOnline.Configuration.Layout
{
    public sealed partial class TicTacToeGrid : UserControl, IGridView
    {
        public event RoutedEventHandler ButtonClickedEvent;

        private readonly GridPresenter gridPresenter = null;

        public TicTacToeGrid()
        {
            InitializeComponent();
            gridPresenter = new GridPresenter(this);
        }

        public void ButtonClicked(object sender, RoutedEventArgs e)
        {
            ButtonClickedEvent.Invoke(sender, e);
        }
    }
}
