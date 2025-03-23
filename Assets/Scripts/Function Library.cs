using UnityEngine;
using static UnityEngine.Mathf;

public static class FunctionLibrary
{    //directory
   public static float Wave(float x, float t)
    {
        return Sin(PI * (x + t));
    }

    public static float MultiWave (float x,float t)
    {
        float y =  Sin(PI * (x+t));
        y += Sin(2f * PI * (x + t)) / 2f;
        //2pi -> sin wavelength is 720 but pi * x -> frequency so 2pix also means it goes 2 times faster. we're also told to cut the amp by half
        return y;
    }
}
