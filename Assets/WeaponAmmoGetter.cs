using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponAmmoGetter : MonoBehaviour
{

    private PlayerController player;
    private GunController playerWeapon;
    private Transform weaponInfoContainer;
    private Text weaponNameDisplay;
    private Text weaponAmmoDisplay;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        weaponInfoContainer = transform.Find("Weapon Info");
        weaponNameDisplay = weaponInfoContainer.Find("Weapon Name").GetComponent<Text>();
        weaponAmmoDisplay = weaponInfoContainer.Find("Weapon Ammo").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        playerWeapon = player.activeWeapon.GetComponent<GunController>();
        weaponNameDisplay.text = playerWeapon.name;
        //weaponAmmoDisplay.text = $"Ammo {playerWeapon.ammo}/{playerWeapon.maxAmmo}";
    }
}
