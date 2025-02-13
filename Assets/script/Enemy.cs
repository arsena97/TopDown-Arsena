using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int hitCount = 3;
    void OnTriggerEnter2D(Collider2D col)
    {
        hitCount = hitCount - 1;
        if (hitCount == 0) Destroy(gameObject);
           // Destroy(gameObject);
       // Destroy(col.gameObject);
    }

}
