using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemyspovne : MonoBehaviour
{
    [SerializeField] GameObject enemyPrafab;
    float spawnRate = 2.5f;

    void Update()
    {
        spawnRate -=  Time.deltaTime;

     if (spawnRate <= 0)
        {
            Instantiate(enemyPrafab,transform.position, transform.rotation);
            spawnRate = 2.5f;

        }
    }
}
