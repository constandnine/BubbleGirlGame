using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class FireShotgun : BaseWeapon
{
    [SerializeField] private int pelletCount;
    [SerializeField] private float spreadAngle;

    [SerializeField] private Transform firePoint;

    [SerializeField] private AudioClip pumpShotgun;


    public override void FireWeapon()
    {
        if (thisWeaponMunition > 0 && isReloadig == false)
        {
            if (canFire == true)
            {
                weaponAudio.clip = weaponStatistics.shootAudio;
                weaponAudio.Play();
                //weaponAudio.clip = null;

                print("123");


                thisWeaponMunition--;


                for (int i = 0; i < pelletCount; i++)
                {
                    float xSpreadAngle = Random.Range(-spreadAngle, spreadAngle);
                    float ySpreadAngle = Random.Range(-spreadAngle, spreadAngle);


                    Vector3 direction = firePoint.forward + new Vector3(xSpreadAngle, ySpreadAngle, 0);


                    direction.Normalize();


                    if (Physics.Raycast(firePoint.position, direction, out RaycastHit hit, weaponStatistics.range))
                    {
                        //damage


                        Debug.DrawRay(firePoint.position, direction * hit.distance, Color.black);
                    }
                }


                // Starts the reload procces.
                StartCoroutine(FireCoolDown());


                weaponAudio.clip = pumpShotgun;
                weaponAudio.Play();
            }
        }
    }


    public void OnReload()
    {
        ReloadWeapon();
    }
}
