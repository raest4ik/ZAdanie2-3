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
            TestOperations();
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

    static void TestOperations()
    {
        try
        {
            var eq1 = new QuadraticEquation(1, -5, 6);
            Console.WriteLine($"\nИсходное уравнение: {eq1}");

            var eq2 = ++eq1;
            Console.WriteLine($"Уравнение после ++: {eq2}");

            var eq3 = --eq2;
            Console.WriteLine($"Уравнение после --: {eq3}");

            double discriminant = (double)eq3;
            Console.WriteLine($"Дискриминант: {discriminant}");

            bool hasRoots = (bool)eq3;
            Console.WriteLine($"Существуют ли корни: {hasRoots}");

            var eq4 = new QuadraticEquation(1, -5, 6);
            Console.WriteLine($"Уравнения равны: {eq3 == eq4}");
            Console.WriteLine($"Уравнения не равны: {eq3 != eq4}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
}
