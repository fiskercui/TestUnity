using System;

public class DynamicDouble
{
    private double _value;

    public static implicit operator double(DynamicDouble dynamicDouble)
    {
        return dynamicDouble.Value;
    }

    public static implicit operator DynamicDouble(double value)
    {
        return new DynamicDouble { Value = value };
    }

    public double Value
    {
        get
        {
            return this._value;
        }
        set
        {
            this._value = value;
        }
    }
}

