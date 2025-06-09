using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   [SerializeField] float speed = 1.5f;
    [SerializeField] int damage = 20;
    Transform player;
   
    void Start()
    {
        GameObject Player = GameObject.FindWithTag("Player") ;
        
        if (player != null)
        { 
            player = player.GetComponent<Transform>();
        }
    }

    void Update()
    {
        if (player == null) return;
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
    public int GetDamge()
    {
        return damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player)
        {
            Destroy(gameObject);
        }


    }

}
