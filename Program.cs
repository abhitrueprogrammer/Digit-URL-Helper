using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Url__dgit
{
    class Program
    {
     static void Main(string[] args)
    {
        
        void OpenUrl(string url)
        {
            try
            {
                Process.Start(url);
            }
            catch
            {
                // hack because of this: https://github.com/dotnet/corefx/issues/10361
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    url = url.Replace("&", "^&");
                    Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    Process.Start("xdg-open", url);
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    Process.Start("open", url);
                }
                else
                {
                    throw;
                }
            }
        }
            do{
            Console.WriteLine("Select the method of Input");
            Console.WriteLine("1: Specify the Month-year-url no. the site would open accordingly");
            Console.WriteLine("2: Specify the prefix of URL, recommended  method");
            var switch_on = Console.ReadLine();
            switch (switch_on)
            {
                case "1" :
                    Console.WriteLine("Enter the month(jan/feb/mar) etc");
                    var month = Console.ReadLine();
                    Console.WriteLine("Enter the year(21,22,23 etc)");
                    var year = Console.ReadLine();
                    Console.WriteLine("Enter the url no (EG. if URL is http://digit.in/feb21-XY you enter XY");
                    var Loc =  "http://dgit.in/" + month + year + "-" + Console.ReadLine();
                    OpenUrl(Loc);
                    break;
                case "2":
                    Console.WriteLine("Enter the suffix of the url [EG. If url is: http://digit.in/xyz, you just enter xyz]");
                    var Location = "http://dgit.in/" + Console.ReadLine();
                    OpenUrl(Location);
                    break;
                default:
                    Console.WriteLine("Invalid Input");
                    break;
            }
           
            Console.WriteLine("Press \"Q\" to quit, or any other key to continue");
            ConsoleKeyInfo cki;
            cki = Console.ReadKey();
            if (cki.Key == ConsoleKey.Q)
                break;
            }
            while(true);
        }
    }
}
