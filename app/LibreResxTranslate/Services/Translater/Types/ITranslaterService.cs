/*
 * Author: Nikolay Dvurechensky
 * Site: https://dvurechensky.pro/
 * Gmail: dvurechenskysoft@gmail.com
 * Last Updated: 22 ноября 2026 12:49:41
 * Version: 1.0.214
 */

namespace LibreResxTranslate.Services.Translater;

public interface ITranslaterService
{
    Task Translate();
    Action<string> ActionLog { get; set; }
}
