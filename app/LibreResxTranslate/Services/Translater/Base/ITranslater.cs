/*
 * Author: Nikolay Dvurechensky
 * Site: https://dvurechensky.pro/
 * Gmail: dvurechenskysoft@gmail.com
 * Last Updated: 16 июля 2026 14:35:41
 * Version: 1.0.87
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
