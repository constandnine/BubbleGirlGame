using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BaseUnit : MonoBehaviour
{
    [Header("Statistics")]

    [SerializeField] private UnitStatistics _unitStatistics;
    public UnitStatistics unitStatistics { get { return _unitStatistics; } set { _unitStatistics = value; } }

    private float thisUnitsHealth;

    private float _distanceToPlayer;
    public float distanceToPlayer { get { return _distanceToPlayer; } set { _distanceToPlayer = value; } }

    [SerializeField] private NavMeshAgent _agent;
    public NavMeshAgent agent { get { return _agent; } set { _agent = value; } }


    [Header("Sound")]

    [SerializeField] private AudioSource unitAudio;


    private void Start()
    {
        unitAudio = GetComponent<AudioSource>();


       //agent = GetComponent<NavMeshAgent>();


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
        Destroy(gameObject);
    }

}
