<div align="center">

# LibreTranslate

</div>

<div align="center" style="margin: 20px 0; padding: 10px; background: #1c1917; border-radius: 10px;">
  <strong>🌐 Language: </strong>
  
  <a href="./libretranslate.md" style="color: #F5F752; margin: 0 10px;">
    🇷🇺 Russian
  </a>
  | 
  <span style="color: #0891b2; margin: 0 10px;">
    ✅ 🇺🇸 English (current)
  </span>
</div>

---

### API - взаимодействия

- Адрес до локального сервера(указан мой на моей машине Ubuntu):

```
http://<IP>:<PORT>/translate
```

- Тело `Post` запрос (Можно протестировать через Postman)

```
{
  "q": "Стоимость ремонта: $[[PH0]], Повреждение: [[PH1]]",
  "source": "ru",
  "target": "en",
  "format": "text"
}
```

### Управление запуском venv - Libretranslate

```sh
source venv/bin/activate
pip install -r requirements.txt
# Дальше нужно сунуть модели под языки вручную translate-ru_en.argosmodel и др.
pip install argostranslate
python -m argostranslate.package install translate-en_ru.argosmodel
python -m argostranslate.package install translate-ru_en.argosmodel
# или
# argos-translate-cli --install-package translate-en_ru.argosmodel
# argos-translate-cli --install-package translate-ru_en.argosmodel

# Сохранятся в ~/.local/share/argos-translate/packages/
# проверка
ls ~/.local/share/argos-translate/packages/
# Если модели есть можно стартовать
python3 main.py --host 0.0.0.0
```

### Базовое управление Docker - Libretranslate

> Запуск контейнера с системой перевода

```sh
docker run -d --name libretranslate -p 5000:5001 libretranslate/libretranslate
```

> или если контейнер уже зарегистрирован и его имя `libretranslate`

```sh
docker container start libretranslate
```

> Просмотр лога на контейнере

```sh
docker exec -it libre /bin/bash
```

> Проверка всех

```sh
docker ps -a
```

> Подключение к запущенному контейнеру

```sh
docker exec -it libre /bin/sh
```

> Создать образ из контейнера (слепок)

```sh
docker commit libre_custom mylibretranslate:custom
```

- libre_custom — имя или ID контейнера
- mylibretranslate:custom — имя и тег нового образа

> Использование нового образа в будущем

```sh
docker run -d --name mytranslate_v2 -p 5000:5000 mylibretranslate:custom
```

<details>
<summary>Показать поддерживаемые коды языков</summary>

```json
[
	{
		"code": "en",
		"name": "английский"
	},
	{
		"code": "sq",
		"name": "албанский"
	},
	{
		"code": "ar",
		"name": "арабский"
	},
	{
		"code": "az",
		"name": "азербайджанский"
	},
	{
		"code": "eu",
		"name": "Basque"
	},
	{
		"code": "bn",
		"name": "бенгальский"
	},
	{
		"code": "bg",
		"name": "болгарский"
	},
	{
		"code": "ca",
		"name": "каталонский"
	},
	{
		"code": "zh-Hans",
		"name": "китайский"
	},
	{
		"code": "zh-Hant",
		"name": "китайский (традиционный)"
	},
	{
		"code": "cs",
		"name": "чешский"
	},
	{
		"code": "da",
		"name": "датский"
	},
	{
		"code": "nl",
		"name": "голландский"
	},
	{
		"code": "eo",
		"name": "эсперанто"
	},
	{
		"code": "et",
		"name": "эстонский"
	},
	{
		"code": "fi",
		"name": "финский"
	},
	{
		"code": "fr",
		"name": "французский"
	},
	{
		"code": "gl",
		"name": "Galician"
	},
	{
		"code": "de",
		"name": "немецкий"
	},
	{
		"code": "el",
		"name": "греческий"
	},
	{
		"code": "he",
		"name": "иврит"
	},
	{
		"code": "hi",
		"name": "хинди"
	},
	{
		"code": "hu",
		"name": "венгерский"
	},
	{
		"code": "id",
		"name": "индонезийский"
	},
	{
		"code": "ga",
		"name": "ирландский"
	},
	{
		"code": "it",
		"name": "итальянский"
	},
	{
		"code": "ja",
		"name": "японский"
	},
	{
		"code": "ko",
		"name": "корейский"
	},
	{
		"code": "lv",
		"name": "латвийский"
	},
	{
		"code": "lt",
		"name": "литовский"
	},
	{
		"code": "ms",
		"name": "малайский"
	},
	{
		"code": "nb",
		"name": "норвежский"
	},
	{
		"code": "fa",
		"name": "персидский"
	},
	{
		"code": "pl",
		"name": "польский"
	},
	{
		"code": "pt",
		"name": "португальский"
	},
	{
		"code": "pt-BR",
		"name": "португальский (бразильский)"
	},
	{
		"code": "ro",
		"name": "румынский"
	},
	{
		"code": "ru",
		"name": "русский"
	},
	{
		"code": "sk",
		"name": "словацкий"
	},
	{
		"code": "sl",
		"name": "словенский"
	},
	{
		"code": "es",
		"name": "испанский"
	},
	{
		"code": "sv",
		"name": "шведский"
	},
	{
		"code": "tl",
		"name": "тагальский"
	},
	{
		"code": "th",
		"name": "тайский"
	},
	{
		"code": "tr",
		"name": "турецкий"
	},
	{
		"code": "uk",
		"name": "украинский"
	},
	{
		"code": "ur",
		"name": "урду"
	}
]
```

</details>
