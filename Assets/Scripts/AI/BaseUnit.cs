using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUnit : MonoBehaviour
{
    [Header("Statistics")]

    [SerializeField] private UnitStatistics _unitStatistics;
    public UnitStatistics unitStatistics { get { return _unitStatistics; } set { _unitStatistics = value; } }

    private float thisUnitsHealth;

    private float _distanceToPlayer;
    public float distanceToPlayer { get { return _distanceToPlayer; } set { _distanceToPlayer = value; } }


    [Header("Sound")]

    [SerializeField] private AudioSource unitAudio;


    private void Start()
    {
        unitAudio = GetComponent<AudioSource>();


        thisUnitsHealth = unitStatistics.health;
    }   


    private void Update() 
    {
        distanceToPlayer = Vector3.Distance(transform.position, unitStatistics.player.position);


        Attack();
        MoveToPlayer();




        if (thisUnitsHealth < 1)
        {
            KillUnit();
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        // deal Damage
    }


    public virtual void MoveToPlayer()
    {
        
    }


    public virtual void Attack()
    {

    }


    public void TakeDamage(float damage)
    {
        thisUnitsHealth -= damage;
    }


    private void KillUnit()
    {

    }

}
