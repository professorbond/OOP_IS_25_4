//ЧАСТЬ 1. БИБЛИОТЕКА 

// независимая книига (агрегация)

class Book
{
    public string Title { get; set; }
    public string Author { get; set; }

    public Book(string title, string author)
    {
        Title = title;
        Author = author;
    }

    public override string ToString()
    {
        return Author + " - " + Title;
    }
}

//нехависимый читатеь
class Reader
{
    public string Name { get; set; }

    public Reader(string name)
    {
        Name = name;
    }
}

// Формуляр существует ТОЛЬКО внутри зала (композиция)
class ReaderCard
{
    public Reader Owner { get; private set; }
    public List<Book> TakenBooks { get; private set; }

    public ReaderCard(Reader owner)
    {
        Owner = owner;
        TakenBooks = new List<Book>();
    }
}

// Библиотекарь может работать в нескольких залах
class Librarian
{
    public string Name { get; set; }
    public List<ReadingRoom> Rooms { get; private set; }

    public Librarian(string name)
    {
        Name = name;
        Rooms = new List<ReadingRoom>();
    }
}

class ReadingRoom
{
    public string Name { get; set; }

    // приват тк принадлежат только залу (композиция)
    private List<ReaderCard> cards = new List<ReaderCard>();

    // Книги и библиотекари - просто ссылки (агрегация)
    public List<Book> Books { get; private set; }
    public List<Librarian> Librarians { get; private set; }

    public ReadingRoom(string name)
    {
        Name = name;
        Books = new List<Book>();
        Librarians = new List<Librarian>();
    }

    public void AddBook(Book book)
    {
        if (!Books.Contains(book))
        {
            Books.Add(book);
        }
    }

    public bool RemoveBook(Book book)
    {
        return Books.Remove(book);
    }

    public void AddLibrarian(Librarian librarian)
    {
        if (!Librarians.Contains(librarian))
        {
            Librarians.Add(librarian);
            librarian.Rooms.Add(this);
        }
    }

    // Ищем формуляр читателя в этом зале
    private ReaderCard FindCard(Reader reader)
    {
        foreach (ReaderCard card in cards)
        {
            if (card.Owner == reader)
            {
                return card;
            }
        }
        return null;
    }

    // Читатель записывается в зал - зал сам создаёт формуляр
    public void RegisterReader(Reader reader)
    {
        if (FindCard(reader) == null)
        {
            cards.Add(new ReaderCard(reader));
        }
    }

    public bool GiveBook(Reader reader, Book book)
    {
        ReaderCard card = FindCard(reader);
        if (card == null || !Books.Contains(book))
        {
            return false;
        }
        Books.Remove(book);
        card.TakenBooks.Add(book);
        return true;
    }

    public bool ReturnBook(Reader reader, Book book)
    {
        ReaderCard card = FindCard(reader);
        if (card == null || !card.TakenBooks.Contains(book))
        {
            return false;
        }
        card.TakenBooks.Remove(book);
        Books.Add(book);
        return true;
    }
}

class Library
{
    public string Name { get; set; }
    public List<ReadingRoom> Rooms { get; private set; }

    //хранится в библиотеке отдельно от залов
    public List<Book> AllBooks { get; private set; }
    public List<Librarian> Librarians { get; private set; }
    public List<Reader> Readers { get; private set; }

    public Library(string name)
    {
        Name = name;
        Rooms = new List<ReadingRoom>();
        AllBooks = new List<Book>();
        Librarians = new List<Librarian>();
        Readers = new List<Reader>();
    }

    public void AddRoom(ReadingRoom room)
    {
        Rooms.Add(room);
    }

    public void AddBook(Book book)
    {
        AllBooks.Add(book);
    }

    public void AddLibrarian(Librarian librarian)
    {
        Librarians.Add(librarian);
    }

    public void AddReader(Reader reader)
    {
        Readers.Add(reader);
    }

    // Книги могут перемещаться между залами
    public bool MoveBook(Book book, ReadingRoom from, ReadingRoom to)
    {
        if (from.RemoveBook(book))
        {
            to.AddBook(book);
            return true;
        }
        return false;
    }

    // Закрываем зал = пропал иформуляры
    public void CloseRoom(ReadingRoom room)
    {
        foreach (Librarian l in room.Librarians)
        {
            l.Rooms.Remove(room);
        }
        Rooms.Remove(room);
    }
}

// ЧАСТЬ 2. ЧЕТО С МУЗЫКОЙ

// Общий интерфейс
interface IAudioMaterial
{
    string Title { get; set; }
    int Duration { get; set; }
    void Display();
}

