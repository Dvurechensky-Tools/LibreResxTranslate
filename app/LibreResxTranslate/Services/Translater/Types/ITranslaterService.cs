/*
 * Author: Nikolay Dvurechensky
 * Site: https://dvurechensky.pro/
 * Gmail: dvurechenskysoft@gmail.com
 * Last Updated: 20 июля 2026 12:31:03
 * Version: 1.0.91
 */

namespace LibreResxTranslate.Services.Translater;

public interface ITranslaterService
{
    Task Translate();
    Action<string> ActionLog { get; set; }
}
