# Частотный словарь

Это консольное приложение на языке C#, которое реализует частотный словарь. Оно парсит текст из txt файла или из файла json, полученного в результате экспорта диалогов мессенджера телеграмм.

# Запуск приложения

Скачайте репозиторий с помощью команды
'''bash
git clone https://github.com/BogaRU/FrequencyDictionary.git
'''
Запустите проект в Visual Studio и следуйте инструкциям приложения.

## Описание функционала

Приложение поддерживает следующие функции:

- Парсинг текста из txt файла
- Парсинг текста из файла json, полученного в результате экспорта диалогов мессенджера телеграмм
- Построение частотного словаря пар на основе текста
- Вывод топ N самых часто встречающихся слов по ключу (в качестве ключа может быть любое введенное слово)

# Как использовать приложение

1. Запустите приложение
2. Выберите источник текста - txt или json файл
3. Укажите путь к файлу с текстом
4. Постройте частотный словарь
5. Введите количество наиболее часто встречаемых слов, которые будут выводиться
6. Получите результат

# Пример использования
'''bash
Введите источник текста:
1. TXT файл
2. JSON файл

> 1

Введите путь к файлу:

> C:\FrequencyDictionary\HarryPotterText.txt

Введите количество выводимых слов с наибольшей частотностью:

> 6

Введите любое слово/предложение:

> harry

Частотный словарь говорит:

harry and ron were delighted to hear
'''