abstract class AudioBase : IAudioMaterial
{
    public string Title { get; set; }
    public int Duration { get; set; }

    public AudioBase(string title, int duration)
    {
        Title = title;
        Duration = duration;
    }

    public void Display()
    {
        Console.WriteLine($"{Title}: {Duration} сек.");
    }
}

class AudioTrack : AudioBase
{
    public AudioTrack(string title, int duration) : base(title, duration)
    {
    }

    // ПЕРЕГРУЗ +
    public static AudioTrack operator +(AudioTrack a, AudioTrack b)
    {
        return new AudioTrack(a.Title + " + " + b.Title, a.Duration + b.Duration);
    }

    // ПЕРЕГРУЗ >
    public static bool operator >(AudioTrack a, AudioTrack b)
    {
        return a.Duration > b.Duration;
    }

    public static bool operator <(Podcast a, Podcast b)
    {
        return a.Duration < b.Duration;
    }
}

class Podcast : AudioBase
{
    public Podcast(string title, int duration) : base(title, duration)
    {
    }

    public static Podcast operator +(Podcast a, Podcast b)
    {
        return new Podcast(a.Title + " + " + b.Title, a.Duration + b.Duration);
    }

    public static bool operator >(Podcast a, Podcast b)
    {
        return a.Duration > b.Duration;
    }
    
    public static bool operator < (Podcast a, Podcast b)
    {
        return a.Duration < b.Duration;
    }
}

// Этот класс работает только с интерфейсом
class AudioPlayer
{
    public static void ShowAll(List<IAudioMaterial> items)
    {
        foreach (IAudioMaterial item in items)
        {
            item.Display();
        }
    }

    public static int TotalDuration(List<IAudioMaterial> items)
    {
        int sum = 0;
        foreach (IAudioMaterial item in items)
        {
            sum += item.Duration;
        }
        return sum;
    }
}

//ТОЧКА ВХОДА

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // ---------- библиотека ----------
        Library library = new Library("Городская библиотека");

        ReadingRoom room1 = new ReadingRoom("Читальный зал №1");
        ReadingRoom room2 = new ReadingRoom("Читальный зал №2");
        library.AddRoom(room1);
        library.AddRoom(room2);

        Book book1 = new Book("Война и мир", "Толстой");
        Book book2 = new Book("Преступление и наказание", "Достоевский");
        library.AddBook(book1);
        library.AddBook(book2);
        room1.AddBook(book1);
        room1.AddBook(book2);

        // один библиотекарь работает в двух залах
        Librarian librarian = new Librarian("Мария Ивановна");
        library.AddLibrarian(librarian);
        room1.AddLibrarian(librarian);
        room2.AddLibrarian(librarian);

        // один читатель пользуется двумя залами
        Reader reader = new Reader("Алина");
        library.AddReader(reader);
        room1.RegisterReader(reader);
        room2.RegisterReader(reader);

        room1.GiveBook(reader, book1);
        library.MoveBook(book2, room1, room2);


        // закрываем зал - книги и библиотекарь остаются
        library.CloseRoom(room2);
        Console.WriteLine();
        Console.WriteLine("После закрытия зала №2:");
        Console.WriteLine("Залов: " + library.Rooms.Count);
        Console.WriteLine("Книг в библиотеке: " + library.AllBooks.Count);
        Console.WriteLine("Библиотекарь работает в залах: " + librarian.Rooms.Count);

        // ---------- аудио ----------
        Console.WriteLine();
        Console.WriteLine("=== Аудио ===");

        AudioTrack t1 = new AudioTrack("Песня 1", 180);
        AudioTrack t2 = new AudioTrack("Песня 2", 200);
        Podcast p1 = new Podcast("Подкаст 1", 1800);
        Podcast p2 = new Podcast("Подкаст 2", 2400);

        AudioTrack sumTrack = t1 + t2;
        sumTrack.Display();

        if (p2 > p1)
        {
            Console.WriteLine("Подкаст 2 длиннее подкаста 1");
        }
        else
        {
            Console.WriteLine("Подкаст 1 длиннее или равен подкасту 2");
        }

        // всё обрабатываем через общий интерфейс
        List<IAudioMaterial> list = new List<IAudioMaterial>();
        list.Add(t1);
        list.Add(t2);
        list.Add(p1);
        list.Add(p2);

        AudioPlayer.ShowAll(list);
        Console.WriteLine("Общая длительность: " + AudioPlayer.TotalDuration(list) + " сек.");

        Console.ReadKey();
    }
}


