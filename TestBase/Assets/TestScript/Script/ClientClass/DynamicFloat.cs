using System;

public class DynamicFloat
{
    private float _value;

    public static implicit operator float(DynamicFloat dynamicFloat)
    {
        return dynamicFloat.Value;
    }

    public static implicit operator DynamicFloat(float value)
    {
        return new DynamicFloat { Value = value };
    }

    public float Value
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

