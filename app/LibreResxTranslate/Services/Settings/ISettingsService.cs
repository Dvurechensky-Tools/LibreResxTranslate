/*
 * Author: Nikolay Dvurechensky
 * Site: https://dvurechensky.pro/
 * Gmail: dvurechenskysoft@gmail.com
 * Last Updated: 20 ноября 2026 06:53:24
 * Version: 1.0.212
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
