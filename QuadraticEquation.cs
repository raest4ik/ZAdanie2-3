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

    public double B
    {
        get => _b;
        set => _b = value;
    }

    public double C
    {
        get => _c;
        set => _c = value;
    }

    
    public QuadraticEquation() {}  
    
    public QuadraticEquation(double a, double b, double c)
    {
        A = a;  
        B = b;
        C = c;
    }

   
    public double[] Solve()
    {
        double discriminant = _b * _b - 4 * _a * _c;

        if (discriminant < 0) return Array.Empty<double>();
        if (discriminant == 0) return new[] { -_b / (2 * _a) };
        
        double sqrtD = Math.Sqrt(discriminant);
        return new[]
        {
            (-_b - sqrtD) / (2 * _a),
            (-_b + sqrtD) / (2 * _a)
        };
    }

    
    public override string ToString() => 
        $"Квадратное уравнение: {_a}x² + {_b}x + {_c} = 0";
}
