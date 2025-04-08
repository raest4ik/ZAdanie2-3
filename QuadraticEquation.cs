using System;

public class QuadraticEquation
{
    private double _a;
    private double _b;
    private double _c;

    public double A
    {
        get => _a;
        set => _a = value != 0 ? value : throw new ArgumentException("Коэффициент 'a' не может быть нулевым");
    }

    public double B { get; set; }
    public double C { get; set; }

    public QuadraticEquation(double a, double b, double c)
    {
        A = a;
        B = b;
        C = c;
    }

    public QuadraticEquation() { }

    public double[] Solve()
    {
        double discriminant = B * B - 4 * A * C;

        if (discriminant < 0) return Array.Empty<double>();
        if (discriminant == 0) return new[] { -B / (2 * A) };
        
        double sqrtD = Math.Sqrt(discriminant);
        return new[]
        {
            (-B - sqrtD) / (2 * A),
            (-B + sqrtD) / (2 * A)
        };
    }

    public override string ToString() => 
        $"Квадратное уравнение: {A}x² + {B}x + {C} = 0";

    // Унарные операции
    public static QuadraticEquation operator ++(QuadraticEquation eq)
    {
        return new QuadraticEquation(eq.A + 1, eq.B + 1, eq.C + 1);
    }

    public static QuadraticEquation operator --(QuadraticEquation eq)
    {
        return new QuadraticEquation(eq.A - 1, eq.B - 1, eq.C - 1);
    }

    // Операции приведения типа
    public static implicit operator double(QuadraticEquation eq)
    {
        return eq.B * eq.B - 4 * eq.A * eq.C;
    }

    public static explicit operator bool(QuadraticEquation eq)
    {
        return eq.B * eq.B - 4 * eq.A * eq.C >= 0;
    }

    // Бинарные операции
    public static bool operator ==(QuadraticEquation eq1, QuadraticEquation eq2)
    {
        if (ReferenceEquals(eq1, eq2)) return true;
        if (ReferenceEquals(eq1, null) || ReferenceEquals(eq2, null)) return false;
        return eq1.A == eq2.A && eq1.B == eq2.B && eq1.C == eq2.C;
    }

    public static bool operator !=(QuadraticEquation eq1, QuadraticEquation eq2)
    {
        return !(eq1 == eq2);
    }
}
