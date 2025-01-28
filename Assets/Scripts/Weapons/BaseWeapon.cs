using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;


public class BaseWeapon : MonoBehaviour
{
    private InputActions inputActions;

    [Header("Weapon Statistics")]

    [SerializeField] private WeaponStatistics _weaponStatistics;
    public WeaponStatistics weaponStatistics { get { return _weaponStatistics; } set {_weaponStatistics = value; } }

    private float maximalFireCoolDown;

    private float _thisWeaponMunition;
    public float thisWeaponMunition { get { return _thisWeaponMunition; } set { _thisWeaponMunition = value;} }


    private bool _canFire;
    public bool canFire { get { return _canFire; } set { _canFire = value; } }

    private bool _isReloadig;
    public bool isReloadig { get { return _isReloadig; } set { _isReloadig = value; } }


    [Header("Audio")]

    [SerializeField] private AudioSource _weaponAudio;
    public AudioSource weaponAudio{ get { return _weaponAudio; } set { _weaponAudio = value; } }


    private void Awake()
    {
        inputActions = new InputActions();


        // sets the weapons amunition to the amunition of the weapons Scriptble object's amunition amount.
        thisWeaponMunition = weaponStatistics.amunition;


        // flags the canFire to true so the weapon can fire.
        canFire = true;


        // Sets the maximal fire cooldown To 3 seconds for every type of gun;
        maximalFireCoolDown = 3f;


        //GEts the wreapons Audio Source.
        weaponAudio = GetComponent<AudioSource>();
        Debug.Log(weaponAudio);
    }


    private void OnEnable()
    {
        inputActions.Player.Shoot.Enable();
        inputActions.Player.Reload.Enable();
    }


    private void OnDisable()
    {
        inputActions.Player.Shoot.Disable();
        inputActions.Player.Reload.Disable();
    }


    public virtual void FireWeapon()
    {
        Debug.LogError("!No weapon!");
    }


    public void ReloadWeapon()
    {
        if (isReloadig == false)
        {
            StartCoroutine(Reload());
        }
    }


    public IEnumerator FireCoolDown()
    {
        // Calculate cooldown based on fireRate
        float cooldownTime = Mathf.Clamp(1f / weaponStatistics.fireRate, 0, maximalFireCoolDown);


        // Waits for the cooldown to end.
        yield return new WaitForSeconds(cooldownTime);


        // Flags the ecanFire to true
        canFire = true;
    }


    private IEnumerator Reload()
    {
        //Flags the is reloading to true so the weapon knows its realoding
        isReloadig = true;

        // flags canFire to False so the weapon cant fire during the reload procces.
        canFire = false;


        // play animation


        //Sets the audioClip of the AudioSource to the reload soundclip and playes it.
        weaponAudio.clip = weaponStatistics.reloadAudio;
        weaponAudio.Play();


        // Waits for the reload time to hit 0
        yield return new WaitForSeconds(weaponStatistics.reloadTime);


        // Resets the amunition.
        thisWeaponMunition = weaponStatistics.amunition;


        // flags the canfire to true so the weapon can fire again.
        canFire = true;

        //Flags the is reloading to true so the weapon knows its realoding
        isReloadig = false;
    }
}
