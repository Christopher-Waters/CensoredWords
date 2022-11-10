using System.Text.RegularExpressions;

namespace censored
{
    class Program
    {
        static String censor(String text,
                      List<string> words)
        {

            foreach (var word in words)
            {

                // Creating the censor which is an asterisks
                // "*" text of the length of censor word
                String stars = "";
                for (int i = 0; i < word.Length; i++)
                    stars += '*';

                text = text.Replace(word, stars);

            }

            return text;
        }

        public static void Main(String[] args)
        {
            string extract = System.IO.File.ReadAllText(@"input.txt");

            var censoredFile = System.IO.File.ReadAllText(@"censored.txt");

            var pattern = @"""(?<r>[^""]*)""|'(?<r>[^']*)'|(?<r>[^\s,]+)";
            var censoredwords = Regex.Matches(censoredFile, pattern).Cast<Match>().Select(x => x.Groups["r"].Value).ToList();

            File.WriteAllText("output.txt",(censor(extract, censoredwords)));

            Console.WriteLine("New censored text written to output.txt");

        }

    }
}