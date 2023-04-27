using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace TicTacToeOnline.Configuration.Layout.GridLayout.Presenter.Interface
{
    public interface IGridPresenter
    {
        void ButtonClicked(object sender, RoutedEventArgs e);
    }
}
