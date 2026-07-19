/*
 * Author: Nikolay Dvurechensky
 * Site: https://dvurechensky.pro/
 * Gmail: dvurechenskysoft@gmail.com
 * Last Updated: 19 июля 2026 10:22:43
 * Version: 1.0.90
 */

using System.Collections;
using System.ComponentModel.Design;

using LibreResxTranslate.Components;
using LibreResxTranslate.Services.Settings;

using Resx.Resources;

namespace LibreResxTranslate.Services.Translater;

public class WinformsLocalizedTranslater : ITranslaterService
{
    public ITranslater Translater { get; private set; }
    public ISettingsService Settings {  get; private set; }
    public Action<string> ActionLog {  get; set; }

    public WinformsLocalizedTranslater(TypeTranslateEnum typeTranslateEnum,
        ISettingsService settings) 
    {
        Settings = settings;

        switch (typeTranslateEnum)
        {
            case TypeTranslateEnum.Libre:
                if (Settings.Settings.IsURL)
                {
                    Translater = new LibreTranslater(
                       Settings.Settings.Url);
                }
                else
                {
                    Translater = new LibreTranslater(
                        Settings.Settings.IP,
                        Settings.Settings.PORT,
                        Settings.Settings.Protocol);
                }
                break;
        }
    }

    public async Task Translate()
    {
        if (Settings == null 
            || Settings.Settings.Entries == null
            || Settings.Settings.IsURL && string.IsNullOrEmpty(Settings.Settings.Url)
            || Settings.Settings.Entries.Count == 0) return;

        foreach (var s in Settings.Settings.Entries) 
        {
            switch(s.Flag)
            {
                case "Folder":
                    await ReadFolderResx(s);
                    break;
                case "File":
                    ReadFileResx(s);
                    break;
            }
        }
    }

    private async Task ReadFolderResx(Entry s)
    {
        if (string.IsNullOrWhiteSpace(s.In) ||
            string.IsNullOrWhiteSpace(s.Out))
            return;

        if (!Directory.Exists(s.In))
        {
            ActionLog?.Invoke($"Input folder not found: {s.In}");
            return;
        }

        Directory.CreateDirectory(s.Out);

        if (string.IsNullOrWhiteSpace(s.CultureIn))
            return;

        if (s.CultureOut == null || s.CultureOut.Count == 0)
            return;

        var files = Extensions.GetFiles(s.In, "*.resx");

        if (files == null || files.Count == 0)
        {
            ActionLog?.Invoke($"No .resx files found: {s.In}");
            return;
        }

        foreach (var file in files)
        {
            ActionLog?.Invoke($"Read file: {file}");

            await ResxReader(
                file,
                s.Out,
                s.CultureIn,
                s.CultureOut);
        }
    }

    private async Task ReadFileResx(Entry s)
    {
        if (string.IsNullOrWhiteSpace(s.FilePath))
        {
            ActionLog?.Invoke("FilePath is empty.");
            return;
        }

        if (!File.Exists(s.FilePath))
        {
            ActionLog?.Invoke($"File not found: {s.FilePath}");
            return;
        }

        if (string.IsNullOrWhiteSpace(s.Out))
        {
            ActionLog?.Invoke("Output folder is empty.");
            return;
        }

        if (string.IsNullOrWhiteSpace(s.CultureIn))
        {
            ActionLog?.Invoke("Input culture is empty.");
            return;
        }

        if (s.CultureOut == null || s.CultureOut.Count == 0)
        {
            ActionLog?.Invoke("Output cultures list is empty.");
            return;
        }

        Directory.CreateDirectory(s.Out);

        ActionLog?.Invoke($"Start translate file: {s.FilePath}");
        ActionLog?.Invoke($"Source culture: {s.CultureIn}");
        ActionLog?.Invoke($"Target cultures: {string.Join(", ", s.CultureOut)}");
        ActionLog?.Invoke($"Output folder: {s.Out}");

        await ResxReader(
            inputResx: s.FilePath,
            outFolder: s.Out,
            inputLang: s.CultureIn,
            outLangs: s.CultureOut
        );

        ActionLog?.Invoke($"Finish translate file: {s.FilePath}");
    }

    private async Task ResxReader(string inputResx, string outFolder, string inputLang, List<string> outLangs)
    {
        try
        {
            var nameOutResx = Path.GetFileName(inputResx).Split('.')[0];

            var localizedResx = new Dictionary<string, List<ResXDataNode>>();
            foreach (var culture in outLangs)
                localizedResx[culture] = new List<ResXDataNode>();

            using (ResXResourceReader resxReader = new ResXResourceReader(inputResx))
            {
                resxReader.UseResXDataNodes = true;

                foreach (DictionaryEntry entry in resxReader)
                {
                    string key = (string)entry.Key;
                    var node = (ResXDataNode)entry.Value;

                    ActionLog.Invoke($"Init translate key '{key}'...");
                    // Получаем значение БЕЗ вызова GetValue (без десериализации сложных типов)
                    string typeName = node.GetValueTypeName((ITypeResolutionService?)null);
                    // Пропускаем всё, кроме строк
                    if (!typeName.StartsWith("System.String"))
                    {
                        // Копируем оригинальный узел во все выходные .resx как есть
                        foreach (var culture in outLangs)
                            localizedResx[culture].Add(node);
                        continue;
                    }

                    string value = node.GetValue((ITypeResolutionService?)null) as string;
                    if (string.IsNullOrWhiteSpace(value))
                        continue;

                    foreach (var culture in outLangs)
                    {   //Перевод на culture (ru en ...)
                        var translated = await Translater.TranslateAsync(value, sourceLang: inputLang, targetLang: culture);
                        if(!string.IsNullOrWhiteSpace(translated))
                        {
                            Func<Type, string> typeNameConverter = t => t.AssemblyQualifiedName!;
                            var translatedNode = new ResXDataNode(key, translated, typeNameConverter);
                            translatedNode.Comment = node.Comment;

                            localizedResx[culture].Add(translatedNode);
                            ActionLog.Invoke($"Translate [{culture}] {key} = {translated}");
                        }
                        else
                        {
                            ActionLog.Invoke($"Nope translate [{culture}] {key} = {value}");
                            localizedResx[culture].Add(node);
                        }

                        await Task.Delay(100);
                    }
                }
            }

            // Сохраняем каждый перевод в свой .resx
            foreach (var (culture, nodes) in localizedResx)
            {
                string outputFile = Path.Combine(outFolder, $"{nameOutResx}.{culture}.resx");
                using var writer = new ResXResourceWriter(outputFile);
                foreach (var node in nodes)
                    writer.AddResource(node);
                writer.Generate();

                ActionLog.Invoke($"Save: {outputFile}");
            }
        }
        catch (Exception ex)
        {
            ActionLog.Invoke($"Exception: {ex.Message} | {ex.StackTrace} | { ex.Source}");
        }
    }
}
