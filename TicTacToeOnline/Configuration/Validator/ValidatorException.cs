using System;

namespace TicTacToeOnline
{
    public class ValidatorException : Exception
    {
        public ValidatorException()
            : this("Invalid nickname")
        {
        }

        public ValidatorException(String message)
            : base(message)
        {
        }
    }
}
