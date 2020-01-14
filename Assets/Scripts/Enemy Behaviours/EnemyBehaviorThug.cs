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

        if (targetInRange) {
           MoveTowardsTarget();
            AimTowardsTarget(currentTarget.transform);
            activeWeapon.GetComponent<GunController>().Use();
        }
    }
}
