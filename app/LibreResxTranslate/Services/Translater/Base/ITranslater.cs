/*
 * Author: Nikolay Dvurechensky
 * Site: https://dvurechensky.pro/
 * Gmail: dvurechenskysoft@gmail.com
 * Last Updated: 25 октября 2026 09:11:04
 * Version: 1.0.186
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
