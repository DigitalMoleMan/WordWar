using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform mainFocus;
    public int maxDistanceFromMain = 100;


    public Transform[] following;

    public Vector3 offset;

    void Start()
    {
        Application.targetFrameRate = 60;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 focusPoint = new Vector3();
        for(int i = 0; i < following.Length; i++) focusPoint += following[i].position;

        focusPoint /= following.Length;

        focusPoint += offset;

        transform.position = focusPoint;
    }
}
