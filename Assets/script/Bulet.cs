using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulet : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float bulletSpeed = 20f;
    [SerializeField] int damage = 10;
    void Start()
    {
        rb.AddForce(transform.up * bulletSpeed, ForceMode2D.Impulse);
        Destroy(gameObject, 2f);
    }

    public int GetDamage()
    { 
        return damage;
    }

}
