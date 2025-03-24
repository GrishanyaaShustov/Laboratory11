using Car;

class SecondPart
{
    // Стек для хранения автомобилей
    private Stack<Car.Car> carStack;

    // Конструктор класса: инициализирует стек и заполняет его случайными автомобилями
    public SecondPart()
    {
        carStack = new Stack<Car.Car>();
        GenerateRandomCars(10); // Генерация 10 случайных автомобилей
    }

    // Основной метод для работы с меню
    public void Run()
    {
        while (true)
        {
            // Вывод меню пользователю
            Console.WriteLine("\nМеню:");
            Console.WriteLine("1. Показать коллекцию");
            Console.WriteLine("2. Добавить автомобиль");
            Console.WriteLine("3. Удалить автомобиль");
            Console.WriteLine("4. Количество грузовиков");
            Console.WriteLine("5. Печать легковых автомобилей");
            Console.WriteLine("6. Найти самый дорогой внедорожник");
            Console.WriteLine("7. Сортировка по цене");
            Console.WriteLine("8. Поиск автомобиля");
            Console.WriteLine("9. Клонировать коллекцию");
            Console.WriteLine("10. Выйти");

            Console.Write("Выберите действие: ");
            string choice = Console.ReadLine();

            // Обработка выбора пользователя
            switch (choice)
            {
                case "1":
                    PrintCollection(); // Показать все автомобили в коллекции
                    break;
                case "2":
                    AddCar(); // Добавить новый автомобиль
                    break;
                case "3":
                    RemoveCar(); // Удалить автомобиль из коллекции
                    break;
                case "4":
                    CountTrucks(); // Подсчитать количество грузовиков
                    break;
                case "5":
                    PrintLightCars(); // Показать только легковые автомобили
                    break;
                case "6":
                    FindMostExpensiveBigCar(); // Найти самый дорогой внедорожник
                    break;
                case "7":
                    SortCars(); // Отсортировать автомобили по цене
                    break;
                case "8":
                    SearchCar(); // Поиск автомобиля в коллекции
                    break;
                case "9":
                    CloneCollection(); // Клонировать коллекцию автомобилей
                    break;
                case "10":
                    return; // Завершить программу
                default:
                    Console.WriteLine("Некорректный ввод. Попробуйте снова.");
                    break;
            }
        }
    }

    // Метод для генерации случайных автомобилей
    private void GenerateRandomCars(int count)
    {
        Random random = new Random();
        for (int i = 0; i < count; i++)
        {
            Car.Car car;
            // Случайный выбор типа автомобиля
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
            car.RandomInit(); // Инициализация случайными данными
            carStack.Push(car); // Добавление автомобиля в стек
        }
    }

    // Метод для вывода всех автомобилей в коллекции
    private void PrintCollection()
    {
        Console.WriteLine("\nКоллекция автомобилей:");
        foreach (var car in carStack)
        {
            car.Show(); // Вывод информации об автомобиле
        }
    }

    // Метод для добавления нового автомобиля
    private void AddCar()
    {
        Console.WriteLine("\nДобавление нового автомобиля...");
        Console.WriteLine("Выберите тип автомобиля:");
        Console.WriteLine("1. Легковой автомобиль");
        Console.WriteLine("2. Грузовик");
        Console.WriteLine("3. Внедорожник");

        string choice = Console.ReadLine();
        Car.Car newCar;

        // Создание автомобиля выбранного типа
        if (choice == "1")
            newCar = new LightCar();
        else if (choice == "2")
            newCar = new DeliveryCar();
        else if (choice == "3")
            newCar = new BigCar();
        else
        {
            Console.WriteLine("Неверный выбор. Попробуйте снова.");
            return;
        }

        newCar.Init(); // Инициализация данных автомобиля через пользовательский ввод
        carStack.Push(newCar); // Добавление автомобиля в стек
        Console.WriteLine("Автомобиль добавлен.");
    }

