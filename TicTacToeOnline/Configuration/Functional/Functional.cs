using System;
using TicTacToeOnline.Configuration.Layout;

namespace TicTacToeOnline
{
    public sealed class Functional
    {
        private Functional() { }

        private static bool isXLast = false;

        public static string TransformMessage(String sender, String message)
        {
            return sender + ">: " + message + "\n";
        }

        public static object ReturnXOrEllipse()
        {
            if (isXLast)
            {
                isXLast = false;
                return new EllipseControl();
            }
            isXLast = true;
            return new XControl();
        }
    }
}
