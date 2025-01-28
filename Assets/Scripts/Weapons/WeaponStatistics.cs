using UnityEngine;


[CreateAssetMenu(fileName = "Weapons", menuName = "Base Weapon")]


public class WeaponStatistics : ScriptableObject
{
    [Header("Statistics")]

    [SerializeField] private int _amunition;
    public int amunition { get { return _amunition; } set { _amunition = value; } }

    [SerializeField]  private float _damage;
    public float damage { get { return _damage; } set { _damage = value; } }

    [SerializeField]  private float _reloadTime;
    public float reloadTime { get { return _reloadTime; } set { _reloadTime = value; } }

    [SerializeField]  private float _range;
    public float range { get { return _range; } set { _range = value; } }

    [SerializeField] private float _fireRate;
    public float fireRate { get { return _fireRate; } set { _fireRate = value; } }


    [Header("Audio")]

    [SerializeField] private AudioClip _reloadAudio;
    public AudioClip reloadAudio { get { return _reloadAudio; } set { _reloadAudio = value; } }

    [SerializeField] private AudioClip _shootAudio;
    public AudioClip shootAudio { get { return _shootAudio; } set { _shootAudio = value; } }
}
