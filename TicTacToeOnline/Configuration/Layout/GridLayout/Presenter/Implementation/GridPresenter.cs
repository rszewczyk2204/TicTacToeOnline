using System.Collections.Generic;
using TicTacToeOnline.Configuration.Layout.GridLayout.Presenter.Interface;
using TicTacToeOnline.Configuration.Layout.GridLayout.View.Interface;
using TicTacToeOnline.Game.Engine;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace TicTacToeOnline.Configuration.Layout.GridLayout.Presenter.Implementation
{
    public class GridPresenter : IGridPresenter
    {
        private readonly IGridView _grid;
        private readonly Engine engine;

        public GridPresenter(IGridView _grid)
        {
            this._grid = _grid;
            this.engine = Engine.Instance;

            this._grid.ButtonClickedEvent += ButtonClicked;
        }

        public void ButtonClicked(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            if (button.Content == null)
            {
                button.Content = engine.ReturnXOrEllipse();
                engine.UpdateTable(button);
            }
        }
    }
}
