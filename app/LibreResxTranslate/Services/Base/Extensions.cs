/*
 * Author: Nikolay Dvurechensky
 * Site: https://dvurechensky.pro/
 * Gmail: dvurechenskysoft@gmail.com
 * Last Updated: 25 мая 2026 11:34:21
 * Version: 1.0.36
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