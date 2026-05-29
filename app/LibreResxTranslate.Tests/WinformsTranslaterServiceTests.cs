/*
 * Author: Nikolay Dvurechensky
 * Site: https://dvurechensky.pro/
 * Gmail: dvurechenskysoft@gmail.com
 * Last Updated: 29 мая 2026 14:16:55
 * Version: 1.0.40
 */

using LibreResxTranslate.Components;
using LibreResxTranslate.Services.Settings;
using LibreResxTranslate.Services.Translater;

namespace LibreResxTranslate.Tests
{
    [TestClass]
    public class WinformsTranslaterServiceTests
    {
        [TestMethod]
        public async Task Translate_Test()
        {
            var settings = new SettingsService();
            settings.ActionLog += (msg) =>
            {
                Console.WriteLine(msg);
            };
            settings.Settings = new ConfigurationData()
            {
                IsURL =  false,
                Url =  "",
                IP =  "192.168.0.179",
                PORT =  "5000",
                Protocol =  "http",
                Entries = new List<Entry>()
                {
                    new Entry()
                    {
                        Flag = "Folder",
                        Type = "WinFormsLocalized",
                        In = "F:\\REPOSITORIES\\GITHUB\\_REPO\\LIZERIUM\\LizeriumAccauntManager\\app\\LizeriumAccauntManager\\Views",
                        Out = "Out",
                        CultureIn = "en",
                        CultureOut = new List<string>() {"ru", "zh-Hans" }
                    }
                }
            };
            if(settings.IsValid)
            {
                var translater = new WinformsLocalizedTranslater(TypeTranslateEnum.Libre, settings);
                translater.ActionLog += (msg) =>
                {
                    Console.WriteLine(msg);
                };

                await translater.Translate();
            }
            else
                Assert.Fail("Settings is not valid");
        }
    }
}
