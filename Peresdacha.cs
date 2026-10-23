public class Employee
{
    private string name;
    private float salary;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public float Salary
    {
        get { return salary; }
        set { salary = value; }
    }

    public Employee(string name, float salary)
    {
        this.name = name;
        this.salary = salary;
    }

    public virtual void Work()
    {
        Console.WriteLine("SMOTRITE SOTRUDNIK IGRAET V PASYANS");
    }
}

public class Teacher : Employee
{   
    public Teacher(string name, float salary) : base(name, salary) {}

    public void Teach()
    {
        Console.WriteLine("Prepod uchit...nu ladno uchitel prepodayot.");
    }

    public override void Work()
    {
        Console.WriteLine("Uchitel uchit.");
    }
}

public class Programmer : Employee
{
    public Programmer(string name, float salary) : base(name, salary) {}

    public void Code()
    {
        Console.WriteLine("Programmist chto to pechataet. A, tochno, ya mamkin programmist.");
    }

    public override void Work()
    {
        Console.WriteLine("Programmist pishet.");
    }
}

public class Doctor : Employee
{
    public Doctor(string name, float salary) : base(name, salary) { }

    public void Treat()
    {
        Console.WriteLine("Othil menya pls chuvak.");
    }

    public override void Work()
    {
        Console.WriteLine("Vrach menya lechit.");
    }
}
class Program
{
    static void Main()
    {
        Console.WriteLine("TESTIK");

        Teacher teacher = new Teacher("Valentina", 100500f);
        Programmer programmer = new Programmer("Ivan", 350000f);
        Doctor doctor = new Doctor("Saveliya", 250500f);

        List<Employee> employees = new List<Employee> { teacher, programmer, doctor };

        foreach (Employee emp in employees)
        {
            Console.WriteLine("Imya: " + emp.Name + " | Z/P: " + emp.Salary);
            emp.Work();
            Console.WriteLine();
        }
    }
}

varik 19
using System.Security.Cryptography.X509Certificates;

public class PortProgramma()
{
    

    public class Shvartovka
    {
        public string Nazvaniye { get; set; }
        public Shvartovka(string nazvanyie)
        {
            Nazvaniye = nazvanyie;
        }

        public void Operate()
        {
            Console.WriteLine("Eto systema shvartovki");
        }
    }

    public class Sudno
    {
        
    }


}
