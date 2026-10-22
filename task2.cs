using System;
using System.Collections.Generic;

// ===== Задача 1 =====
class Furniture
{
    public string Name;
    public Furniture(string n) => Name = n;
}

class Equipment
{
    public string Name;
    public Equipment(string n) => Name = n;
}

class ServiceSystem
{
    public string Type;
    public ServiceSystem(string t) => Type = t;
    public void Work() => Console.WriteLine("система " + Type + " работает");
}

class Floor
{
    public int Number;
    public ServiceSystem System;
    public List<Furniture> Furnitures = new List<Furniture>();
    public List<Equipment> Equipments = new List<Equipment>();

    public Floor(int n, string t)
    {
        Number = n;
        System = new ServiceSystem(t);
    }

    public void ShowInfo()
    {
        Console.WriteLine("Этаж " + Number + " (" + System.Type + ")");
        Console.WriteLine("  мебель: " + Furnitures.Count + ", оборудование: " + Equipments.Count);
    }
}

class Employee
{
    public string Name;
    public string Position;
    public List<Floor> Floors = new List<Floor>();

    public Employee(string n, string p)
    {
        Name = n;
        Position = p;
    }

    public void ShowFloors()
    {
        Console.Write(Name + ": ");
        foreach (var f in Floors)
            Console.Write(f.Number + " ");
        Console.WriteLine();
    }
}

// ===== Задача 2 =====

// исходные классы из задания (без изменений)
class TextFile
{
    public string Content { get; set; }
    public TextFile(string content) { Content = content; }

    public void Show()
    {
        Console.WriteLine(Content);
    }
}

class TextMessage
{
    public string Content { get; set; }
    public TextMessage(string content) { Content = content; }

    public void Show()
    {
        Console.WriteLine(Content);
    }
}

// общий абстрактный класс — унификация
abstract class TextData
{
    public string Content { get; set; }

    public TextData(string content)
    {
        Content = content;
    }

    public virtual void Show()
    {
        Console.WriteLine(Content);
    }

    // перегрузка + для двух объектов одного типа
    public static TextData operator +(TextData a, TextData b)
    {
        if (a.GetType() != b.GetType())
            throw new Exception("нельзя складывать разные типы");

        return (TextData)Activator.CreateInstance(a.GetType(), a.Content + " " + b.Content);
    }
}

class TextFile2 : TextData
{
    public TextFile2(string content) : base(content) { }
    public override void Show() => Console.WriteLine("Файл: " + Content);
}

class TextMessage2 : TextData
{
    public TextMessage2(string content) : base(content) { }
    public override void Show() => Console.WriteLine("Сообщение: " + Content);
}

class Program
{
    // общий обработчик — принимает любой TextData
    static void ProcessText(TextData d)
    {
        d.Show();
    }

    static void Main()
    {
        // --- гостиница ---
        Floor f1 = new Floor(1, "уборка");
        Floor f2 = new Floor(2, "отопление");

        Furniture table = new Furniture("Стол");
        f1.Furnitures.Add(table);
        f1.Furnitures.Add(new Furniture("Кровать"));
        f1.Equipments.Add(new Equipment("Телевизор"));

        // переносим стол на 2 этаж
        f1.Furnitures.Remove(table);
        f2.Furnitures.Add(table);

        Employee ivan = new Employee("Иванов", "админ");
        Employee petrova = new Employee("Петрова", "горничная");

        ivan.Floors.Add(f1);
        ivan.Floors.Add(f2);
        petrova.Floors.Add(f1);

        f1.ShowInfo();
        f2.ShowInfo();
        ivan.ShowFloors();
        petrova.ShowFloors();
        f1.System.Work();
        f2.System.Work();

        // --- текст ---
        Console.WriteLine();

        // исходные классы из задания — просто проверим, что работают
        TextFile oldFile = new TextFile("старый файл");
        TextMessage oldMsg = new TextMessage("старое сообщение");
        oldFile.Show();
        oldMsg.Show();

        // новые классы с унификацией
        TextFile2 a = new TextFile2("Привет");
        TextFile2 b = new TextFile2("мир");
        TextMessage2 m1 = new TextMessage2("Как дела?");
        TextMessage2 m2 = new TextMessage2("Норм");

        ProcessText(a);
        ProcessText(m1);
        ProcessText(a + b);   // Файл: Привет мир
        ProcessText(m1 + m2); // Сообщение: Как дела? Норм

        // проверяем, что разные типы складывать нельзя
        try
        {
            ProcessText(a + m1);
        }
        catch (Exception e)
        {
            Console.WriteLine("Ошибка: " + e.Message);
        }
    }
}