/*
 * Author: Nikolay Dvurechensky
 * Site: https://dvurechensky.pro/
 * Gmail: dvurechenskysoft@gmail.com
 * Last Updated: 05 августа 2026 07:14:56
 * Version: 1.0.107
 */

namespace LibreResxTranslate.Services.Translater;

public interface ITranslaterService
{
    Task Translate();
    Action<string> ActionLog { get; set; }
}
