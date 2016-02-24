using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unpacked
{
    class HexConverter
    {
        static void Main(string[] args)
        {
            string hexValue = "C3C3C3C2C1C";
            Encoding ebcdic = Encoding.GetEncoding(37);

            string ebcdicStr = ConvertHexToString(hexValue,ebcdic);

            Console.WriteLine("Converted {0}", ebcdicStr);
            Console.ReadKey();
        }
        public static string ConvertHexToString(String hexInput, Encoding encoding)
        {
            int numberChars = hexInput.Length;
            if (numberChars % 2 != 0) return string.Empty;

            byte[] bytes = new byte[numberChars / 2];
            for (int i = 0; i < numberChars; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(hexInput.Substring(i, 2), 16);
            }
            return encoding.GetString(bytes);
        }
    }
}
