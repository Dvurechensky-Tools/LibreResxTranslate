/*
 * Author: Nikolay Dvurechensky
 * Site: https://dvurechensky.pro/
 * Gmail: dvurechenskysoft@gmail.com
 * Last Updated: 28 апреля 2026 14:45:22
 * Version: 1.0.10
 */

namespace LibreResxTranslate.Components;

/// <summary>
/// Translation component
/// </summary>
public class Entry
{
    /// <summary>
    /// Entry type
    /// Folder - from directory to directory
    /// File - from specific file to directory
    /// </summary>
    public string Flag { get; set; }

    /// <summary>
    /// WinForms - localized flag, Ini-specialized, etc.
    /// </summary>
    public string Type { get; set; }

    /// <summary>
    /// Directory for searching Resx files
    /// </summary>
    public string In { get; set; }

    /// <summary>
    /// Resx file path
    /// </summary>
    public string FilePath { get; set; }

    /// <summary>
    /// Output directory for translated Resx files
    /// </summary>
    public string Out { get; set; }

    /// <summary>
    /// Source language
    /// </summary>
    public string CultureIn { get; set; }

    /// <summary>
    /// Target languages
    /// </summary>
    public List<string> CultureOut { get; set; }

    public bool IsValid =>
           !string.IsNullOrWhiteSpace(Flag) &&
           !string.IsNullOrWhiteSpace(Type) &&
           !string.IsNullOrWhiteSpace(In) &&
           !string.IsNullOrWhiteSpace(Out) &&
           !string.IsNullOrWhiteSpace(CultureIn) &&
           CultureOut is { Count: > 0 } &&
           CultureOut.All(x => !string.IsNullOrWhiteSpace(x)) &&
           Path.Exists(In) &&
           Directory.Exists(Out);
}