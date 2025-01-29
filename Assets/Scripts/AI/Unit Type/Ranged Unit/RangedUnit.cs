using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class RangedUnit : BaseUnit
{
    [Header("Distance")]

    [SerializeField] private float attackDistanceToPlayer;
    [SerializeField] private float minimalDistanceToPlayer;

    [Header("Projectile")]

    [SerializeField] private GameObject projectilePrefab;

    [SerializeField] private float throwForce;
    [SerializeField] private float upwardForce;


/*    public override void MoveToPlayer()
    {
        if (distanceToPlayer > minimalDistanceToPlayer)
        {
          //  unitStatistics.agent.SetDestination(unitStatistics.player.position);
        }
    }*/


    public override void Attack()
    {
        if (distanceToPlayer <= attackDistanceToPlayer)
        {
            //Spawns the projectile
            GameObject projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);


            //Gets the rigidBody of the Projectile
            Rigidbody rb = projectile.GetComponent<Rigidbody>();


            // Gets the direction tha ball needs to be trown at and adds a slight curve.
            Vector3 throwDirection = (transform.forward * throwForce) + (Vector3.up * upwardForce);


            // Adds force to the projectile.
            rb.AddForce(throwDirection, ForceMode.Impulse);
        }
    }
}
