//Вариант 17
using System;
using System.Collections.Generic;

// task 1
class MedicalRecord
{
    public int RecordCount { get; set; }

    public MedicalRecord(int recordCount = 0)
    {
        RecordCount = recordCount;
    }

    public void AddRecord()
    {
        RecordCount++;
        Console.WriteLine($"Мед запись добавлена. Всего мед записей: {RecordCount}");
    }
}

class Equipment
{
    public string Name { get; set; }
    public string SerialNumber { get; set; }
    public Cabinet CurrentCabinet { get; set; }

    public Equipment(string name, string serialNumber)
    {
        Name = name;
        SerialNumber = serialNumber;
    }

    public void ToMove(Cabinet newCabinet)
    {
        CurrentCabinet = newCabinet;
        Console.WriteLine($"Оборудование {Name} перемещено в новый кабинет");
    }
}

class Cabinet
{
    public int Number { get; set; }

    private MedicalRecord _medicalRecord;
    private List<Doctor> _doctors = new List<Doctor>();
    private List<Equipment> _equipments = new List<Equipment>();

    public Cabinet(int number)
    {
        Number = number;
        _medicalRecord = new MedicalRecord();
    }

    public void AddEquipment(Equipment equipment)
    {
        _equipments.Add(equipment);
        equipment.CurrentCabinet = this;
    }

    public MedicalRecord GetMedicalRecord()
    {
        return _medicalRecord;
    }
}

class Doctor
{
    public string Name { get; set; }
    public string Specialization { get; set; }

    private List<Cabinet> _cabinets = new List<Cabinet>();

    public Doctor(string name, string specialization)
    {
        Name = name;
        Specialization = specialization;
    }

    public void AddCabinet(Cabinet cabinet)
    {
        _cabinets.Add(cabinet);
        Console.WriteLine($"Доктору добавлен кабинет {cabinet.Number}");
    }

    public void ConsultPatient(Patient patient)
    {
        Console.WriteLine($"Доктор {Name} ведет прием пациента {patient.Name}");
    }
}

class Patient
{
    public string Name { get; set; }
    public string Address { get; set; }

    public Patient(string name, string address)
    {
        Name = name;
        Address = address;
    }
}

class Polyclinic
{
    public string Name { get; set; }
    private List<Cabinet> _polyclinicCabinets = new List<Cabinet>();
    private List<Doctor> _polyclinicDoctors = new List<Doctor>();
    private List<Patient> _polyclinicPatients = new List<Patient>();

    public Polyclinic(string name)
    {
        Name = name;
    }
}

//task2
interface IDisplayable
{
    void Display();
}

class PdfDocument : IDisplayable
{
    public string Name { get; set; }
    public long Size { get; set; }

    public PdfDocument(string name, long size)
    {
        Name = name;
        Size = size;
    }


    public void Display()
    {
        Console.WriteLine($"{Name}: {Size} байт");
    }

    // Перегрузка операторов с PdfDocument
    public static bool operator >(PdfDocument documentA, PdfDocument documentB)
    {
        return documentA.Size > documentB.Size;
    }

    public static bool operator <(PdfDocument documentA, PdfDocument documentB)
    {
        return documentA.Size < documentB.Size;
    }

    public static long operator +(PdfDocument documentA, PdfDocument documentB)
    {
        return documentA.Size + documentB.Size;
    }

    // Перегрузка операторов с WordDocument для работы кода в Main
    public static bool operator >(PdfDocument documentA, WordDocument documentB)
    {
        return documentA.Size > documentB.Size;
    }

    public static bool operator <(PdfDocument documentA, WordDocument documentB)
    {
        return documentA.Size < documentB.Size;
    }

    public static long operator +(PdfDocument documentA, WordDocument documentB)
    {
        return documentA.Size + documentB.Size;
    }
}

class WordDocument : IDisplayable
{
    public string Name { get; set; }
    public long Size { get; set; }

    public WordDocument(string name, long size)
    {
        Name = name;
        Size = size;
    }


    public void Display()
    {
        Console.WriteLine($"{Name}: {Size} байт");
    }
}

class DocumentProcessor
{
    public void Process(IDisplayable displayable)
    {
        displayable.Display();
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("ТЕСТ");

        //ПОЛИКЛИНИКА
        Console.WriteLine("Поликлиника");

        Polyclinic clinic = new Polyclinic("Центральная поликлиника");

        Cabinet cabinet101 = new Cabinet(101);
        Doctor doctor = new Doctor("Смирнов А.В.", "Хирург");
        doctor.AddCabinet(cabinet101);

        Patient patient = new Patient("Иванов И.И.", "ул. Ленина, 15");
        doctor.ConsultPatient(patient);

        Console.WriteLine("Проверка медицинских записей (Композиция):");
        cabinet101.GetMedicalRecord().AddRecord();
        cabinet101.GetMedicalRecord().AddRecord();

        Console.WriteLine("Проверка оборудования:");
        Equipment ultrasound = new Equipment("УЗИ-аппарат", "SN-9988");
        cabinet101.AddEquipment(ultrasound);
        ultrasound.ToMove(null);

        //ДОКУМЕНТЫ
        Console.WriteLine("Документы");

        PdfDocument pdfDoc = new PdfDocument("ИсторияБолезни.pdf", 2500);
        WordDocument wordDoc = new WordDocument("Направление.docx", 1200);

        DocumentProcessor processor = new DocumentProcessor();

        Console.WriteLine("Обработка PDF документа:");
        processor.Process(pdfDoc);

        Console.WriteLine("Обработка Word документа:");
        processor.Process(wordDoc);

        long totalSize = pdfDoc + wordDoc;
        Console.WriteLine($"[Тест оператора +] Суммарный размер документов: {totalSize} байт (Ожидается: 3700)");

        if (pdfDoc > wordDoc)
        {
            Console.WriteLine($"[Тест оператора >] Успех: документ '{pdfDoc.Name}' больше, чем '{wordDoc.Name}'.");
        }
    }
}