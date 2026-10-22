using System;

class Customer
{
    public string Name {  get; set; }
    public List<Item> Items {  get; set; }
    public Customer(string name)
    {
        Name = name;
        Items = new List<Item>();
    }

    public void CustomersItems(Item item)
    {
        Items.Add(item);
    }

    public void ShowInfo()
    {
        Console.WriteLine($"Покупатель {Name}");
    }
}

class Item
{
    public string Name { get; set; }
    public Item(string name) 
    { 
        Name = name; 
    }
    public void ShowInfo()
    {
        Console.WriteLine($"Товар {Name}");
    }
}

class Category
{
    public string Name { get; set; }
    private List<Item> items = new List<Item>();
    private bool isClosed = false;

    public Category(string name)
    {
        Name = name;
    }
    public void AddItem(Item item)
    {
        if (isClosed)
            throw new InvalidOperationException(
                "Категория закрыта");

        items.Add(item);
    }
    public void ShowInfo()
    {
        Console.WriteLine($"Категория {Name}");
        foreach (Item item in items)
        {
            item.ShowInfo();
        }
    }
    public void Close()
    {
        items.Clear();
        isClosed = true;
    }
}

class Shop
{
    public string Name { get; set; }

    private List<Category> categories = new List<Category>();

    private bool isClosed = false;

    public Shop(string name)
    {
        Name = name;
    }
    public Category AddCategory(string name)
    {
        if (isClosed)
            throw new InvalidOperationException(
                "Магазин закрыт");

        Category category = new Category(name);
        categories.Add(category);

        return category;
    }

    public void ShowInfo()
    {
        if (isClosed)
        {
            Console.WriteLine("Магазин закрыт");
            return;
        }

        Console.WriteLine($"Магазин: {Name}");

        foreach (Category category in categories)
        {
            category.ShowInfo();
        }
    }

    public void Close()
    {
        foreach (Category category in categories)
        {
            category.Close();
        }

        categories.Clear();
        isClosed = true;

        Console.WriteLine("Магазин закрыт");
    }
}



interface IMoney
{
    void Transaction();
}

class Kaspi: IMoney
{
    public void Transaction()
    {
        Console.WriteLine("Перевод на Каспи");
    }
}

class Halyk : IMoney
{
    public void Transaction()
    {
        Console.WriteLine("Перевод на Халык");
    }
}


