using System;

class Program
{
    static void Main()
    {
        // Матриця суміжності для вершин A, B, C, D, E
        int[,] matrix = {
            { 0, 1, 0, 0, 0 }, // A
            { 1, 0, 1, 1, 0 }, // B
            { 0, 0, 0, 0, 1 }, // C
            { 1, 1, 0, 0, 0 }, // D
            { 0, 0, 0, 1, 0 }  // E
        };

        char[] vertices = { 'A', 'B', 'C', 'D', 'E' };

        bool exit = false;
        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("        РОБОТА З ГРАФОМ (МЕНЮ)          ");
            Console.WriteLine("========================================");
            Console.WriteLine("1. Вивести матрицю суміжності на екран");
            Console.WriteLine("2. Знайти суміжні вершини до вершини C (за завданням)");
            Console.WriteLine("3. Вибрати іншу вершину для перевірки");
            Console.WriteLine("0. Вихід з програми");
            Console.WriteLine("========================================");
            Console.Write("Оберіть пункт меню: ");

            string choice = Console.ReadLine() ?? "";
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    PrintMatrix(matrix, vertices);
                    break;

                case "2":
                    FindAdjacent(matrix, vertices, 2);
                    break;

                case "3":
                    Console.Write("Введіть назву вершини (A, B, C, D, E): ");
                    string input = (Console.ReadLine() ?? "").Trim().ToUpper();

                    if (input.Length > 0)
                    {
                        int index = Array.IndexOf(vertices, input[0]);
                        if (index != -1)
                        {
                            FindAdjacent(matrix, vertices, index);
                        }
                        else
                        {
                            Console.WriteLine("Помилка: такої вершини немає у графі!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Помилка: ви нічого не ввели.");
                    }
                    break;

                case "0":
                    exit = true;
                    Console.WriteLine("Вихід з програми...");
                    break;

                default:
                    Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                    break;
            }

            if (!exit)
            {
                Console.WriteLine("\nНатисніть будь-яку клавішу, щоб продовжити...");
                Console.ReadKey();
            }
        }
    }

    // Метод для виведення матриці суміжності
    static void PrintMatrix(int[,] matrix, char[] vertices)
    {
        Console.WriteLine("Матриця суміжності графа:");
        Console.WriteLine();
        Console.Write("    ");

        for (int i = 0; i < vertices.Length; i++)
        {
            Console.Write(vertices[i] + " ");
        }

        Console.WriteLine();
        Console.WriteLine("  ------------------");

        for (int i = 0; i < vertices.Length; i++)
        {
            Console.Write(vertices[i] + " | ");
            for (int j = 0; j < vertices.Length; j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    // Метод для пошуку суміжних вершин
    static void FindAdjacent(int[,] matrix, char[] vertices, int targetIndex)
    {
        Console.WriteLine("Вершини, суміжні з вершиною " + vertices[targetIndex] + ":");

        int count = 0;
        for (int j = 0; j < vertices.Length; j++)
        {
            if (matrix[targetIndex, j] == 1)
            {
                Console.WriteLine("- " + vertices[j]);
                count++;
            }
        }

        if (count == 0)
        {
            Console.WriteLine("Немає суміжних вершин.");
        }
    }
}