using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Car
{
    public class TestCollections
    {
        private LinkedList<LightCar> col1; // Коллекция 1: LinkedList<LightCar>
        private LinkedList<string> col2;  // Коллекция 2: LinkedList<string>
        private Dictionary<Car, LightCar> col3; // Коллекция 3: Dictionary<Car, LightCar>
        private Dictionary<string, LightCar> col4; // Коллекция 4: Dictionary<string, LightCar>

        public TestCollections(int count)
        {
            col1 = new LinkedList<LightCar>();
            col2 = new LinkedList<string>();
            col3 = new Dictionary<Car, LightCar>();
            col4 = new Dictionary<string, LightCar>();

            Random random = new Random();

            for (int i = 0; i < count; i++)
            {
                // Создаем новый объект LightCar и вызываем RandomInit
                LightCar car = new LightCar();
                car.RandomInit();

                // Добавляем элементы в коллекции
                col1.AddLast(car);
                col2.AddLast(car.ToString());
                col3[car.GetBase] = car; // Используем метод GetBase для ключа
                col4[car.ToString()] = car;
            }
        }

        public void MeasureSearchTime()
        {
            Stopwatch stopwatch = new Stopwatch();

            // Выбираем элементы для поиска
            LightCar firstCar = col1.First.Value;
            LightCar middleCar = col1.Count > 1 ? col1.ElementAt(col1.Count / 2) : null;
            LightCar lastCar = col1.Last.Value;

            // Создаем несуществующий объект
            LightCar nonExistingCar = new LightCar();
            nonExistingCar.RandomInit();
            nonExistingCar.Brand = "NonExistingBrand"; // Уникализируем объект

            string firstString = col2.First.Value;
            string middleString = col2.Count > 1 ? col2.ElementAt(col2.Count / 2) : null;
            string lastString = col2.Last.Value;
            string nonExistingString = nonExistingCar.ToString();

            Console.WriteLine("\n=== Измерение времени поиска ===\n");

            // Измеряем время поиска для LinkedList<LightCar>
            Console.WriteLine("1. Коллекция: LinkedList<LightCar>");
            MeasureTimeForCollection(col1, firstCar, middleCar, lastCar, nonExistingCar);

            // Измеряем время поиска для LinkedList<string>
            Console.WriteLine("\n2. Коллекция: LinkedList<string>");
            MeasureTimeForCollection(col2, firstString, middleString, lastString, nonExistingString);

            // Измеряем время поиска для Dictionary<Car, LightCar>
            Console.WriteLine("\n3. Коллекция: Dictionary<Car, LightCar>");
            MeasureTimeForDictionary(col3, firstCar.GetBase, middleCar?.GetBase, lastCar.GetBase, nonExistingCar.GetBase);

            // Измеряем время поиска для Dictionary<string, LightCar>
            Console.WriteLine("\n4. Коллекция: Dictionary<string, LightCar>");
            MeasureTimeForDictionary(col4, firstString, middleString, lastString, nonExistingString);
        }

        private void MeasureTimeForCollection<T>(ICollection<T> collection, T first, T middle, T last, T nonExisting)
        {
            Stopwatch stopwatch = new Stopwatch();
            long[] times = new long[4];

            Console.WriteLine("Поиск элементов:");

            // Поиск первого элемента
            stopwatch.Restart();
            for (int i = 0; i < 100; i++) collection.Contains(first);
            stopwatch.Stop();
            times[0] = stopwatch.ElapsedTicks;
            Console.WriteLine($"Первый элемент: {times[0]} тиков");

            // Поиск центрального элемента
            if (middle != null)
            {
                stopwatch.Restart();
                for (int i = 0; i < 100; i++) collection.Contains(middle);
                stopwatch.Stop();
                times[1] = stopwatch.ElapsedTicks;
                Console.WriteLine($"Центральный элемент: {times[1]} тиков");
            }

            // Поиск последнего элемента
            stopwatch.Restart();
            for (int i = 0; i < 100; i++) collection.Contains(last);
            stopwatch.Stop();
            times[2] = stopwatch.ElapsedTicks;
            Console.WriteLine($"Последний элемент: {times[2]} тиков");

            // Поиск несуществующего элемента
            stopwatch.Restart();
            for (int i = 0; i < 100; i++) collection.Contains(nonExisting);
            stopwatch.Stop();
            times[3] = stopwatch.ElapsedTicks;
            Console.WriteLine($"Несуществующий элемент: {times[3]} тиков");
        }

        private void MeasureTimeForDictionary<TKey, TValue>(IDictionary<TKey, TValue> dictionary, TKey firstKey, TKey middleKey, TKey lastKey, TKey nonExistingKey)
        {
            Stopwatch stopwatch = new Stopwatch();
            long[] times = new long[4];

            Console.WriteLine("Поиск элементов:");

            // Поиск по ключу (первый)
            stopwatch.Restart();
            for (int i = 0; i < 100; i++) dictionary.ContainsKey(firstKey);
            stopwatch.Stop();
            times[0] = stopwatch.ElapsedTicks / 100;
            Console.WriteLine($"Первый элемент: {times[0]} тиков");

            // Поиск по ключу (центральный)
            if (middleKey != null)
            {
                stopwatch.Restart();
                for (int i = 0; i < 100; i++) dictionary.ContainsKey(middleKey);
                stopwatch.Stop();
                times[1] = stopwatch.ElapsedTicks / 100;
                Console.WriteLine($"Центральный элемент: {times[1]} тиков");
            }

            // Поиск по ключу (последний)
            stopwatch.Restart();
            for (int i = 0; i < 100; i++) dictionary.ContainsKey(lastKey);
            stopwatch.Stop();
            times[2] = stopwatch.ElapsedTicks / 100;
            Console.WriteLine($"Последний элемент: {times[2]} тиков");

            // Поиск по ключу (несуществующий)
            stopwatch.Restart();
            for (int i = 0; i < 100; i++) dictionary.ContainsKey(nonExistingKey);
            stopwatch.Stop();
            times[3] = stopwatch.ElapsedTicks / 100;
            Console.WriteLine($"Несуществующий элемент: {times[3]} тиков");
        }
    }
}