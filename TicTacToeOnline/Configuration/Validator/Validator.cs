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
            ' ',
            '-',
            '\\',
            '/',
            '.'
        };

        private static List<String> illegalWords = new List<string>()
        {
            "arse",
            "arsehead",
            "arsehole",
            "ass",
            "asshole",
            "bastard",
            "bitch",
            "bloody",
            "bollocks",
            "brotherfucker",
            "bugger",
            "bullshit",
            "childfucker",
            "christonabike",
            "christonacracker",
            "cock",
            "cocksucker",
            "crap",
            "cunt",
            "damn",
            "damnit",
            "dick",
            "dickhead",
            "dyke",
            "fatherfucker",
            "frigger",
            "fuck",
            "goddamn",
            "godsdamn",
            "hell",
            "holyshit",
            "horseshit",
            "inshit",
            "jesusfuck",
            "kike",
            "motherfucker",
            "nigga",
            "nigra",
            "piss",
            "prick",
            "pussy",
            "shit",
            "shitass",
            "shite",
            "sisterfucker",
            "slut",
            "sonofabitch",
            "sonofawhore",
            "spastic",
            "turd",
            "twat",
            "wanker"
        };

        private Validator() { }

        public static bool ValidateNickName(string nickName)
        {
            return string.IsNullOrEmpty(nickName) || ContainsIllegalCharacters(nickName)
                    || ContainsIllegalWords(nickName);
        }

        private static bool ContainsIllegalCharacters(string nickName)
        {
            return nickName.Any(c => illegalCharacters.Contains(c));
        }

        private static bool ContainsIllegalWords(string nickName)
        {
            return DeconstructString(nickName).Any(s => illegalWords.Contains(s.ToLower()));
        }

        private static string[] DeconstructString(string nickName)
        {
            return nickName.Split('\n');
        }

        public static bool ValidateIPPortInput(string ipPort)
        {
            return string.IsNullOrEmpty(ipPort) || !IsValidIPPortString(ipPort);
        }

        private static bool IsValidIPPortString(string ipPort)
        {
            string[] parts = ipPort.Split(':');
            return IsIPValid(parts[0]) && IsValidPort(parts[1]);
        }

        private static bool IsIPValid(string ip)
        {
            string[] ipParts = ip.Split('.');
            return ipParts.Length == 4 && ip.All(char.IsDigit);
        }

        private static bool IsValidPort(string port)
        {
            return port.Length > 0 && port.All(char.IsDigit);
        }
    }
}
