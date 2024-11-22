using System;
using System.Text;

class Sphere
{
    protected double b1, b2, b3, R;

    public virtual void InputCoefficients()
    {
        Console.WriteLine("Введіть координати центру сфери (b1, b2, b3):");
        b1 = double.Parse(Console.ReadLine());
        b2 = double.Parse(Console.ReadLine());
        b3 = double.Parse(Console.ReadLine());

        Console.WriteLine("Введіть радіус сфери (R):");
        R = double.Parse(Console.ReadLine());

        if (R <= 0)
        {
            throw new ArgumentException("Радіус сфери повинен бути додатнім!");
        }
    }

    public virtual void DisplayCoefficients()
    {
        Console.WriteLine($"Рівняння сфери: (x1 {FormatSign(-b1)})^2 + (x2 {FormatSign(-b2)})^2 + (x3 {FormatSign(-b3)})^2 = {R}^2");
    }

    public virtual double CalculateVolume()
    {
        return (4.0 / 3.0) * Math.PI * Math.Pow(R, 3);
    }

    protected string FormatSign(double value)
    {
        return value > 0 ? $"+ {value}" : $"- {-value}";
    }
}

class Ellipsoid : Sphere
{
    private double a1, a2, a3;

    public override void InputCoefficients()
    {
        Console.WriteLine("Введіть координати центру еліпсоїда (b1, b2, b3):");
        b1 = double.Parse(Console.ReadLine());
        b2 = double.Parse(Console.ReadLine());
        b3 = double.Parse(Console.ReadLine());

        Console.WriteLine("Введіть напівосі еліпсоїда (a1, a2, a3):");
        a1 = double.Parse(Console.ReadLine());
        a2 = double.Parse(Console.ReadLine());
        a3 = double.Parse(Console.ReadLine());

        if (a1 <= 0 || a2 <= 0 || a3 <= 0)
        {
            throw new ArgumentException("Напівосі еліпсоїда повинні бути додатніми!");
        }
    }

    public override void DisplayCoefficients()
    {
        Console.WriteLine($"Рівняння еліпсоїда: ((x1 {FormatSign(-b1)})^2 / {a1}^2) + ((x2 {FormatSign(-b2)})^2 / {a2}^2) + ((x3 {FormatSign(-b3)})^2 / {a3}^2) = 1");
    }

    public override double CalculateVolume()
    {
        return (4.0 / 3.0) * Math.PI * a1 * a2 * a3;
    }
}

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine("Виберіть, що створити: 1 - Куля, 2 - Еліпсоїд");
        int choice = int.Parse(Console.ReadLine());

        try
        {
            if (choice == 1)
            {
                Sphere sphere = new Sphere();
                sphere.InputCoefficients();
                sphere.DisplayCoefficients();
                Console.WriteLine($"Об'єм сфери: {sphere.CalculateVolume():F2}");
            }
            else if (choice == 2)
            {
                Ellipsoid ellipsoid = new Ellipsoid();
                ellipsoid.InputCoefficients();
                ellipsoid.DisplayCoefficients();
                Console.WriteLine($"Об'єм еліпсоїда: {ellipsoid.CalculateVolume():F2}");
            }
            else
            {
                Console.WriteLine("Невірний вибір.");
            }
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Помилка: Введено недійсні числові значення.");
        }
    }
}