/*
 * Author: Nikolay Dvurechensky
 * Site: https://dvurechensky.pro/
 * Gmail: dvurechenskysoft@gmail.com
 * Last Updated: 04 мая 2026 07:14:46
 * Version: 1.0.16
 */

using System.Text;
using System.Text.Json;

namespace LibreResxTranslate.Services.Translater;

/// <summary>
/// Перевод под LibreTranslate (Локальный Docker сервер))
/// </summary>
public class LibreTranslater : ITranslater
{
    public string IP { get; set; } = "192.168.64.128";
    public string Port { get; set; } = "5001";
    public string Protocol { get; set; } = "http";
    public string Url { get; set; }

    private bool IsUrl { get; set; } = false;

    public Action<string> ActionLog { get; set; }

    public LibreTranslater() { }

    public LibreTranslater(string url) 
    {
        Url = url;
        IsUrl = true;
    }

    public LibreTranslater(string IP = "192.168.64.128", string Port = "5001", string Protocol = "http") 
    { 
        this.IP = IP;
        this.Port = Port;
        this.Protocol = Protocol;
    }

    public async Task<string> TranslateAsync(string text, string sourceLang = "ru", string targetLang = "en")
    {
        try
        {
            using var client = new HttpClient();
            var payload = new
            {
                q = text,
                source = sourceLang,
                target = targetLang,
                format = "text"
            };

            var content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8,
                "application/json");

            var address = (IsUrl) ? Url + "/translate" : $"{Protocol}://{IP}:{Port}/translate";
            ActionLog.Invoke($"Send request to address: {address}");
            var response = await client.PostAsync(address, content);
            var resultJson = await response.Content.ReadAsStringAsync();
            ActionLog.Invoke($"Response json: {resultJson}");

            var result = JsonSerializer.Deserialize<JsonElement>(resultJson);
            return result.GetProperty("translatedText").GetString();
        }
        catch (Exception ex)
        {
            var msg = ex.Message;
            return null;
        }
    }
}
