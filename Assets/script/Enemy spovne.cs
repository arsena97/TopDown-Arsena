using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemyspovne : MonoBehaviour
{
    [SerializeField] GameObject enemyPrafab;
    [SerializeField] float initiallSpawnRate = 2f;
    float spawnRate;
     void Start()
    {
        spawnRate = initiallSpawnRate;
    }
    void Update()
    {
        spawnRate -= Time.deltaTime;

        if (spawnRate <= 0)
        {
            Instantiate(enemyPrafab, transform.position, transform.rotation);
            spawnRate = initiallSpawnRate;


        }
    }
}
