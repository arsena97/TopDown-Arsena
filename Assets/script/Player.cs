using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 9.5f;
    [SerializeField] Camera camera;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject bulletSpawnPoint;
    [SerializeField] GameObject ghostbulletPrefab;
    [SerializeField] float bulletFireRateDefoilt = 6f;
    float bulletFireRate = 3f;
    [SerializeField] int health = 30;
    [SerializeField] float ghostbulletFireRateDefoilt = 6f;
    float gostbulletFireRate = 6f;





    void Update()
    {
        Move();
        Turn();
        gostbulletFireRate -= Time.deltaTime;
        if (gostbulletFireRate <= 0 && Input.GetMouseButtonDown(1))
        {
            Instantiate(ghostbulletPrefab, bulletSpawnPoint.transform.position, transform.rotation);
            gostbulletFireRate = ghostbulletFireRateDefoilt;
        }
        bulletFireRate -= Time.deltaTime;
        if (bulletFireRate <= 0 && Input.GetMouseButtonDown(0))

        {
            Instantiate(bulletPrefab, bulletSpawnPoint.transform.position, transform.rotation);
            bulletFireRate = bulletFireRateDefoilt;
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        Debug.Log("damejaxa enemy");
        if (enemy)
        {
            health -= enemy.GetDamge();
        }
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }


}
