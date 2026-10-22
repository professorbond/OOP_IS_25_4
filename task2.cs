//task1
class product
{
    public string Name;
    public decimal Price;
    public product(string name, decimal price)
    {
        Name = name
        Price = price 
    }
} 
class Category
{
    public string name
    public List <product> Product = new List<product>();
    public Category(string name)
    {
        name = name;
    }
}
class Store
{
    public string Name;
    public Store(string name)
    {
        Name = name;
    }
}
class Customer
{
    public string Name;
    public Customer(string name)
    {
        Name = name;
    }
}
class program
{
    static void Main()
    {
        Category phone = new Category("Телефоны");
        Category computer = new Category("Компьютеры");

        product p1 = new product("Iphone", 300000);
        product p2 = new product("ноутбук", 400000);
        phone.Product.add(p1);
        computer.Product.add(p2); 
        Store store = new Store("Магазин 1");
        Customer customer = new Customer("Игорь");
        Console.Writeline(customer.Name);
        Console.Writeline(store.Name);
        Console.Writeline(phone.name + ": "+ p1.Name);
        Console.Writeline(computer.name + ": "+ p2.Name);
    }
}
