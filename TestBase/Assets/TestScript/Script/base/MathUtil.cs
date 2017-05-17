using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathUtil  {


    static public Rect ConvertToPixels(Rect rect, int width, int height, bool round)
    {
        Rect final = rect;

        if (round)
        {
            final.xMin = Mathf.RoundToInt(rect.xMin * width);
            final.xMax = Mathf.RoundToInt(rect.xMax * width);
            final.yMin = Mathf.RoundToInt((1f - rect.yMax) * height);
            final.yMax = Mathf.RoundToInt((1f - rect.yMin) * height);
        }
        else
        {
            final.xMin = rect.xMin * width;
            final.xMax = rect.xMax * width;
            final.yMin = (1f - rect.yMax) * height;
            final.yMax = (1f - rect.yMin) * height;
        }
        return final;
    }

    static public Rect ConvertToTexCoords(Rect rect, int width, int height)
    {
        Rect final = rect;

        if (width != 0f && height != 0f)
        {
            final.xMin = rect.xMin / width;
            final.xMax = rect.xMax / width;
            final.yMin = 1f - rect.yMax / height;
            final.yMax = 1f - rect.yMin / height;
        }
        return final;
    }

}
