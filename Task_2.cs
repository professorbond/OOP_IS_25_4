using System;

//TASK_2
// class TextFile
// {
//     public string Content { get; set; }

//     public TextFile (string content)
//     {
//         Content = content;
//     }

//     public void Show()
//     {
//         Console.WriteLine(Content);
//     }
// }

// class TextMessage
// {
//     public string Content { get; set; }

//     public TextMessage (string content)
//     {
//         Content = content;
//     }

//     public void Show()
//     {
//         Console.WriteLine(Content);
//     }
// }

public interface ATextDoc
{
    string Content { get; set; }
}

public class TextFile : ATextDoc
{
    public string Content { get; set; }

}
public class TextMessage : ATextDoc
{
    public string Content { get; set; }

}
//TASK_1

public class FloorService
{
    public string ServiceName { get; set; }
    public FloorService(string serviceName)
        {
            ServiceName = serviceName;
        }
};

public class Floor
{
    public int Number { get; set; }
    private FloorService serviceSystem;
    public Floor(int number, string serviceName)
        {
            Number = number;
            serviceSystem = new FloorService(serviceName);
        }
};
