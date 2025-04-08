using System;

public static class InputValidator
{
    public static double GetValidDouble(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            if (double.TryParse(Console.ReadLine(), out double result))
            {
                return result;
            }
            Console.WriteLine("Ошибка ввода! Введите число");
        }
    }

    public static bool AskToContinue()
    {
        Console.Write("Продолжить? (да/нет): ");
        while (true)
        {
            var input = Console.ReadLine().ToLower();
            if (input == "да") return true;
            if (input == "нет") return false;
            Console.Write("Некорректный ввод. Введите 'да' или 'нет': ");
        }
    }
}
