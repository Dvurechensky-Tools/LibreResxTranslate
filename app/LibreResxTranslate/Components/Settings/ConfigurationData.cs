/*
 * Author: Nikolay Dvurechensky
 * Site: https://dvurechensky.pro/
 * Gmail: dvurechenskysoft@gmail.com
 * Last Updated: 31 мая 2026 15:11:59
 * Version: 1.0.42
 */

namespace LibreResxTranslate.Components;

public class ConfigurationData
{
    public bool IsURL { get; set; }
    public string Url { get; set; }
    public string IP { get; set; }
    public string PORT { get; set; }
    public string Protocol { get; set; }

    public List<Entry> Entries { get; set; } = new List<Entry>();
    public bool IsValid =>
       IsURL
           ? !string.IsNullOrWhiteSpace(Url)
           : !string.IsNullOrWhiteSpace(IP) &&
             !string.IsNullOrWhiteSpace(PORT) &&
             int.TryParse(PORT, out _) &&
             (Protocol == "http" || Protocol == "https");
}
