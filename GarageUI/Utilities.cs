using System;
using System.Collections.Generic;
using System.Text;

namespace GarageUI
{
    static class Utilities
    {
        public static void WriteLineYellow(string i_ToPrint)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(i_ToPrint);
            Console.ResetColor();
        }
        public static void WriteLineRed(string i_ToPrint)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(i_ToPrint);
            Console.ResetColor();
        }
        public static TEnum ParseEnumUntilSucceed<TEnum>(string i_StartMessage) where TEnum:struct
        {
            WriteLineYellow(i_StartMessage);
            string userInput = Console.ReadLine();
            TEnum status;
            while (!Enum.TryParse<TEnum>(userInput, true, out status))
            {
               WriteLineRed(i_StartMessage);
                userInput = Console.ReadLine();
            }
           return status;
        }
        public static float ParseNumberUntilSucceed(string i_StartMessage,float? i_MinValue=null,float? i_MaxValue=null, bool i_IsInt=false)
        {
            WriteLineYellow(i_StartMessage);            
            float res=0;
            bool accepted = false;
            while (!accepted)
            {
                string userInput = Console.ReadLine();

                while (!float.TryParse(userInput, out res))
                {
                    WriteLineRed("You have not entered a valid Number!");
                    WriteLineYellow(i_StartMessage);
                    userInput = Console.ReadLine();
                }
                accepted = true;
                if(i_MinValue!=null && res < i_MinValue)
                {
                    accepted = false;
                    WriteLineRed($"please enter a value above {i_MinValue}");
                }
                if (i_MaxValue != null && res > i_MaxValue)
                {
                    WriteLineRed($"please enter a value below {i_MaxValue}");
                    accepted = false;
                }
                if (i_IsInt && res !=Math.Floor(res))
                {
                    WriteLineRed("You have not enterd a whole number!");
                    accepted = false;
                }
            }
            return res;
        }
        public static StringBuilder MenuOptionsFromEnum(Type i_Enum,StringBuilder io_StringBuilder = null, int startIndex = 1)
        {
            if(io_StringBuilder == null)
            {
                io_StringBuilder = new StringBuilder();
            }
            int i = startIndex;
            foreach(string name in Enum.GetNames(i_Enum))
            {
                io_StringBuilder.AppendLine($"{ name,-7}:{i++,7}");
            }
            return io_StringBuilder;
        }
        public static bool ParseBoolUntilSucceed(string i_StartMessage)
        {
            WriteLineYellow(i_StartMessage);
            bool res = true;
            while (!bool.TryParse(Console.ReadLine(), out res))
            {
                WriteLineRed($"please enter a valid bool string {bool.TrueString} or {bool.FalseString}");
            }
            return res;
        }


    }
}
