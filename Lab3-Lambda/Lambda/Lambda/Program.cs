using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Данная программа выводит таблицу, " +
                          "где строки и столбцы озаглавлены цифрами, " +
                          "а в ячейках таблицы находится их сумма или произведение.");

        int size;

        Func<int, int, char, int> Pull = (x, y, operation) =>
        {
            if (operation == '+')
                return x + y;
            if (operation == '*')
                return x * y;
            throw new ArgumentException("Неподдерживаемая операция");
        };

        do
        {
            Console.Write("Введите размерность таблицы (значение должно быть > 1): ");
            size = int.Parse(Console.ReadLine());
        } while (size < 1);

        Console.Write("Введите операцию (+, *): ");
        char operation = char.Parse(Console.ReadLine());

        double[,] table = new double[size, size];

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                table[i, j] = Pull(i + 1, j + 1, operation);
            }
        }

        PrintTable();

        void PrintTable()
        {
            Console.WriteLine("Результат:");

            Console.Write("\t\t");
            for (int i = 1; i <= size; i++)
            {
                Console.Write($"{i}\t\t");
            }
            Console.WriteLine("");


            for (int i = 0; i < size; i++)
            {
                Console.Write($"   {i + 1}\t|\t");
                for (int j = 0; j < size; j++)
                {
                    Console.Write($"{table[i, j]}\t|\t");
                }
                Console.WriteLine();
            }
        }
    }
}