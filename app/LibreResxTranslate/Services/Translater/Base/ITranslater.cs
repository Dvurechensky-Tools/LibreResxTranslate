/*
 * Author: Nikolay Dvurechensky
 * Site: https://dvurechensky.pro/
 * Gmail: dvurechenskysoft@gmail.com
 * Last Updated: 20 июня 2026 07:11:31
 * Version: 1.0.62
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
