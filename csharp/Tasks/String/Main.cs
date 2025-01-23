using System.Text;

namespace Tasks.String
{
    public class Main
    {
        // public string ReverseWords(string s)
        // {
        //     if (string.IsNullOrWhiteSpace(s))
        //         return s;
        //
        //     var words = s.Split(' ')
        //         .Where(w => !string.IsNullOrWhiteSpace(w))
        //         .Reverse();
        //
        //     return string.Join(' ', words);
        // }

        public string ReverseWords(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                return s;


            // 1. Clean spaces
            var sb = CleanSpaces(s);

            // 2. Reverse the whole string
            sb = Reverse(sb);

            // 3. Reverse each word
            sb = ReverseWords(sb);

            return sb.ToString();


            StringBuilder CleanSpaces(string s)
            {
                var sb = new StringBuilder();

                int i = 0;
                // skip spaces at the beginning of the text
                while (s[i] == ' ')
                    i++;

                while (i < s.Length)
                {
                    // add non-spaces to the StringBuilder
                    while (i < s.Length && s[i] != ' ')
                        sb.Append(s[i++]);

                    // skip spaces
                    while (i < s.Length && s[i] == ' ')
                        i++;

                    // add one space to divide 2 words
                    if (i < s.Length)
                        sb.Append(' ');
                }

                return sb;
            }

            StringBuilder Reverse(StringBuilder sb)
            {
                int i = 0; int j = s.Length - 1;
                while (i < j)
                {
                    var temp = sb[i];
                    sb.Replace(sb[i], sb[j], i, 1);
                    sb.Replace(sb[j], temp, j, 1);
                    i++;
                    j--;
                }

                return sb;
            }

            StringBuilder ReverseWords(StringBuilder sb)
            {
                int i = 0;
                int j = 0;
                while (i < sb.Length)
                {
                    while (j < sb.Length && sb[j] != ' ')
                    {
                        j++;
                    }

                    var k = j - 1;
                    while (i < k)
                    {
                        var temp = sb[i];
                        sb.Replace(sb[i], sb[k], i, 1);
                        sb.Replace(sb[k], temp, k, 1);
                        i++;
                        k--;
                    }

                    // i = 
                }

                return sb;
            }
        }
    }
}