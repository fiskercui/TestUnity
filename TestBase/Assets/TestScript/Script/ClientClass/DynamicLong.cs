using System;

public class DynamicLong
{
    private long _value;

    public static implicit operator long(DynamicLong dynamicLong)
    {
        return dynamicLong.Value;
    }

    public static implicit operator DynamicLong(long value)
    {
        return new DynamicLong { Value = value };
    }

    public long Value
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

