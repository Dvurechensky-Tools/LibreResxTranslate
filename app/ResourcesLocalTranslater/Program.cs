/*
 * Author: Nikolay Dvurechensky
 * Site: https://dvurechensky.pro/
 * Gmail: dvurechenskysoft@gmail.com
 * Last Updated: 22 августа 2026 15:03:38
 * Version: 1.0.124
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