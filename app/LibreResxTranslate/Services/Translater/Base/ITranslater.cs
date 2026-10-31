/*
 * Author: Nikolay Dvurechensky
 * Site: https://dvurechensky.pro/
 * Gmail: dvurechenskysoft@gmail.com
 * Last Updated: 31 октября 2026 10:57:40
 * Version: 1.0.192
 */

namespace LibreResxTranslate.Services.Translater;

/// <summary>
/// Шаблон разновидностей перерводчиков
/// </summary>
public interface ITranslater
{
    Task<string> TranslateAsync(string text, string sourceLang = "ru", string targetLang = "en");
    Action<string> ActionLog { get; set; }
}
