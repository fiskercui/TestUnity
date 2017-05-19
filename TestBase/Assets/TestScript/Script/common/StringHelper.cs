using Pb;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringHelper  {


    public static void makeU64GUID(string input, ref string[] output)
    {
        output = input.Split('|');
    }

    public static string makeStrGUID(U64Type src)
    {
        return src.high + "|" + src.low;

    }
}
