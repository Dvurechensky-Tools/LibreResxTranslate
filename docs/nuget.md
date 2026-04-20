# LibreResxTranslate

Automated `.resx` localization library for .NET projects using LibreTranslate.

Generate multilingual resource files for existing WinForms, WPF, and desktop applications without manually editing translations.

---

## Features

- Translate existing `.resx` files into multiple languages
- Supports folder-based batch translation
- Supports single file translation
- Works with self-hosted LibreTranslate servers
- Supports remote LibreTranslate endpoints
- JSON configuration based workflow
- Event-based logging
- Extensible translator architecture
- Suitable for CI/CD automation

---

## Use Cases

- Localizing legacy WinForms applications
- Translating WPF resource files
- Creating multilingual desktop apps
- Migrating old single-language projects
- Internal company software localization
- Offline translation pipelines

---

## Installation

```bash
dotnet add package LibreResxTranslate
```

---

## Quick Start

```csharp
using LibreResxTranslate.Components;
using LibreResxTranslate.Services.Settings;
using LibreResxTranslate.Services.Translater;

ISettingsService settings = new SettingsService();

settings.ActionLog += Console.WriteLine;
settings.LoadSettings();

if (!settings.IsValid)
{
    Console.WriteLine("Invalid configuration.");
    return;
}

var translator = new WinformsLocalizedTranslater(
    TypeTranslateEnum.Libre,
    settings);

translator.ActionLog += Console.WriteLine;

await translator.Translate();
```

---

## Example Configuration

```json
{
	"IsURL": false,
	"Url": "",
	"IP": "127.0.0.1",
	"PORT": "5000",
	"Protocol": "http",
	"Entries": [
		{
			"Flag": "Folder",
			"Type": "WinFormsLocalized",
			"In": "C:\\Project\\Resources",
			"Out": "C:\\Project\\Output",
			"CultureIn": "en",
			"CultureOut": ["ru", "de", "fr"]
		}
	]
}
```

---

## Supported Modes

### Folder Mode

Translate all `.resx` files from a directory.

### File Mode

Translate a specific `.resx` file.

---

## Supported Translation Providers

### LibreTranslate

- Local server
- Remote endpoint
- Self-hosted environments
- Private infrastructure ready

> Info startup Libretranslate - https://github.com/Dvurechensky-Tools/LibreResxTranslate/blob/main/docs/libretranslate.md

---

## Why Use This Library?

Manual `.resx` localization is slow and repetitive.

This package automates the process while allowing you to keep translation infrastructure under your control.

Perfect for companies that need private or offline localization workflows.

---

## License

MIT
