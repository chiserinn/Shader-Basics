using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UIElements;

public class Graph:MonoBehaviour
{
    [SerializeField]
    Transform pointPrefab;

    [SerializeField, Range(10, 100)]
    int resolution = 10;

    [SerializeField]
    FunctionLibrary.FunctionName function;



    Transform[] points;

    private void Awake()
    {
        float block_space = 2f / resolution;
        var position = Vector3.zero;
        var scale = Vector3.one * block_space;

        points = new Transform[resolution * resolution];

        for (int i = 0, x = 0, z=0; i < points.Length; i++, x++)
        {
            if (x == resolution)
            {
                x = 0;
                z += 1;
            }
            Transform point = points[i] = Instantiate(pointPrefab);
            position.x = (x + 0.5f) * block_space - 1f;
            position.z = (z + 0.5f) * block_space - 1f;
            point.localPosition = position;
            point.localScale = scale;
            point.SetParent(transform, false);
        }

    }

    private void Update()
    {
        FunctionLibrary.Function f = FunctionLibrary.GetFunction(function);
        float time = Time.time;
        for (int i = 0; i < points.Length; i++)
        {
            Transform point = points[i];
            Vector3 position = point.localPosition;
            position.y = f(position.x, position.z, time);
           
            //sin(pi*(x+t))
            point.localPosition = position;
        }
    }
}
