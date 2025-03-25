using UnityEngine;
using static UnityEngine.Mathf;

public static class FunctionLibrary
{    //directory

    public delegate float Function(float x, float z, float t);
    public enum FunctionName { Wave, MultiWave, Ripple }

    static Function[] functions = { Wave, MultiWave, Ripple };
    
    public static Function GetFunction (FunctionName name)
    {
        return functions[(int)name];
    }



    public static float Wave(float x, float z, float t)
    {
        return Sin(PI * (x +z+ t));
    }

    public static float MultiWave (float x, float z, float t)
    {
        float y =  Sin(PI * (x+ 0.5f * t));
        y += 0.5f * Sin(2f * PI * (z + t));
        y += Sin(PI * (x + z + 0.25f * t));
        //2pi -> sin wavelength is 720 but pi * x -> frequency so 2pix also means it goes 2 times faster. we're also told to cut the amp by half
        return y * (1f/2.5f) ;
    }

    public static float Ripple (float x, float z, float t)
    {
        float d = Sqrt(x * x + z * z);
        float y = Sin(PI * (4f * d - t));
        return y/(1f +10f *d);
    }
}
