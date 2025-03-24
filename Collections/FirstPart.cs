using System.Collections;
using System.Diagnostics;
using Car;

class FirstPart
{
    private ArrayList cars; // Коллекция автомобилей

    public FirstPart()
    {
        // Инициализируем коллекцию случайными автомобилями
        cars = GenerateRandomCars(10);
    }

    public void Run()
    {
        while (true)
        {
            Console.WriteLine("\nМеню:");
            Console.WriteLine("1. Показать коллекцию");
            Console.WriteLine("2. Добавить автомобиль");
            Console.WriteLine("3. Удалить автомобиль");
            Console.WriteLine("4. Подсчитать количество грузовиков");
            Console.WriteLine("5. Вывести легковые автомобили");
            Console.WriteLine("6. Найти самый дорогой внедорожник");
            Console.WriteLine("7. Сортировать по цене");
            Console.WriteLine("8. Поиск автомобиля");
            Console.WriteLine("9. Выйти");

            Console.Write("Выберите действие: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    PrintCollection();
                    break;
                case "2":
                    AddCar();
                    break;
                case "3":
                    RemoveCar();
                    break;
                case "4":
                    CountTrucks();
                    break;
                case "5":
                    PrintLightCars();
                    break;
                case "6":
                    FindMostExpensiveBigCar();
                    break;
                case "7":
                    SortCars();
                    break;
                case "8":
                    SearchCar();
                    break;
                case "9":
                    return;
                default:
                    Console.WriteLine("Некорректный ввод. Попробуйте снова.");
                    break;
            }
        }
    }

    // Генерация случайной коллекции автомобилей
    private ArrayList GenerateRandomCars(int count)
    {
        ArrayList cars = new ArrayList();
        Random random = new Random();

        for (int i = 0; i < count; i++)
        {
            Car.Car car;
            switch (random.Next(3))
            {
                case 0:
                    car = new BigCar(); // Внедорожник
                    break;
                case 1:
                    car = new DeliveryCar(); // Грузовик
                    break;
                default:
                    car = new LightCar(); // Легковой автомобиль
                    break;
            }
            car.RandomInit(); // Заполняем случайными значениями
            cars.Add(car);
        }
        return cars;
    }

    // Вывод всей коллекции автомобилей
    private void PrintCollection()
    {
        Console.WriteLine("\nКоллекция автомобилей:");
        foreach (Car.Car car in cars)
        {
            car.Show();
        }
    }

    // Добавление нового автомобиля в коллекцию
    private void AddCar()
    {
        Console.WriteLine("\nДобавление нового автомобиля...");

        // Предлагаем выбор типа автомобиля
        Console.WriteLine("Выберите тип автомобиля:");
        Console.WriteLine("1. Легковой автомобиль");
        Console.WriteLine("2. Грузовик");
        Console.WriteLine("3. Внедорожник");

        string choice = Console.ReadLine();

        Car.Car newCar;

        // Создаем объект соответствующего типа на основе выбора пользователя
        if (choice == "1")
        {
            newCar = new LightCar();
        }
        else if (choice == "2")
        {
            newCar = new DeliveryCar();
        }
        else if (choice == "3")
        {
            newCar = new BigCar();
        }
        else
        {
            Console.WriteLine("Неверный выбор. Попробуйте снова.");
            return;
        }

        // Ввод данных пользователем
        newCar.Init();
        cars.Add(newCar);

        Console.WriteLine("Автомобиль добавлен.");
    }

    // Удаление автомобиля по индексу
    private void RemoveCar()
    {
        if (cars.Count == 0)
        {
            Console.WriteLine("Коллекция пуста.");
            return;
        }

        Console.Write("\nВведите индекс автомобиля для удаления: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index >= 0 && index < cars.Count)
        {
            cars.RemoveAt(index);
            Console.WriteLine("Автомобиль удален.");
        }
        else
        {
            Console.WriteLine("Некорректный индекс.");
        }
    }

    // Подсчет количества грузовых автомобилей
    private void CountTrucks()
    {
        int count = 0;
        foreach (Car.Car car in cars)
        {
            if (car is DeliveryCar)
                count++;
        }
        Console.WriteLine($"\nКоличество грузовых автомобилей: {count}");
    }

    // Вывод всех легковых автомобилей
    private void PrintLightCars()
    {
        Console.WriteLine("\nЛегковые автомобили:");
        foreach (Car.Car car in cars)
        {
            if (car is LightCar)
                car.Show();
        }
    }

    // Поиск самого дорогого внедорожника
    private void FindMostExpensiveBigCar()
    {
        BigCar mostExpensive = null;
        foreach (Car.Car car in cars)
        {
            if (car is BigCar bigCar)
            {
                if (mostExpensive == null || bigCar.Price > mostExpensive.Price)
                {
                    mostExpensive = bigCar;
                }
            }
        }

        if (mostExpensive != null)
        {
            Console.WriteLine("\nСамый дорогой внедорожник:");
            mostExpensive.Show();
        }
        else
        {
            Console.WriteLine("В коллекции нет внедорожников.");
        }
    }

    // Сортировка автомобилей по цене
    private void SortCars()
    {
        cars.Sort(new CarPriceComparer());
        Console.WriteLine("Коллекция отсортирована по цене.");
    }

    // Поиск автомобиля по введенным пользователем данным
    private void SearchCar()
    {
        if (cars.Count == 0)
        {
            Console.WriteLine("Коллекция пуста.");
            return;
        }

        // Выбор типа автомобиля для поиска
        Console.WriteLine("\nВыберите тип автомобиля для поиска:");
        Console.WriteLine("1. Легковой автомобиль");
        Console.WriteLine("2. Внедорожник");
        Console.WriteLine("3. Грузовой");
        Console.Write("Введите номер типа: ");
    
        Car.Car searchCar = null;
        string choice = Console.ReadLine();
    
        switch (choice)
        {
            case "1":
                searchCar = new Car.LightCar();
                break;
            case "2":
                searchCar = new Car.BigCar();
                break;
            case "3":
                searchCar = new Car.DeliveryCar();
                break;
            default:
                Console.WriteLine("Некорректный выбор.");
                return;
        }

        // Ввод характеристик автомобиля
        searchCar.Init();

        Stopwatch stopwatch = Stopwatch.StartNew();
    
        // Поиск автомобиля в коллекции
        bool found = cars.Contains(searchCar);

        stopwatch.Stop();

        Console.WriteLine($"\nЭлемент {(found ? "найден" : "не найден")} за {stopwatch.ElapsedTicks} тиков.");
    }
}
