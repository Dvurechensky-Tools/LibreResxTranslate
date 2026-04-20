<div align="center">

# LibreTranslate

</div>

<div align="center" style="margin: 20px 0; padding: 10px; background: #1c1917; border-radius: 10px;">
  <strong>🌐 Language: </strong>
  
  <a href="./libretranslate.ru.md" style="color: #F5F752; margin: 0 10px;">
    🇷🇺 Russian
  </a>
  | 
  <span style="color: #0891b2; margin: 0 10px;">
    ✅ 🇺🇸 English (current)
  </span>
</div>

---

### API Interaction

- Address of the local server (example: running on my Ubuntu machine):

```text
http://<IP>:<PORT>/translate
```

- `POST` request body (can be tested in Postman):

```json
{
	"q": "Repair cost: $[[PH0]], Damage: [[PH1]]",
	"source": "ru",
	"target": "en",
	"format": "text"
}
```

---

### Managing `venv` Startup — LibreTranslate

```sh
source venv/bin/activate
pip install -r requirements.txt

# Then place language models manually, such as:
# translate-ru_en.argosmodel
# translate-en_ru.argosmodel

pip install argostranslate

python -m argostranslate.package install translate-en_ru.argosmodel
python -m argostranslate.package install translate-ru_en.argosmodel

# or

argos-translate-cli --install-package translate-en_ru.argosmodel
argos-translate-cli --install-package translate-ru_en.argosmodel

# Models will be stored in:
~/.local/share/argos-translate/packages/

# Check installed models
ls ~/.local/share/argos-translate/packages/

# If models are installed, start the server:
python3 main.py --host 0.0.0.0
```

---

### Basic Docker Management — LibreTranslate

> Start a container with the translation system

```sh
docker run -d --name libretranslate -p 5000:5001 libretranslate/libretranslate
```

> Or if the container already exists and is named `libretranslate`

```sh
docker container start libretranslate
```

> View container logs / open shell

```sh
docker exec -it libre /bin/bash
```

> Show all containers

```sh
docker ps -a
```

> Connect to a running container

```sh
docker exec -it libre /bin/sh
```

> Create an image snapshot from a container

```sh
docker commit libre_custom mylibretranslate:custom
```

- `libre_custom` — container name or ID
- `mylibretranslate:custom` — new image name and tag

> Use the custom image later

```sh
docker run -d --name mytranslate_v2 -p 5000:5000 mylibretranslate:custom
```

---

<details>
<summary>Show supported language codes</summary>

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
