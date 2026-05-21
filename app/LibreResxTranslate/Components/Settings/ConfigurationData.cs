/*
 * Author: Nikolay Dvurechensky
 * Site: https://dvurechensky.pro/
 * Gmail: dvurechenskysoft@gmail.com
 * Last Updated: 21 мая 2026 11:59:44
 * Version: 1.0.32
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