    // Метод для удаления автомобиля из коллекции
    private void RemoveCar()
    {
        if (carStack.Count == 0)
        {
            Console.WriteLine("Коллекция пуста.");
            return;
        }

        Car.Car removedCar = carStack.Pop(); // Удаление последнего добавленного автомобиля
        Console.WriteLine("\nУдален автомобиль:");
        removedCar.Show(); // Вывод информации об удаленном автомобиле
    }

    // Метод для подсчета количества грузовиков
    private void CountTrucks()
    {
        int count = 0;
        foreach (var car in carStack)
        {
            if (car is DeliveryCar) // Проверка, является ли автомобиль грузовиком
                count++;
        }
        Console.WriteLine($"\nКоличество грузовых автомобилей: {count}");
    }

    // Метод для вывода легковых автомобилей
    private void PrintLightCars()
    {
        Console.WriteLine("\nЛегковые автомобили:");
        foreach (var car in carStack)
        {
            if (car is LightCar) // Проверка, является ли автомобиль легковым
                car.Show(); // Вывод информации о легковом автомобиле
        }
    }

    // Метод для поиска самого дорогого внедорожника
    private void FindMostExpensiveBigCar()
    {
        BigCar mostExpensive = null;
        foreach (var car in carStack)
        {
            if (car is BigCar bigCar) // Проверка, является ли автомобиль внедорожником
            {
                if (mostExpensive == null || bigCar.Price > mostExpensive.Price)
                    mostExpensive = bigCar; // Обновление самого дорогого внедорожника
            }
        }

        if (mostExpensive != null)
        {
            Console.WriteLine("\nСамый дорогой внедорожник:");
            mostExpensive.Show(); // Вывод информации о самом дорогом внедорожнике
        }
        else
        {
            Console.WriteLine("В коллекции нет внедорожников.");
        }
    }

    // Метод для сортировки автомобилей по цене
    private void SortCars()
    {
        Stack<Car.Car> tempStack = new Stack<Car.Car>();
        while (carStack.Count > 0)
        {
            Car.Car temp = carStack.Pop();

            // Сортировка с использованием временного стека
            while (tempStack.Count > 0 && new CarPriceComparer().Compare(tempStack.Peek(), temp) > 0)
            {
                carStack.Push(tempStack.Pop());
            }

            tempStack.Push(temp);
        }

        // Перенос отсортированных элементов обратно в основной стек
        carStack = tempStack;
        Console.WriteLine("Коллекция отсортирована по цене.");
    }

    // Метод для поиска автомобиля в коллекции
    private void SearchCar()
    {
        if (carStack.Count == 0)
        {
            Console.WriteLine("Коллекция пуста.");
            return;
        }

        Console.WriteLine("\nВыберите тип автомобиля для поиска:");
        Console.WriteLine("1. Легковой автомобиль");
        Console.WriteLine("2. Внедорожник");
        Console.WriteLine("3. Грузовой");
        Console.Write("Введите номер типа: ");

        Car.Car searchCar = null;
        string choice = Console.ReadLine();

        // Создание автомобиля выбранного типа
        switch (choice)
        {
            case "1":
                searchCar = new LightCar();
                break;
            case "2":
                searchCar = new BigCar();
                break;
            case "3":
                searchCar = new DeliveryCar();
                break;
            default:
                Console.WriteLine("Некорректный выбор.");
                return;
        }

        searchCar.Init(); // Инициализация данных автомобиля через пользовательский ввод

        bool found = false;
        foreach (var car in carStack)
        {
            if (car.Equals(searchCar)) // Проверка на равенство автомобилей
            {
                found = true;
                break;
            }
        }

        Console.WriteLine($"\nЭлемент {(found ? "найден" : "не найден")}.");
    }

    // Метод для клонирования коллекции автомобилей
    private void CloneCollection()
    {
        Stack<Car.Car> clonedStack = new Stack<Car.Car>();

        foreach (var car in carStack)
        {
            // Используем метод Clone для создания глубокой копии каждого автомобиля
            clonedStack.Push((Car.Car)car.Clone());
        }

        Console.WriteLine("\nКлонированная коллекция:");
        foreach (var car in clonedStack)
        {
            car.Show(); // Вывод информации о клонированных автомобилях
        }
    }
}