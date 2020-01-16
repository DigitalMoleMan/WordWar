using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviorThug : EnemyController
{
    // Update is called once per frame
    public override void TypeUpdate()
    {
        float distanceFromTarget = (currentTarget.transform.position - transform.position).magnitude;

        targetInRange = (distanceFromTarget < visionRadius) ? true : false;

        GunController activeWeaponController = activeWeapon.GetComponent<GunController>();
        AudioSource shootSound = activeWeapon.GetComponent<AudioSource>();

        if (targetInRange) {
           MoveTowardsTarget();
            AimTowardsTarget(currentTarget.transform);

            if (activeWeaponController.cooldown == 0) {
                activeWeaponController.Use();


                if (activeWeaponController.automatic) {
                    if (!shootSound.isPlaying) shootSound.Play();
                } else shootSound.Play();
            }
        } else shootSound.Stop();
    }
}
