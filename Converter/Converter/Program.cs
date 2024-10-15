using System;

class Converter
{
    public decimal UsdRate { get; set; }
    public decimal EurRate { get; set; }

    public Converter(decimal usdRate, decimal eurRate)
    {
        UsdRate = usdRate;
        EurRate = eurRate;
    }

    public void PointsOfMenu()
    {
        Console.WriteLine("Оберіть дію:");
        Console.WriteLine("1 - Конвертувати гривні в долари");
        Console.WriteLine("2 - Конвертувати гривні в євро");
        Console.WriteLine("3 - Конвертувати долари в гривні");
        Console.WriteLine("4 - Конвертувати євро в гривні");
        Console.WriteLine("5 - Вийти з конвертора");
    }

    public decimal ConvertUahToUsd(decimal uahAmount)
    {
        return uahAmount / UsdRate;
    }

    public decimal ConvertUahToEur(decimal uahAmount)
    {
        return uahAmount / EurRate;
    }

    public decimal ConvertUsdToUah(decimal usdAmount)
    {
        return usdAmount * UsdRate;
    }

    public decimal ConvertEurToUah(decimal eurAmount)
    {
        return eurAmount * EurRate;
    }

    public decimal GetValidDecimalInput(string prompt)
    {
        decimal value;
        Console.WriteLine(prompt);
        while (!decimal.TryParse(Console.ReadLine(), out value) || value <= 0)
        {
            Console.WriteLine("Помилка! Введіть коректне додатне число.");
        }
        return value;
    }

    public int GetValidIntInput(string prompt)
    {
        int value;
        Console.WriteLine(prompt);
        string input = Console.ReadLine();  // Читаємо введене значення один раз
        while (!int.TryParse(input, out value) || value > 5 || value < 1)
        {
            if (!int.TryParse(input, out value))
            {
                Console.WriteLine("Помилка! Введіть коректне число.");
            }
            else if (value < 1 || value > 5)
            {
                Console.WriteLine("Помилка! Цього пункту немає в меню.");
            }

            input = Console.ReadLine();  // Читаємо нове значення
        }
        return value;
    }

    public void RunMenu()
    {
        int choice;
        do
        {
            PointsOfMenu();
            choice = GetValidIntInput("");

            switch (choice)
            {
                case 1:
                    decimal uahToUsdAmount = GetValidDecimalInput("Введіть суму в гривнях:");
                    Console.WriteLine($"Сума в доларах: {ConvertUahToUsd(uahToUsdAmount)}");
                    break;
                case 2:
                    decimal uahToEurAmount = GetValidDecimalInput("Введіть суму в гривнях:");
                    Console.WriteLine($"Сума в євро: {ConvertUahToEur(uahToEurAmount)}");
                    break;
                case 3:
                    decimal usdToUahAmount = GetValidDecimalInput("Введіть суму в доларах:");
                    Console.WriteLine($"Сума в гривнях: {ConvertUsdToUah(usdToUahAmount)}");
                    break;
                case 4:
                    decimal eurToUahAmount = GetValidDecimalInput("Введіть суму в євро:");
                    Console.WriteLine($"Сума в гривнях: {ConvertEurToUah(eurToUahAmount)}");
                    break;
                case 5:
                    Console.WriteLine("Дякую, що скористалися конвертором. До побачення");
                    break;
            }

        } while (choice >= 1 && choice <= 4);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        decimal usdRate = new Converter(1, 1).GetValidDecimalInput("Введіть курс долара до гривні:");
        decimal eurRate = new Converter(1, 1).GetValidDecimalInput("Введіть курс євро до гривні:");

        Converter converter = new Converter(usdRate, eurRate);

        // Запускаємо меню конвертера
        converter.RunMenu();
    }
}
