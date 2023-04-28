using System.Collections.Generic;

namespace TicTacToeOnline.Game.Engine
{
    public class Engine
    {
        private Engine() { }

        public static Engine Instance { get; private set; } = new Engine();

        public void UpdateTable(string buttonName)
        { }

        private void Compute()
        { }
    }
}
