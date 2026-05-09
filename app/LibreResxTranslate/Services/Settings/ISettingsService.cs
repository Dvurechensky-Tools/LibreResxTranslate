/*
 * Author: Nikolay Dvurechensky
 * Site: https://dvurechensky.pro/
 * Gmail: dvurechenskysoft@gmail.com
 * Last Updated: 09 мая 2026 08:14:16
 * Version: 1.0.21
 */

using LibreResxTranslate.Components;

namespace LibreResxTranslate.Services.Settings
{
    public interface ISettingsService
    {
        ConfigurationData LoadSettings();
        void ClearSettings();
        string PathConfig { get; set; }
        ConfigurationData Settings { get; set; }
        Action<string> ActionLog { get; set; }
        bool IsValid { get; }
    }
}
