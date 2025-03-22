using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Graph : MonoBehaviour
{
    [SerializeField]
    Transform pointPrefab;

    [SerializeField, Range (10,100)]
    int resolution = 10;
    int j = 0;
    int k = 0;

    private void Awake()
    {
        float block_space = 2f / resolution;
        var position = Vector3.zero;
        var scale = Vector3.one * block_space;
        for (int i = 0; i < resolution; i++) 
        {
            Transform point = Instantiate(pointPrefab);
            position.x =  (i+0.5f) * block_space - 1f;
            position.y = position.x * position.x;
            point.localPosition = position;
            point.localScale = scale;
            point.SetParent(transform, false);
        }
        while (j < 10)
        {
            j++;
            Debug.Log(j);

        }
        while (k < 10)
        {
            ++k;
            Debug.Log(k);


        }
    }


}
