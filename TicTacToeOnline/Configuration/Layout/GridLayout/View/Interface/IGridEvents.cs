﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace TicTacToeOnline.Configuration.Layout.GridLayout.View.Interface
{
    public interface IGridEvents
    {
        event RoutedEventHandler ButtonClickedEvent;
    }
}
