using System;
using System.Collections.Generic;

namespace ConfigurationManagerExample
{
    public class ConfigurationManager
    {
        private static ConfigurationManager _instance;
        private ConfigurationManager()
        {
            Settings = new Dictionary<string, string>();
        }
        public static ConfigurationManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ConfigurationManager();
                }
                return _instance;
            }
        }
        public Dictionary<string, string> Settings { get; private set; }
        public void SetSetting(string key, string value)
        {
            if (Settings.ContainsKey(key))
            {
                Settings[key] = value;
            }
            else
            {
                Settings.Add(key, value);
            }
        }
        public string GetSetting(string key)
        {
            return Settings.ContainsKey(key) ? Settings[key] : "Налаштування не знайдено";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nМеню:");
                Console.WriteLine("1. Додати/змінити налаштування");
                Console.WriteLine("2. Переглянути налаштування");
                Console.WriteLine("3. Вийти");
                Console.Write("Оберіть дію: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.Write("Введіть ключ: ");
                        string key = Console.ReadLine();
                        Console.Write("Введіть значення: ");
                        string value = Console.ReadLine();
                        ConfigurationManager.Instance.SetSetting(key, value);
                        Console.WriteLine("Налаштування оновлено.");
                        break;

                    case "2":
                        Console.WriteLine("\nПоточні налаштування:");
                        foreach (var setting in ConfigurationManager.Instance.Settings)
                        {
                            Console.WriteLine($"{setting.Key}: {setting.Value}");
                        }
                        break;

                    case "3":
                        return;

                    default:
                        Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                        break;
                }
            }
        }
    }
}