using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Configuration;

namespace coding_test_counting
{
    public class Program
    {
        static void Main(string[] args)
        {
            string testInput = "abvc Bdefoae aesild, Beesdijl"; //to be changed

            string[] words = Regex.Split(testInput, @"\W+");

            Rule1(words, @"^[Aa]");
            Rule2(words, @"^[Bb]");
            Rule3(words, @"^[abc]");
            Rule4(words, @"^[Cc]", @"^[Aa]");
        }

        public static void Rule1(string[] words, string regex)
        {
            int totalNumber = 0;
            int totalLength = 0;

            foreach (string value in words)
            {
                var match = Regex.Match(value, regex);
                if (match.Success)
                {
                    totalNumber++;
                    totalLength = totalLength + value.Length;
                }
            }

            var avgLength = totalNumber > 0 ? totalLength / totalNumber : 0;
            IOUtilities.WriteToFile("average_length_of_words_starting_with_a.txt", avgLength.ToString());
            Console.WriteLine("Average Length: " + avgLength);
        }

        public static void Rule2(string[] words, string regex)
        {
            int totalNumber = 0;

            foreach (string value in words)
            {
                var match = Regex.Match(value, regex);
                if (match.Success)
                {
                    string[] words_e = Regex.Split(value, @"[Ee]");
                    totalNumber = totalNumber + (words_e.Length - 1);
                }
            }

            IOUtilities.WriteToFile("count_of_e_in_words_starting_with_b.txt", totalNumber.ToString());
            Console.WriteLine("Total number of E/e: " + totalNumber);
        }

        public static void Rule3(string[] words, string regex)
        {
            int maxLength = 0;

            foreach (string value in words)
            {
                var match = Regex.Match(value, regex);
                if (match.Success)
                {
                    maxLength = maxLength > value.Length ? maxLength : value.Length;
                }
            }

            IOUtilities.WriteToFile("longest_words_starting_with_abc.txt", maxLength.ToString());
            Console.WriteLine("The longest length: " + maxLength);
        }

        public static void Rule4(string[] words, string regex_first, string regex_second)
        {
            int totalNumber = 0;

            for(int i=0; i<words.Length; i++)
            {
                var match_first = Regex.Match(words[i], regex_first);
                var match_second = (i + 1) < words.Length ? Regex.Match(words[i + 1], regex_second) : Match.Empty;
                if (match_first.Success && match_second.Success)
                {
                    totalNumber++;
                }
            }

            IOUtilities.WriteToFile("count_of_sequence_of_words_starging_withs_c_and_a.txt", totalNumber.ToString());
            Console.WriteLine("The number of the sequence: " + totalNumber);
        }


    }
}
