using System;
using System.Collections.Generic;
using System.Linq;

namespace Tasks.String
{
    public class PrintLast10Lines
    {
        public List<string> Print(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return new List<string>();
            }

            var result = new List<string>();
            var n = input.Length;
            int lastDelimeterPosition = input.LastIndexOf('\n');

            int startPos = n - 1;
            var tempString = "";
            var count = 0;
            for (int i = n - 1; i > -1 && count < 10; i--)
            {
                if (input[i] == '\n')
                {
                    var charArray = tempString.ToCharArray();
                    charArray = charArray.Reverse().ToArray();
                    result.Add(new string(charArray));
                    count++;
                    tempString = "";
                }
                else
                {
                    tempString += input[i];
                }
            }

            result.ForEach(Console.WriteLine);
            return result;
        }
    }
}