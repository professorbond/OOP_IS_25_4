class Program
{
    static void Main()
    {
        Teacher teacher = new Teacher("Анна", 150000);
        Programmer programmer = new Programmer("Алексей", 300000);
        Doctor doctor = new Doctor("Иван", 200000);

        teacher.Work();
        programmer.Work();
        doctor.Work();
    }
}