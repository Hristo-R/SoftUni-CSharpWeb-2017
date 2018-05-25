namespace _02.ValidateUrl
{
    using System;
    using System.Text.RegularExpressions;

    public class ValidateUrl
    {
        public static void Main()
        {
            bool isValidUrl = true;

            Console.Write("Input: ");
            string url = Console.ReadLine();
            
            string pattern =
                @"^(http|https):\/\/([a-zA-Z0-9\.\-]+)\:?(\d+)?(\/([a-zA-Z0-9\.\-\/]+)*)?\??([a-zA-Z0-9\.\-\=\&]+)?\#?([a-zA-Z0-9\.\-]+)?$";

            Regex regex = new Regex(pattern);
            Match match = regex.Match(url);

            if (regex.IsMatch(url))
            {
                string protocol = match.Groups[1].Value;
                string host = match.Groups[2].Value;
                string port = match.Groups[3].Value;
                if (port.Equals("80") || port.Equals("443"))
                {
                    isValidUrl = false;

                    if ((port.Equals("80") && protocol.Equals("http")) || (port.Equals("443") && protocol.Equals("https")))
                    {
                        isValidUrl = true;
                    }
                }
                else if (port == string.Empty)
                {
                    isValidUrl = true;
                }
                else
                {
                    isValidUrl = false;
                }

                string path = match.Groups[4].Value;
                string query = match.Groups[6].Value;
                string fragment = match.Groups[7].Value;
            }
            else
            {
                isValidUrl = false;
            }

            if (isValidUrl)
            {
                Console.WriteLine($"Protocol: {match.Groups[1].Value}");
                Console.WriteLine($"Host: {match.Groups[2].Value}");
                if (match.Groups[1].Value.Equals("http"))
                {
                    Console.WriteLine("Port: 80");
                }

                if (match.Groups[1].Value.Equals("https"))
                {
                    Console.WriteLine("Port: 443");
                }

                Console.WriteLine($"Path: {match.Groups[4].Value}");

                if (match.Groups[6].Value != string.Empty)
                {
                    Console.WriteLine($"Query: {match.Groups[6].Value}");
                }

                if (match.Groups[7].Value != string.Empty)
                {
                    Console.WriteLine($"Fragment: {match.Groups[7].Value}");
                }
            }
            else
            {
                Console.WriteLine("Invalid URL");
            }
        }
    }
}
