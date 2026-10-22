using System;
using System.Collections.Generic;

class Doctor
{
    public string Name { get; }

    public Doctor(string name)
    {
        Name = name;
    }

    public void Work()
    {
        Console.WriteLine($"Врач {Name} продолжает работать.");
    }
}

class Archive
{
    private List<string> records = new List<string>();

    public void AddRecord(string record)
    {
        records.Add(record);
    }

    public void ShowRecords()
    {
        foreach (string record in records)
            Console.WriteLine($"  {record}");
    }
}

class Department
{
    private List<Doctor> doctors = new List<Doctor>();
    private Archive? archive;

    public string Name { get; }
    public bool IsClosed { get; private set; }

    public Department(string name)
    {
        Name = name;
        archive = new Archive();
    }

    public void AddDoctor(Doctor doctor)
    {
        if (IsClosed)
        {
            Console.WriteLine("Нельзя добавить врача: отделение закрыто.");
            return;
        }

        if (doctor != null && !doctors.Contains(doctor))
            doctors.Add(doctor);
    }

    public void AddRecord(string record)
    {
        if (archive == null)
        {
            Console.WriteLine("Архив отделения больше не существует.");
            return;
        }

        archive.AddRecord(record);
    }

    public void ShowInfo()
    {
        Console.WriteLine($"Отделение «{Name}»");
        if (IsClosed)
        {
            Console.WriteLine("  Отделение закрыто, архив больше не существует.");
            return;
        }

        Console.WriteLine("Врачи:");
        foreach (Doctor doctor in doctors)
            Console.WriteLine($"  {doctor.Name}");

        Console.WriteLine("Архив:");
        if (archive != null)
            archive.ShowRecords();
    }

    public void Close()
    {
        if (IsClosed)
            return;

        IsClosed = true;
        archive = null;
        doctors.Clear();
        Console.WriteLine($"Отделение «{Name}» закрыто. Его архив удалён.");
    }
}


class Hospital
{
    private List<Department> departments = new List<Department>();

    public string Name { get; }

    public Hospital(string name)
    {
        Name = name;
    }

    public Department CreateDepartment(string name)
    {
        Department department = new Department(name);
        departments.Add(department);
        return department;
    }

    public void ShowInfo()
    {
        Console.WriteLine($"Больница «{Name}»");
        foreach (Department department in departments)
            department.ShowInfo();
    }
}

class Program
{
    static void Main()
    {
        Doctor doctor1 = new Doctor("Нуртай Маргулан");
        Doctor doctor2 = new Doctor("Вилена Сергеевна");

        Hospital hospital = new Hospital("Городская больница");
        Department therapy = hospital.CreateDepartment("Терапия");
        Department cardiology = hospital.CreateDepartment("Кардиология");


        therapy.AddDoctor(doctor2);
        cardiology.AddDoctor(doctor1);

        therapy.AddRecord("История болезни пациента №1");
        cardiology.AddRecord("История болезни пациента №2");
        hospital.ShowInfo();

        Console.WriteLine();
        therapy.Close();
        therapy.ShowInfo();
        therapy.AddRecord("Новая запись");

        Console.WriteLine("\nВрачи продолжают работать после закрытия отделения:");
        doctor1.Work();
        doctor2.Work();

        Console.WriteLine("\nДругое отделение продолжает работать:");
        cardiology.ShowInfo();
    }
}
