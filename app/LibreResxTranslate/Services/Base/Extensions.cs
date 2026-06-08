/*
 * Author: Nikolay Dvurechensky
 * Site: https://dvurechensky.pro/
 * Gmail: dvurechenskysoft@gmail.com
 * Last Updated: 08 июня 2026 07:13:45
 * Version: 1.0.50
 */

public class Extensions
{
    /// <summary>
    /// Search files
    /// </summary>
    /// <param name="path">Directory</param>
    /// <param name="pattern">File pattern [*.ini]</param>
    public static List<string> GetFiles(string path, string pattern = "*.ini")
        => Directory.EnumerateFiles(path, pattern, SearchOption.AllDirectories).ToList();
}