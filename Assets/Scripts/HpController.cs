using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpController : MonoBehaviour
{
    public float hp = 5;
    // Start is called before the first frame update

    public void Damage(float dmg) {
        hp -= dmg;
    }
}
