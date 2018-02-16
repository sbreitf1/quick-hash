using System;
using System.Text;

namespace QuickHash
{
    enum HashEncodings
    {
        HexLowerCase = 0,
        HexUpperCase = 1,
        BlockyHex = 2,
        Base64 = 3
    }


    static class HashConverter
    {
        static string[] hexByteStrings;
        static HashConverter()
        {
            char[] hexChars = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
            hexByteStrings = new string[256];
            for (int i = 0; i < 256; i++)
                hexByteStrings[i] = hexChars[i / 16].ToString() + hexChars[i % 16].ToString();
        }


        public static string ToString(byte[] hash, HashEncodings encoding)
        {
            switch(encoding)
            {
                case HashEncodings.HexLowerCase: return ToHexString(hash).ToLower();
                case HashEncodings.HexUpperCase: return ToHexString(hash);
                case HashEncodings.BlockyHex: return ToHexString(hash, "-").ToLower();
                case HashEncodings.Base64: return ToBase64String(hash);
                default: return "-";
            }
        }

        public static string ToHexString(byte[] hash)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hexByteStrings[hash[i]]);
            }
            return sb.ToString();
        }

        public static string ToHexString(byte[] hash, string separator)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                if (i > 0)
                    sb.Append(separator);
                sb.Append(hexByteStrings[hash[i]]);
            }
            return sb.ToString();
        }

        public static string ToBase64String(byte[] hash)
        {
            return Convert.ToBase64String(hash);
        }
    }
}
