using System;

class Program
{
    static void Main()
    {
        do
        {
            Console.Clear();
            TestConstructors();
            TestEquationSolution();
        } while (InputValidator.AskToContinue());
    }

    static void TestConstructors()
    {
        try
        {
            Console.WriteLine("Тест конструктора по умолчанию:");
            var eq1 = new QuadraticEquation();
            Console.WriteLine(eq1);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }

        try
        {
            Console.WriteLine("\nТест валидного конструктора:");
            var eq2 = new QuadraticEquation(1, -5, 6);
            Console.WriteLine(eq2);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }

        try
        {
            Console.WriteLine("\nТест невалидного конструктора (a=0):");
            var eq3 = new QuadraticEquation(0, 2, 3);
            Console.WriteLine(eq3);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }

    static void TestEquationSolution()
    {
        try
        {
            var equation = new QuadraticEquation(
                InputValidator.GetValidDouble("Введите a: "),
                InputValidator.GetValidDouble("Введите b: "),
                InputValidator.GetValidDouble("Введите c: "));

            Console.WriteLine($"\nСоздано уравнение: {equation}");

            var roots = equation.Solve();
            Console.WriteLine("Корни:");
            Console.WriteLine(roots.Length switch
            {
                0 => "Действительных корней нет",
                1 => $"x = {roots[0]:F2}",
                _ => $"x₁ = {roots[0]:F2}, x₂ = {roots[1]:F2}"
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
}
