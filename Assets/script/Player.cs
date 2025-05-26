
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 9.5f;
    [SerializeField] Camera camera;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject bulletSpawnPoint;
    [SerializeField] GameObject ghostbulletPrefab;
    [SerializeField] float bulletFireRateDefoilt = 6f;
    float bulletFireRate = 3f;
    [SerializeField] int health = 50;
    [SerializeField] float ghostbulletFireRateDefoilt = 6f;
    float gostbulletFireRate = 6f;
    [SerializeField] TextMeshProUGUI healthtext;
    [SerializeField] SceneLoader sceneLoader;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip bulletSound;
    [SerializeField] AudioClip lossSound;
    private void Start()
    {
        healthtext.text = "Health:" + health ;
      
    }

    void Update()
    {
        Move();
        Turn();
        gostbulletFireRate -= Time.deltaTime;
        if (gostbulletFireRate <= 0 && Input.GetMouseButtonDown(1))
        {
            audioSource.PlayOneShot(bulletSound);
            Instantiate(ghostbulletPrefab, bulletSpawnPoint.transform.position, transform.rotation);
            gostbulletFireRate = ghostbulletFireRateDefoilt;
        }
        bulletFireRate -= Time.deltaTime;
        if (bulletFireRate <= 0 && Input.GetMouseButtonDown(0))

        {
            audioSource.PlayOneShot(bulletSound);
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
            healthtext.text = "Health:" + health;
            if (health <= 200)
            {
                healthtext.color = Color.yellow;
            }
            if (health <= 100)
            {
                healthtext.color = Color.red;
            }
        }
        if (health <= 0)
        {
            audioSource.PlayOneShot(lossSound);
            Destroy(gameObject);
            sceneLoader.LoadGameOverUI();
        }
    }
   
   
}
