using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponAmmoGetter : MonoBehaviour
{

    private GunController playerWeapon;
    private Text nameDisplay;
    private Text ammoDisplay;
    // Start is called before the first frame update
    void Start()
    {
        nameDisplay = transform.Find("Weapon Name").GetComponent<Text>();
        ammoDisplay = transform.Find("Weapon Ammo").GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        playerWeapon = GameObject.Find("Player").GetComponent<PlayerController>().activeWeapon.GetComponent<GunController>();
        nameDisplay.text = playerWeapon.name;
        ammoDisplay.text = $"Ammo {playerWeapon.ammo}/{playerWeapon.maxAmmo}";
    }
}
