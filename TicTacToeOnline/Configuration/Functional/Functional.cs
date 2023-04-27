using System;

namespace TicTacToeOnline
{
    public sealed class Functional
    {
        private Functional() { }

        public static string TransformMessage(String sender, String message)
        {
            return sender + ">: " + message + "\n";
        }
    }
}
