using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToeOnline
{
    public class Validator
    {
        private static List<char> illegalCharacters = new List<char>
        {
            '\n',
            '\r',
            '-',
            ' '
        };

        private static Dictionary<Guid, String> illegalWords = new Dictionary<Guid, String>()
        {
            { Guid.NewGuid(), "arse" },
            { Guid.NewGuid(), "arsehead" },
            { Guid.NewGuid(), "arsehole" },
            { Guid.NewGuid(), "ass" },
            { Guid.NewGuid(), "asshole" },
            { Guid.NewGuid(), "bastard" },

        };

        private Validator() { }

        public static void ValidateNickName(string nickName)
        {
            if (String.IsNullOrEmpty(nickName) || ContainsInvalidCharacters(nickName) 
                    || ContainsInvalidCharacters(nickName) || )
            {
                throw new ValidatorException();
            }
        }

        private static bool ContainsInvalidCharacters(string nickName)
        {
            return nickName.Any(c => illegalCharacters.Contains(c));
        }

        /// <summary>
        /// Deconstruct around what?
        /// Every possible character out of ASCII or normal english alphabet?
        /// </summary>
        /// <param name="nickName"></param>
        private static void DeconstructString(ref String nickName)
        {

        }
    }
}
