/*
 * Author: Nikolay Dvurechensky
 * Site: https://dvurechensky.pro/
 * Gmail: dvurechenskysoft@gmail.com
 * Last Updated: 31 августа 2026 07:10:11
 * Version: 1.0.132
 */

namespace LibreResxTranslate.Services.Translater;

public interface ITranslaterService
{
    Task Translate();
    Action<string> ActionLog { get; set; }
}
