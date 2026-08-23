/*
 * Author: Nikolay Dvurechensky
 * Site: https://dvurechensky.pro/
 * Gmail: dvurechenskysoft@gmail.com
 * Last Updated: 23 августа 2026 07:16:08
 * Version: 1.0.125
 */

namespace LibreResxTranslate.Services.Translater;

public interface ITranslaterService
{
    Task Translate();
    Action<string> ActionLog { get; set; }
}
