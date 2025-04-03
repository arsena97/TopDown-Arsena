using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
   
  [SerializeField] float health;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        health -= 50;
        Debug.Log(health);
        Bulet bullet = collision.GetComponent<Bulet>();

        if (bullet) 
       
       {
            health -= bullet.GetDamage();
        }
       // if (health < 0)
       // {
       //     Destroy(gameObject);
       // }
    }


}
