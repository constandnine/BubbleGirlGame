using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "Units", menuName = "Unit Statistics")]


public class UnitStatistics : ScriptableObject
{
    [Header("Navmesh")]

    [SerializeField] private NavMeshAgent _agent;
    public NavMeshAgent agent { get { return _agent; } set { _agent = value; } }

    [SerializeField] private Transform _player;
    public Transform player { get { return _player; } set { _player = value; } }


    [Header("Statistics")]

    [SerializeField] private float _damage;
    public float damage { get { return _damage; } set { _damage = value; } }

    [SerializeField] private float _health;
    public float health { get { return _health; } set { _health = value; } }


    [Header("Sound")]

    [SerializeField] private AudioClip _Hitsound;
    public AudioClip hitsound { get { return _Hitsound; } set { _Hitsound = value; } }

    [SerializeField] private AudioClip _attackSound;
    public AudioClip attackSound { get { return _attackSound; } set { _attackSound = value; } }

    [SerializeField] private AudioClip _deathSound;
    public AudioClip deathSound { get { return _deathSound; } set { _deathSound = value; } }
}
