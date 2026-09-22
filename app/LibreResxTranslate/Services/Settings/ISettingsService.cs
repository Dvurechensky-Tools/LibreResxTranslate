/*
 * Author: Nikolay Dvurechensky
 * Site: https://dvurechensky.pro/
 * Gmail: dvurechenskysoft@gmail.com
 * Last Updated: 22 сентября 2026 09:25:00
 * Version: 1.0.154
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
