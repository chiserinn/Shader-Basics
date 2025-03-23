using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UIElements;

public class Expanded_Functions : MonoBehaviour
{
    [SerializeField]
    Transform pointPrefab;

    [SerializeField, Range (10,100)]
    int resolution = 10;

    [SerializeField]
    float A;

    [SerializeField]
    string cos_or_sine;

    [SerializeField]
    float B;

    [SerializeField]
    float C;

    [SerializeField]
    float D;

    
    //fx = 2 sin (2(x - 3pi/8)) + 4
    //f(x) = A sin(B(x-C))+D
    //sin or cos //
    //sin amplitude (A)
    //B
    //C
    //D

    

    Transform[] points;

    private void Awake()
    {
        float block_space = 2f / resolution;
        var position = Vector3.zero;
        var scale = Vector3.one * block_space;

        points = new Transform[resolution];
  

        for (int i = 0; i < points.Length; i++) 
        {
            Transform point = points[i] = Instantiate(pointPrefab);
            position.x =  (i+0.5f) * block_space - 1f;
            point.localPosition = position;
            point.localScale = scale;
            point.SetParent(transform, false);
            

        }
        
    }

    private void Update()
    {   
        float time = Time.time;
        string cos_sine=cos_or_sine;


        for (int i = 0; i < points.Length;i++) {
            Transform point = points[i];
            Vector3 position = point.localPosition;
            if (cos_sine == "cos")
            {
                position.y = A* Mathf.Cos(Mathf.PI * (position.x + time));
            }
            if (cos_sine == "sin")
            {
                position.y = A* Mathf.Sin(Mathf.PI * (position.x + time));
            }
            else
            {
                Debug.Log("Error")
            }

            //sin(pi*(x+t))
            point.localPosition = position;
        }
    }


}
