using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dd_console {
    class ByteFormatter {
        const long BaseByte = 1024;
        public static String getFormatGMKBString(long rawByte) {
            long Byte = rawByte % BaseByte;
            long KByte = rawByte / BaseByte % BaseByte;
            long MByte = rawByte / BaseByte / BaseByte % BaseByte;
            long GByte = rawByte / BaseByte / BaseByte / BaseByte % BaseByte;
            return $"{GByte,3}GB{MByte,4}MB{KByte,4}KB{Byte,4}B";
        }
        public static void writeFormatGMKBStringColor(long rawByte) {
            long Byte = rawByte % BaseByte;
            long KByte = rawByte / BaseByte % BaseByte;
            long MByte = rawByte / BaseByte / BaseByte % BaseByte;
            long GByte = rawByte / BaseByte / BaseByte / BaseByte % BaseByte;
            if (GByte == 0) {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("  0GB");
                Console.ResetColor();
            } else {
                Console.Write($"{GByte,3}GB");
            }
            if (GByte == 0 && MByte == 0) {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("  0MB");
                Console.ResetColor();
            } else {
                Console.Write($"{MByte,4}MB");
            }
            if (GByte == 0 && MByte == 0 && KByte == 0) {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("  0KB");
                Console.ResetColor();
            } else {
                Console.Write($"{KByte,4}KB");
            }
            Console.Write($"{Byte,4}B");
        }
        public static long getByteFromGMKBString(String text) {
            long result = 0;
            System.Text.RegularExpressions.Regex gbReg = new System.Text.RegularExpressions.Regex(@"(\d+)GB", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex kbReg = new System.Text.RegularExpressions.Regex(@"(\d+)KB", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex mbReg = new System.Text.RegularExpressions.Regex(@"(\d+)MB", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex bReg = new System.Text.RegularExpressions.Regex(@"(\d+)B", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            if (bReg.IsMatch(text)) {
                var m = bReg.Match(text);
                result += long.Parse(m.Groups[1].Value);
            }
            if (kbReg.IsMatch(text)) {
                var m = kbReg.Match(text);
                result += long.Parse(m.Groups[1].Value) * BaseByte;
            }
            if (mbReg.IsMatch(text)) {
                var m = mbReg.Match(text);
                result += long.Parse(m.Groups[1].Value) * BaseByte * BaseByte;
            }
            if (gbReg.IsMatch(text)) {
                var m = gbReg.Match(text);
                result += long.Parse(m.Groups[1].Value) * BaseByte * BaseByte * BaseByte;
            }
            return result;
        }
    }
}
