using System;

namespace TechProductFactoryApp
{
    public interface IScreen
    {
        string GetDetails();
    }
    public interface IProcessor
    {
        string GetDetails();
    }
    public interface ICamera
    {
        string GetDetails();
    }
    public class SmartphoneScreen : IScreen
    {
        public string GetDetails() => "Сенсорний екран 6.5 дюймів";
    }
    public class SmartphoneProcessor : IProcessor
    {
        public string GetDetails() => "Процесор Snapdragon 888";
    }
    public class SmartphoneCamera : ICamera
    {
        public string GetDetails() => "Камера 108 МП";
    }
    public class LaptopScreen : IScreen
    {
        public string GetDetails() => "Екран 15.6 дюймів з роздільною здатністю 4K";
    }
    public class LaptopProcessor : IProcessor
    {
        public string GetDetails() => "Процесор Intel Core i7";
    }
    public class LaptopCamera : ICamera
    {
        public string GetDetails() => "Вебкамера 720p";
    }
    public class TabletScreen : IScreen
    {
        public string GetDetails() => "Екран 10.1 дюймів з IPS матрицею";
    }
    public class TabletProcessor : IProcessor
    {
        public string GetDetails() => "Процесор Apple M1";
    }
    public class TabletCamera : ICamera
    {
        public string GetDetails() => "Камера 12 МП з ультрашироким кутом";
    }
    public interface ITechProductFactory
    {
        IScreen CreateScreen();
        IProcessor CreateProcessor();
        ICamera CreateCamera();
    }
    public class SmartphoneFactory : ITechProductFactory
    {
        public IScreen CreateScreen() => new SmartphoneScreen();
        public IProcessor CreateProcessor() => new SmartphoneProcessor();
        public ICamera CreateCamera() => new SmartphoneCamera();
    }
    public class LaptopFactory : ITechProductFactory
    {
        public IScreen CreateScreen() => new LaptopScreen();
        public IProcessor CreateProcessor() => new LaptopProcessor();
        public ICamera CreateCamera() => new LaptopCamera();
    }
    public class TabletFactory : ITechProductFactory
    {
        public IScreen CreateScreen() => new TabletScreen();
        public IProcessor CreateProcessor() => new TabletProcessor();
        public ICamera CreateCamera() => new TabletCamera();
    }
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nОберіть тип продукту для створення:");
                Console.WriteLine("1. Смартфон");
                Console.WriteLine("2. Ноутбук");
                Console.WriteLine("3. Планшет");
                Console.WriteLine("4. Вийти");
                Console.Write("Ваш вибір: ");
                string choice = Console.ReadLine();
                if (choice == "4") break;

                ITechProductFactory factory = choice switch
                {
                    "1" => new SmartphoneFactory(),
                    "2" => new LaptopFactory(),
                    "3" => new TabletFactory(),
                    _ => null
                };

                if (factory == null)
                {
                    Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                    continue;
                }
                var screen = factory.CreateScreen();
                var processor = factory.CreateProcessor();
                var camera = factory.CreateCamera();
                Console.WriteLine("\nСтворений продукт містить такі компоненти:");
                Console.WriteLine($"Екран: {screen.GetDetails()}");
                Console.WriteLine($"Процесор: {processor.GetDetails()}");
                Console.WriteLine($"Камера: {camera.GetDetails()}");
            }
        }
    }
}
