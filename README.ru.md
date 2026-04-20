<div align="center">

# LibreResxTranslate

### Библиотека для автоматической локализации `.resx` ресурсов .NET проектов через LibreTranslate.

<p align="center">
  <img src="https://shields.dvurechensky.pro/nuget/v/LibreResxTranslate">
  <img src="https://shields.dvurechensky.pro/nuget/dt/LibreResxTranslate">
  <img src="https://shields.dvurechensky.pro/badge/license-MIT-green">
</p>

</div>

<div align="center" style="margin: 20px 0; padding: 10px; background: #1c1917; border-radius: 10px;">
  <strong>🌐 Язык: </strong>
  
  <span style="color: #F5F752; margin: 0 10px;">
    ✅ 🇷🇺 Русский (текущий)
  </span>
  | 
  <a href="./README.md" style="color: #0891b2; margin: 0 10px;">
    🇺🇸 English
  </a>
</div>

---

> [!TIP]
> Позволяет генерировать языковые версии ресурсов для существующих WinForms, WPF и desktop-приложений без ручного перевода строк.

---

## Возможности

- Перевод существующих `.resx` файлов на несколько языков
- Пакетная обработка папок
- Перевод отдельных файлов
- Поддержка локального LibreTranslate сервера
- Поддержка удалённых LibreTranslate API
- Работа через JSON-конфигурацию
- Логирование через события
- Расширяемая архитектура переводчиков
- Подходит для CI/CD автоматизации

---

## Где полезно

- Локализация legacy WinForms приложений
- Перевод WPF ресурсов
- Создание мультиязычных desktop-приложений
- Перевод старых одноязычных проектов
- Локализация внутренних корпоративных систем
- Полностью локальный pipeline перевода

---

## Установка

```bash
dotnet add package LibreResxTranslate
```

---

## Быстрый старт

```csharp
using LibreResxTranslate.Components;
using LibreResxTranslate.Services.Settings;
using LibreResxTranslate.Services.Translater;

ISettingsService settings = new SettingsService();

settings.ActionLog += Console.WriteLine;
settings.LoadSettings();

if (!settings.IsValid)
{
    Console.WriteLine("Некорректная конфигурация.");
    return;
}

var translator = new WinformsLocalizedTranslater(
    TypeTranslateEnum.Libre,
    settings);

translator.ActionLog += Console.WriteLine;

await translator.Translate();
```

---

## Пример конфигурации

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

## Режимы работы

### Folder Mode

Перевод всех `.resx` файлов из указанной директории.

### File Mode

Перевод конкретного `.resx` файла.

---

## Поддерживаемые переводчики

### LibreTranslate

- Локальный сервер
- Удалённый API
- Self-hosted инфраструктура
- Подходит для приватного использования

> [!IMPORTANT]
> [Настройка LibreTranslate](docs/libretranslate.ru.md)

---

## Почему это полезно?

Ручная локализация `.resx` файлов занимает много времени и превращается в рутину.

Эта библиотека автоматизирует процесс и позволяет полностью контролировать инфраструктуру перевода.

Особенно полезно компаниям, где нельзя отправлять строки интерфейса во внешние облачные сервисы.

---

## Roadmap

- CLI версия
- GUI менеджер

---

## Лицензия

MIT
