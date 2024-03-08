
/*  Разработать класс Fraction, представляющий простую дробь. 
    в классе предусмотреть два поля: числитель и знаменатель дроби. 
    Выполнить перегрузку следующих операторов: +,-,*,/,==,!=,, true и false. 
    Арифметические действия и сравнение выполняется в соответствии с правилами работы с дробями. 
    Оператор true возвращает true если дробь правильная (числитель меньше знаменателя), 
    оператор false возвращает true если дробь неправильная (числитель больше знаменателя). 
    Выполнить перегрузку операторов, необходимых для успешной компиляции следующего фрагмента кода:*/

using System;

class Fraction
{
    private int numerator;
    private int denominator;

    public Fraction(int num, int denom)
    {
        numerator = num;
        denominator = denom;
    }

    public static Fraction operator +(Fraction f1, double d)
    {
        return new Fraction(f1.numerator + (int)(d * f1.denominator), f1.denominator);
    }

    public static Fraction operator +(Fraction f1, Fraction f2)
    {
        int newNumerator = f1.numerator * f2.denominator + f2.numerator * f1.denominator;
        int newDenominator = f1.denominator * f2.denominator;
        return new Fraction(newNumerator, newDenominator);
    }

    public static Fraction operator -(Fraction f1, Fraction f2)
    {
        int newNumerator = f1.numerator * f2.denominator - f2.numerator * f1.denominator;
        int newDenominator = f1.denominator * f2.denominator;
        return new Fraction(newNumerator, newDenominator);
    }

    public static Fraction operator *(Fraction f1, Fraction f2)
    {
        int newNumerator = f1.numerator * f2.numerator;
        int newDenominator = f1.denominator * f2.denominator;
        return new Fraction(newNumerator, newDenominator);
    }

    public static Fraction operator /(Fraction f1, Fraction f2)
    {
        int newNumerator = f1.numerator * f2.denominator;
        int newDenominator = f1.denominator * f2.numerator;
        return new Fraction(newNumerator, newDenominator);
    }

    public static bool operator ==(Fraction f1, Fraction f2)
    {
        return f1.numerator * f2.denominator == f2.numerator * f1.denominator;
    }

    public static bool operator !=(Fraction f1, Fraction f2)
    {
        return !(f1 == f2);
    }

    public static bool operator true(Fraction f)
    {
        return f.numerator < f.denominator;
    }

    public static bool operator false(Fraction f)
    {
        return f.numerator > f.denominator;
    }

    public static Fraction operator *(Fraction f1, int a)
    {
        return new Fraction(f1.numerator * a, f1.denominator);
    }

    public static Fraction operator *(int a, Fraction f1)
    {
        return f1 * a;
    }

    public override string ToString()
    {
        return $"{numerator}/{denominator}";
    }
}

class Program
{
    static void Main()
    {
        Fraction f = new Fraction(3, 4);
        int a = 10;
        Fraction f1 = f * a;
        Fraction f2 = a * f;
        double d = 1.5;
        Fraction f3 = f + d;

        Console.WriteLine("f1: " + f1);
        Console.WriteLine("f2: " + f2);
        Console.WriteLine("f3: " + f3);
    }
}
