using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnBeThug : EnemyController
{
    // Update is called once per frame
    public override void TypeUpdate()
    {
        NavMeshAgent nav = GetComponent<NavMeshAgent>();
        nav.destination = currentTarget.transform.position;
        float distanceFromTarget = (currentTarget.transform.position - transform.position).magnitude;

        targetInRange = (distanceFromTarget < visionRadius) ? true : false;

        if (targetInRange) {
            MoveTowardsTarget();
            AimTowardsTarget(currentTarget.transform);
            activeWeapon.GetComponent<GunController>().Shoot();
        }
    }
}
