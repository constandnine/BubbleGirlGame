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

    [SerializeField] private Transform throwPoint;

    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private GameObject projectile;

    [SerializeField] private float throwForce;
    [SerializeField] private float upwardForce;

    [SerializeField] private float range;
    private  float distanceToProjectile;


    [Header("SHooting")]

    [SerializeField] private float timeBetweenShots;

    private bool canShoot = true;

    private ProjectileManager projectileManager;





    /*    public override void MoveToPlayer()
        {
            transform.LookAt(player);
            
            
            if (distanceToPlayer > minimalDistanceToPlayer)
            {
                unitStatistics.agent.SetDestination(unitStatistics.player.position);
            }
        }*/


    public override void Attack()
    {
        if (distanceToPlayer <= attackDistanceToPlayer && projectile == null && canShoot == true)
        {
            //Spawns the projectile
            projectile = Instantiate(projectilePrefab, throwPoint.position, transform.rotation);


            projectileManager = projectile.GetComponent<ProjectileManager>();


            //Gets the rigidBody of the Projectile
            Rigidbody rb = projectile.GetComponent<Rigidbody>();


            // Gets the direction tha ball needs to be trown at and adds a slight curve.
            Vector3 throwDirection = (transform.forward * throwForce) + (Vector3.up * upwardForce);


            // Adds force to the projectile.
            rb.AddForce(throwDirection, ForceMode.Impulse);


            
            canShoot = false;
        }

        if (projectile != null)
        {
            distanceToProjectile = Vector3.Distance(projectile.transform.position, transform.position);


            if (distanceToProjectile > range)
            {
                projectileManager.DestroyProjectile();


                projectile = null;


                StopCoroutine(ShootCoolDown());

                StartCoroutine(ShootCoolDown());
            }
        }
    }


    private IEnumerator ShootCoolDown()
    {
        yield return new WaitForSeconds(timeBetweenShots);


        canShoot = true;
    }
}
