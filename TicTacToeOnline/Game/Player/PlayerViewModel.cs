using System.Collections.ObjectModel;
using System.ComponentModel;

namespace TicTacToeOnline.Game.Player
{
    public class PlayerViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Player> _players;
        private Player _player;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Player> Players
        {
            get { return _players; }

            set
            {
                if (_players != value)
                {
                    _players = value;
                    OnPropertyChanged(nameof(Player));
                }
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
