using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    [Header("Other scripts")]

    [SerializeField] private Health health;

    [SerializeField] private UnitStatistics unitStatistics;
    [SerializeField] private RangedUnit rangedUnit;


    [Header("Layers")]

    [SerializeField] private LayerMask player;



    [SerializeField] private GameObject projectile;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == player)
        {
            health.takedamage(unitStatistics.damage);


            DestroyProjectile();
        }


        else
        {
            DestroyProjectile();
        }
    }


    public void DestroyProjectile()
    {
        Destroy(projectile);
    }
}
