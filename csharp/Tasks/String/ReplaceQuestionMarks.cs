using System.Text;

namespace Tasks.String
{
    public class ReplaceQuestionMarks
    {
        public string Run(string input)
        {
            char[] alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToLower().ToCharArray();
            
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }

            // var sb = new StringBuilder(input);
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] != '?')
                {
                    // sb.Append(input[i]);
                    continue;
                }

                char left = i - 1 >= 0 ? input[i - 1] : default;
                char right = i + 1 < input.Length ? input[i + 1] : default;

                foreach (var character in alphabet)
                {
                    if (left != character && right != character)
                    {
                        input = input
                            .Remove(i, 1)
                            .Insert(i, character.ToString());
                    }
                }
            }
            
            return input;
        }
    }
}