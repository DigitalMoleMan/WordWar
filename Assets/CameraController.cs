using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform mainFocus;
    public int maxDistanceFromMain = 100;

    public Transform[] following;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 focusPoint = new Vector3();
        for(int i = 0; i < following.Length; i++)
        {
            focusPoint += following[i].position;
        }
        focusPoint /= following.Length;

        focusPoint.z = -10;

        float distFromMain = (mainFocus.position - focusPoint).magnitude - 10;

        if(distFromMain < maxDistanceFromMain)transform.position = focusPoint;
    }
}
