using System;

public class Fraction
{
    // Private attributes (Encapsulation)
    private int _top;
    private int _bottom;

    // --- Constructors ---

    // 1. No-argument constructor → defaults to 1/1
    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }

    // 2. One-argument constructor → numerator only, denominator = 1
    public Fraction(int top)
    {
        _top = top;
        _bottom = 1;
    }

    // 3. Two-argument constructor → numerator and denominator
    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }

    // --- Getters and Setters ---

    public int GetTop()
    {
        return _top;
    }

    public void SetTop(int top)
    {
        _top = top;
    }

    public int GetBottom()
    {
        return _bottom;
    }

    public void SetBottom(int bottom)
    {
        _bottom = bottom;
    }

    // --- Other Methods ---

    // Returns the fraction as a string, e.g. "3/4"
    public string GetFractionString()
    {
        return $"{_top}/{_bottom}";
    }

    // Returns the decimal value, e.g. 0.75
    public double GetDecimalValue()
    {
        return (double)_top / (double)_bottom;
    }
}
