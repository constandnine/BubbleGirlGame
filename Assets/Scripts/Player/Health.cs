using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("")]
    [SerializeField] private float health;

    public void takedamage(float damage)
    {
        health -= damage;
    }
}
