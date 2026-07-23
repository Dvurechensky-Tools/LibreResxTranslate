/*
 * Author: Nikolay Dvurechensky
 * Site: https://dvurechensky.pro/
 * Gmail: dvurechenskysoft@gmail.com
 * Last Updated: 23 июля 2026 13:17:27
 * Version: 1.0.94
 */

using Newtonsoft.Json;

using LibreResxTranslate.Components;

namespace LibreResxTranslate.Services.Settings;

public class SettingsService : ISettingsService
{
    public string PathConfig { get; set; } = Path.Combine(AppContext.BaseDirectory, "Configurations", "app_settings.json");
    public ConfigurationData Settings { get; set; }
    public bool IsValid => Settings.IsValid && File.Exists(PathConfig);
    public Action<string> ActionLog { get; set; }

    /// <summary>
    /// Загрузка из корня приложения настроек
    /// </summary>
    /// <returns></returns>
    public ConfigurationData LoadSettings()
    {
        // Генерируем файл настроек для заполнения точек перевода
        if(!File.Exists(PathConfig))
        {
            var clearData = new ConfigurationData();
            var jsonData = JsonConvert.SerializeObject(new ConfigurationData());
            var dir = Path.GetDirectoryName(PathConfig);
            Directory.CreateDirectory(dir);
            File.WriteAllText(PathConfig, jsonData.ToString());
            Settings = clearData;
            ActionLog.Invoke($"{PathConfig} not found. Config was created.");
            return clearData;
        }

        var fileContent = File.ReadAllText(PathConfig);
        var data = JsonConvert.DeserializeObject<ConfigurationData>(fileContent);
        Settings = data;
        ActionLog.Invoke($"{PathConfig} read success. Entries: {Settings.Entries.Count}. \n" +
            $"Is url: {Settings.IsURL}\n");
        return data;
    }

    public void ClearSettings()
    {
        File.Delete(PathConfig);
        ActionLog.Invoke($"{PathConfig} deleted.");
    }
}
