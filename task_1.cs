//Вариант 10
using System;

class University
{
    public string Name { get; set; }
    private List<Department> _departments;

    public University(string name)
    {
        Name = name;
    }

    public Department CreateDepartment(string nameDertment)
    {
        Department department = new Department(nameDertment);
        _departments.Add(department);
        return department;

    }
}

class Department
{
    public string Name { get; set; }
    private List<Teacher> _teachers;

    public Department(string name)
    {
        Name = name;
    }

    public AddTeacher(Teacher teacher)
    {
        _teachers.Add(teacher);
    }

}

class Teacher
{
    public string Name { get; set; }
    private List<Student> _stundents;

    public Teacher(string name)
    {
        Name = name;
    }
    
    public AddStudent(Student student)
    {
        {
            _students.Add(teacher);
        }
    }
}

class Student
{
    public string Name { get; set; }
    private Teacher currTeacher;

    public Studnet(string name)
    {
        Name = name;
    }

    public void ChangeTeacher(Teacher teacher)
    {
        currTeacher = teacher;
    }
}

