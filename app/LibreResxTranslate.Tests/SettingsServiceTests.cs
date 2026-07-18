/*
 * Author: Nikolay Dvurechensky
 * Site: https://dvurechensky.pro/
 * Gmail: dvurechenskysoft@gmail.com
 * Last Updated: 18 июля 2026 07:49:41
 * Version: 1.0.89
 */

using LibreResxTranslate.Services.Settings;

namespace LibreResxTranslate.Tests
{
    [TestClass]
    public sealed class SettingsServiceTests
    {
        [TestMethod]
        public void LoadSettingsExist_Test()
        {
            ISettingsService settingsService = new SettingsService();
            var data = settingsService.LoadSettings();
            Assert.IsNotNull(data);
        }

        [TestMethod]
        public void ClearSettings_Test()
        {
            ISettingsService settingsService = new SettingsService();
            settingsService.ClearSettings();
            bool exist = File.Exists(settingsService.PathConfig);
            Assert.IsTrue(exist == false);
        }
    }
}
