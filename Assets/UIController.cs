using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{

    private GameObject hpBar;
    // Start is called before the first frame update
    void Start()
    {
        hpBar = transform.Find("Hp Bar").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
