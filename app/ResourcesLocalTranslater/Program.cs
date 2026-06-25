/*
 * Author: Nikolay Dvurechensky
 * Site: https://dvurechensky.pro/
 * Gmail: dvurechenskysoft@gmail.com
 * Last Updated: 25 июня 2026 16:52:13
 * Version: 1.0.67
 */

using LibreResxTranslate.Components;
using LibreResxTranslate.Services.Settings;
using LibreResxTranslate.Services.Translater;

ISettingsService settings = new SettingsService();
settings.ActionLog += (msg) =>
{
    Console.WriteLine(msg);
};
settings.LoadSettings();

if(!settings.IsValid)
{
    Console.WriteLine($"Settings is not Valid... Please check {settings.PathConfig}");
    return;
}

var translater = new WinformsLocalizedTranslater(TypeTranslateEnum.Libre, settings);
translater.ActionLog += (msg) =>
{
    Console.WriteLine(msg);
};

await translater.Translate();