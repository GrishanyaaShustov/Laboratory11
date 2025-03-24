using System;
using Car;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\nМеню:");
            Console.WriteLine("1. Запуск первой части");
            Console.WriteLine("2. Запуск второй части");
            Console.WriteLine("3. Запуск третьей части");
            Console.WriteLine("4. Выйти");

            Console.Write("Выберите действие: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    FirstPart firstPart = new FirstPart();
                    firstPart.Run();  // Запуск первой части программы
                    break;
                case "2":
                    SecondPart secondPart = new SecondPart();
                    secondPart.Run();  // Запуск второй части программы
                    break;
                case "3":
                    TestCollections test = new TestCollections(1000); // Создаем коллекции с 1000 элементами
                    test.MeasureSearchTime(); // Измеряем время поиска
                    break;
                case "4":
                    return;  // Завершение программы
                default:
                    Console.WriteLine("Некорректный ввод. Попробуйте снова.");
                    break;
            }
        }
    }
}