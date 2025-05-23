using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Health : MonoBehaviour
{

   [SerializeField] int health = 100;
     Score score;
    private void Start()
    {
        score = GameObject.FindWithTag("Score").GetComponent<Score>();
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Bulet bullet = collision.GetComponent<Bulet>();
        if (bullet)
        {
            health -= 50;
        }

        if (health <= 0)
        {
            Destroy(gameObject);
            score.IncreaseScore();
           
        }
    }
}
