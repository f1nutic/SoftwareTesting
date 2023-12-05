using PersonalExceptions;

string path = "";
string[] nums;
List<Exception> exceptions = new List<Exception>();
Logs logSaver = new Logs(); 
int a = 0;
int b = 0;
int c = 0;
Console.WriteLine("Данная программа выводит решение для квадратного уравнения" +
                  "\nКоэффициенты квадратного уравнения задаются в текстовом файле через пробел" +
                  "\nВведите путь до файла" +
                  "\nПример: /home/user/Projects/App/example.txt");
try
{
    Console.Write("> ");
    path = Console.ReadLine();
    if (File.Exists(path))
    {
        using StreamReader reader = new StreamReader(path);
        nums = reader.ReadToEnd().Split(' ');
    }
    else
    {
        throw new FileNotFindException("Файл не найден.");
    }


    int[] kef = new int[3];
    for (int i = 0; i < 3; i++)
    {
        if (int.TryParse(nums[i], out kef[i]))
        {
        }
        else
        {
            throw new NotNumException($"Значение '{nums[i]}' не является числом");
        }
    }

    a = kef[0];
    b = kef[1];
    c = kef[2];
    double discriminant = Math.Pow(b, 2) - 4 * a * c;
    if (discriminant < 0)
    {
        throw new DiscriminantIsNegativeException($"Дискриминант < 0" +
                                                  $"\nКорней квадратного уравнения нет " +
                                                  $"\nЗначение дискриминанта = {discriminant}");
    }
    if (discriminant == 0)
    {
        throw new DiscriminantIsNullException($"Дискриминант = 0" +
                                              $"\nКвадратное уравнение имеет один корень");

    }
    Console.WriteLine($"Дискриминант > 0" +
                      $"\nКвадратное уравнение имеет два корня");
    double x1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
    double x2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
    Console.WriteLine($"Решение квадратного уравнения :" +
                      $"\nКорень 1 = {x1}" +
                      $"\nКорень 2 = {x2}");
}
catch (FileNotFoundException ex)
{
    exceptions.Add(ex);
    Console.WriteLine(ex.Message);
}
catch (NotNumException ex)
{
    exceptions.Add(ex);
    Console.WriteLine(ex.Message);
}
catch (DiscriminantIsNegativeException ex)
{
    exceptions.Add(ex);
    Console.WriteLine(ex.Message);

}
catch (DiscriminantIsNullException ex)
{
    exceptions.Add(ex);
    Console.WriteLine(ex.Message);
    double x = -b / (2 * a);
    Console.WriteLine($"Решение квадратного уравнения:" +
                      $"\nКорень 1 = {x}");
}
catch (Exception ex)
{
    exceptions.Add(ex);
    Console.WriteLine(ex.Message);
}
finally
{
    Console.WriteLine($"\nКоличество возникший исключений - {exceptions.Count}");
    if (exceptions.Count > 0)
    {
        Console.WriteLine("Список исключений");
        foreach (var exception in exceptions)
        {
            Console.WriteLine(" - " + exception.GetType());
            logSaver.LogToTxt(exception);
            logSaver.LogToXML(exception);
            logSaver.LogToJSON(exception);
        }
    }
    Console.WriteLine("\nКонец работы программы.");
}