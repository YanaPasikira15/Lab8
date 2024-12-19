using System;
using System.Collections.Generic;

namespace GraphVisualizationApp
{
    public interface IGraph
    {
        void Draw(Dictionary<string, double> data);
    }
    public class LineGraph : IGraph
    {
        public void Draw(Dictionary<string, double> data)
        {
            Console.WriteLine("\nЛінійний графік:");
            foreach (var point in data)
            {
                Console.WriteLine($"{point.Key}: {point.Value}");
            }
        }
    }
    public class BarGraph : IGraph
    {
        public void Draw(Dictionary<string, double> data)
        {
            Console.WriteLine("\nСтовпчиковий графік:");
            foreach (var point in data)
            {
                Console.Write($"{point.Key}: ");
                for (int i = 0; i < (int)point.Value; i++)
                {
                    Console.Write("|");
                }
                Console.WriteLine();
            }
        }
    }
    public class PieChart : IGraph
    {
        public void Draw(Dictionary<string, double> data)
        {
            Console.WriteLine("\nКругова діаграма:");
            double total = 0;
            foreach (var value in data.Values)
            {
                total += value;
            }
            foreach (var point in data)
            {
                double percentage = (point.Value / total) * 100;
                Console.WriteLine($"{point.Key}: {percentage:F2}%");
            }
        }
    }
    public abstract class GraphFactory
    {
        public abstract IGraph CreateGraph();
    }
    public class LineGraphFactory : GraphFactory
    {
        public override IGraph CreateGraph()
        {
            return new LineGraph();
        }
    }
    public class BarGraphFactory : GraphFactory
    {
        public override IGraph CreateGraph()
        {
            return new BarGraph();
        }
    }
    public class PieChartFactory : GraphFactory
    {
        public override IGraph CreateGraph()
        {
            return new PieChart();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nОберіть тип графіка:");
                Console.WriteLine("1. Лінійний графік");
                Console.WriteLine("2. Стовпчиковий графік");
                Console.WriteLine("3. Кругова діаграма");
                Console.WriteLine("4. Вийти");
                Console.Write("Ваш вибір: ");
                string choice = Console.ReadLine();
                if (choice == "4") break;
                GraphFactory factory = choice switch
                {
                    "1" => new LineGraphFactory(),
                    "2" => new BarGraphFactory(),
                    "3" => new PieChartFactory(),
                    _ => null
                };
                if (factory == null)
                {
                    Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                    continue;
                }
                Console.WriteLine("Введіть дані для візуалізації у форматі 'назва=значення', розділені комами:");
                string input = Console.ReadLine();
                var data = new Dictionary<string, double>();
                foreach (var item in input.Split(','))
                {
                    var parts = item.Split('=');
                    if (parts.Length == 2 && double.TryParse(parts[1], out double value))
                    {
                        data[parts[0]] = value;
                    }
                }
                IGraph graph = factory.CreateGraph();
                graph.Draw(data);
            }
        }
    }
}
