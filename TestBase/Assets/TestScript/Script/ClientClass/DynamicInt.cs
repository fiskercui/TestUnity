using System;

public class DynamicInt
{
    private int _value;

    public static implicit operator int(DynamicInt dynamicInt)
    {
        return dynamicInt.Value;
    }

    public static implicit operator DynamicInt(int value)
    {
        return new DynamicInt { Value = value };
    }

    public int Value
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

