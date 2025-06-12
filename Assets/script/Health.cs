using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
public class Health : MonoBehaviour
{

    [SerializeField] int health = 100;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip destroysound;
    [SerializeField] Enemy enemy;
    [SerializeField] BoxCollider2D collider;
    [SerializeField] SpriteRenderer sprite;
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
            Disablecomponents();
            audioSource.PlayOneShot(destroysound);
            score.IncreaseScore();
            Destroy(gameObject, destroysound.length);
        }
        
    }
    private void Disablecomponents()
    {
        collider.enabled = false;
        sprite.enabled = false;
        enemy.enabled = false;
    }
}
