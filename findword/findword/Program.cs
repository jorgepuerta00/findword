namespace WordFinder
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            var matrix = new string[] { "chill", "wind", "snow", "cold" };
            var wordstream = new string[] { "abcdc", "fgwio", "chill", "pqnsd", "uvdxy" };
            var result = new WordFinder(matrix).Find(wordstream);
            Console.WriteLine(string.Join(",", result));
        }
    }
}
