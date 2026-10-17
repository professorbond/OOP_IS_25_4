using System;
using System.Collections.Generic;

class Teacher
{
    public string Name { get; set; }
    public Teacher(string name) => Name = name;
}

class Faculty
{
    public string Name { get; set; }
    public List<Teacher> Teachers { get; set; } = new List<Teacher>();

    public Faculty(string name, List<Teacher> teachers)
    {
        Name = name;
        Teachers = teachers;
    };
}

class University
{
    public string Name { get; set; }
    public List<Faculty> Faculties { get; set; } = new List<Faculty>();
    public University(string name)
    {
        Faculty faculty = new Faculty(); // композиция
    };


    public void Close()
    {
        Faculties.Clear();
        Console.WriteLine("Университет '{Name}' закрыт.факультеты удалены.");
    }
}

