using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

Stopwatch stopwatch = new Stopwatch();

string password = Console.ReadLine();

stopwatch.Start();
var key = Hack(password);
stopwatch.Stop();

Console.WriteLine("Your password: " + key);
Console.WriteLine("Time elapsed: " + stopwatch.ElapsedMilliseconds + "ms");


static string StringSha256Hash(string text) =>
    string.IsNullOrEmpty(text)
        ? string.Empty
        : BitConverter
            .ToString(new SHA256Managed().ComputeHash(
                Encoding.UTF8.GetBytes(text))).Replace("-", string.Empty);

string Hack(string hash)
{
    var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz".ToArray();
    foreach (var t in chars)
    {
        foreach (var t1 in chars)
        {
            foreach (var t2 in chars)
            {
                foreach (var t3 in chars)
                {
                    var key = new string(new[] { t, t1, t2, t3 });
                    Console.WriteLine(key);
                    if (StringSha256Hash(key) == hash)
                    {
                        return key;
                    }
                }
            }
        }
    }

    return null;
}