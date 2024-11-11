using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Listede sayıların tanımlanması
        List<int> list = new List<int> { -1, 2, -3, 8, 17, 56, 77, 86, 95, 100 };

        // Çift sayılar
        IEnumerable<int> evenValues = list.Where(x => x % 2 == 0);
        Console.WriteLine("Cift sayilar:");
        foreach (int value in evenValues)
        {
            Console.WriteLine(value);
        }
        Console.WriteLine("----------------------------");

        // Tek sayılar
        IEnumerable<int> oddValues = list.Where(x => x % 2 != 0);
        Console.WriteLine("Tek sayilar:");
        foreach (int value in oddValues)
        {
            Console.WriteLine(value);
        }
        Console.WriteLine("----------------------------");

        // Negatif sayılar
        IEnumerable<int> negativeValues = list.Where(x => x < 0);
        Console.WriteLine("Negatif sayilar:");
        foreach (int value in negativeValues)
        {
            Console.WriteLine(value);
        }
        Console.WriteLine("----------------------------");

        // Pozitif sayılar
        IEnumerable<int> positiveValues = list.Where(x => x > 0);
        Console.WriteLine("Pozitif sayilar:");
        foreach (int value in positiveValues)
        {
            Console.WriteLine(value);
        }
        Console.WriteLine("----------------------------");

        // 15'ten büyük ve 22'den küçük sayılar
        IEnumerable<int> values = list.Where(x => x > 15 && x < 22);
        Console.WriteLine("15'ten büyük ve 22'den küçük sayılar:");
        foreach (int value in values)
        {
            Console.WriteLine(value);
        }
        Console.WriteLine("----------------------------");

        // Listedeki her bir sayının karesi
        IEnumerable<int> squareValues = list.Select(x => x * x);
        Console.WriteLine("Listedeki her bir sayının karesi:");
        foreach (int value in squareValues)
        {
            Console.WriteLine(value);
        }
        Console.WriteLine("----------------------------");

        Console.ReadKey();
    }
}
