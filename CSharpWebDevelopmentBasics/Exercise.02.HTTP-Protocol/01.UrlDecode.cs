namespace _01.UrlDecode
{
    using System;
    using System.Net;

    public class UrlDecode
    {
        public static void Main()
        {
            Console.Write("input: ");
            string input = Console.ReadLine();

            Console.WriteLine($"output: {WebUtility.UrlDecode(input)}");
        }
    }
}
