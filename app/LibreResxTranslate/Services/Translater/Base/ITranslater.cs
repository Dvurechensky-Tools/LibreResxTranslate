/*
 * Author: Nikolay Dvurechensky
 * Site: https://dvurechensky.pro/
 * Gmail: dvurechenskysoft@gmail.com
 * Last Updated: 22 апреля 2026 18:59:28
 * Version: 1.0.4
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
