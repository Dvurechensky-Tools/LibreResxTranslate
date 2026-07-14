/*
 * Author: Nikolay Dvurechensky
 * Site: https://dvurechensky.pro/
 * Gmail: dvurechenskysoft@gmail.com
 * Last Updated: 14 июля 2026 07:18:51
 * Version: 1.0.85
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
