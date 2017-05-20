using System;
using System.Collections.Generic;

static class RotateSystem
{
    public enum eRotateMethod
    {
        eQuaternionRotateTowards,
        eVec3RotateTowards,
    }

    private static  eRotateMethod currentRotateMethod;
    public static  eRotateMethod RotateMethod { get {return currentRotateMethod;} set { currentRotateMethod = value; } }

}
