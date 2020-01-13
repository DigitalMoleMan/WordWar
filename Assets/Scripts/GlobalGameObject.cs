using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalGameObject : MonoBehaviour
{
    // Start is called before the first frame update
    GameController GetGameController()
    {
        return GameObject.Find("World").GetComponent<GameController>();
    }

}
