using System;
using System.Collections.Generic;

public interface IDataPrototype
{
    IDataPrototype Clone();
    void DisplayData();
    string GetData();
    void SetData(string data);
}
public class CsvData : IDataPrototype
{
    private string _data;
    public CsvData(string data)
    {
        _data = data;
    }
    public IDataPrototype Clone()
    {
        return new CsvData(_data);
    }
    public void DisplayData()
    {
        Console.WriteLine($"CSV дані: {_data}");
    }
    public string GetData()
    {
        return _data;
    }
    public void SetData(string data)
    {
        _data = data;
    }
}
public class JsonData : IDataPrototype
{
    private string _data;
    public JsonData(string data)
    {
        _data = data;
    }
    public IDataPrototype Clone()
    {
        return new JsonData(_data);
    }
    public void DisplayData()
    {
        Console.WriteLine($"JSON дані: {_data}");
    }
    public string GetData()
    {
        return _data;
    }
    public void SetData(string data)
    {
        _data = data;
    }
}
public class XmlData : IDataPrototype
{
    private string _data;
    public XmlData(string data)
    {
        _data = data;
    }
    public IDataPrototype Clone()
    {
        return new XmlData(_data);
    }
    public void DisplayData()
    {
        Console.WriteLine($"XML дані: {_data}");
    }
    public string GetData()
    {
        return _data;
    }
    public void SetData(string data)
    {
        _data = data;
    }
}
public interface IDataAdapter
{
    IDataPrototype ConvertData(IDataPrototype sourceData);
}
public class CsvToJsonAdapter : IDataAdapter
{
    public IDataPrototype ConvertData(IDataPrototype sourceData)
    {
        string csvData = sourceData.GetData();
        string jsonData = $"{{ \"data\": \"{csvData}\" }}"; 
        return new JsonData(jsonData);
    }
}
public class CsvToXmlAdapter : IDataAdapter
{
    public IDataPrototype ConvertData(IDataPrototype sourceData)
    {
        string csvData = sourceData.GetData();
        string xmlData = $"<data>{csvData}</data>"; 
        return new XmlData(xmlData);
    }
}
class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\nВиберіть вихідний формат даних:");
            Console.WriteLine("1. CSV");
            Console.WriteLine("2. Вийти");
            Console.Write("Ваш вибір: ");
            string sourceChoice = Console.ReadLine();
            if (sourceChoice == "2") break;
            Console.WriteLine("Виберіть цільовий формат даних:");
            Console.WriteLine("1. JSON");
            Console.WriteLine("2. XML");
            Console.Write("Ваш вибір: ");
            string targetChoice = Console.ReadLine();
            IDataPrototype sourceData = new CsvData("name,age\nJohn,30\nJane,25");
            IDataAdapter adapter = targetChoice switch
            {
                "1" => new CsvToJsonAdapter(),
                "2" => new CsvToXmlAdapter(),
                _ => null
            };
            if (adapter == null)
            {
                Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                continue;
            }
            Console.WriteLine("\nВихідні дані:");
            sourceData.DisplayData();
            IDataPrototype convertedData = adapter.ConvertData(sourceData);
            Console.WriteLine("\nПеретворені дані:");
            convertedData.DisplayData();
        }
    }
}