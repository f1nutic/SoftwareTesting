using System.Xml.Linq;
using Newtonsoft.Json;

namespace PersonalExceptions;

public class Logs : ILogSaver
{
    public void LogToTxt(Exception exception)
    {
        using StreamWriter streamWriter = new StreamWriter("log.txt", true);
        streamWriter.Write($"Time: {DateTime.UtcNow}\n" +
                           $"Exception: {exception.Message}\n" +
                           $"ApplicationName: {exception.Source}\n" +
                           $"TraceLog: {exception.StackTrace}\n" +
                           $"\n");
    }

    public void LogToXML(Exception exception)
    {
        string fileName = "log.xml";
        XDocument doc;
        XElement root;

        if (File.Exists(fileName))
        {
            doc = XDocument.Load(fileName);
            root = doc.Element("Errors");
        }
        else
        {
            root = new XElement("Errors");
            doc = new XDocument(root);
        }

        XElement errorElement = new XElement("Error",
            new XElement("Time", DateTime.UtcNow.ToString()),
            new XElement("Exception", exception.Message),
            new XElement("ApplicationName", exception.Source),
            new XElement("TraceLog", exception.StackTrace)
        );

        root.Add(errorElement);
        doc.Save(fileName);
    }
    
   
    public void LogToJSON(Exception exception)
    {
        string fileName = "log.json";

        var errorInfo = new
        {
            Time = DateTime.UtcNow.ToString(),
            Exception = exception.Message,
            ApplicationName = exception.Source,
            TraceLog = exception.StackTrace
        };

        string json = JsonConvert.SerializeObject(errorInfo, Newtonsoft.Json.Formatting.Indented);

        using var fileStream = new FileStream(fileName, FileMode.Append, FileAccess.Write);
        using var streamWriter = new StreamWriter(fileStream);
        streamWriter.WriteLine(json);
    }
}