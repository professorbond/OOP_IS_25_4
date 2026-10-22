// Вариант 6
//task 1
using System;
using System.Collections.Generetiv;
class MedicalArchive
{
    public string ArchiveName {set; get;}
    public MedicalArchive(strng archiveName)
    {
        Name=name;
    }
}
class Department
{
    public string Name {set; get;}
    public MedicalArchive Archive {set; get;}

    public List <Doctor> Doctors {set; get;}

    public Department{string name, string archiveName}
    {
        Name = name;
        Archive = new MedicalArchive(archiveName);
        Doctor = new List<Doctor>();
    }
    public void AddDoctor (Doctor doctor)
    {
        Doctors.Add(doctor);
    }
    
    class Hospital
    {
        public string Name { set; get; }
        public List<Department> Departments { set; get;}

        public Hospital(string name)
        {
            Name = name
            Departments = new List<Department>();
        }
    }
    class Program
    {
        static void Main()
        {
            Hospital hospital = new  Hospital ("Городская больница");
            Department cardiology =
                new Department ("Кардиология", "Архив кардиологии ");
        }
    }
}






//task2
interface IShape
{
    double GetArea();
}
class Rectangle : IShape
{
    public double Weight { set; get; }
    public double Height { set; get; }

    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }

    public double GetArea()
    {
        return Width Height;
    }
}

class Circle : IShape
{
    public double Radius { get; set; }

    public Circle(double radius)
    {
        Radius = radius;
    }

    public double GetArea()
    {
        return Math.PI * Radius * Radius
    }
}
class Area