using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    
        [SerializeField] float speed = 9.5f;
        [SerializeField] Camera camera;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject bulletSpawnPoint;
    [SerializeField]GameObject ghostbulletPrefab;
    [SerializeField] float bulletFireRate = 3f;
    [SerializeField] float gostbulletFireRateDefoilt;

   
    
     
    

    void Update()
    {
        Move();
        Turn();
        bulletFireRate -=  Time.deltaTime;
        if (bulletFireRate <= 0 && Input.GetMouseButtonDown(0))
        {
                Instantiate(bulletPrefab, bulletSpawnPoint.transform.position, transform.rotation);
            bulletFireRate = 3f;
        }
        

        
        if (Input.GetMouseButtonDown(1))
        {
            Instantiate(ghostbulletPrefab,bulletSpawnPoint.transform.position,transform.rotation);
        }
    }
    
        void Move()
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            transform.position = transform.position + new Vector3(horizontal, vertical) * Time.deltaTime * speed;
        }

        void Turn()
        {
            Vector2 mouseWorldPosition = camera.ScreenToWorldPoint(Input.mousePosition); 
        Vector2 lookDirection = mouseWorldPosition - (Vector2)transform.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(0, 0, angle);
}

    }