using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public GameObject bulletPrefab;

    Camera cam;
    [HideInInspector]public float width;
    //private float speed = 3f;

    bool isShooting;
    //float coolDown = 0.5f;
    [SerializeField] private ObjectPool objectPool = null;

    public ShipStats shipStats;

    private Vector2 offScreenPos = new Vector2(0, -20);
    private Vector2 startPos = new Vector2(0, -6);

    private void Awake()
    {
        cam = Camera.main;
        width = ((1 / (cam.WorldToViewportPoint(new Vector3(1, 1, 0)).x - .5f) / 2) - 0.25f);
    }

    void Start()
    {
        shipStats.currentHealt = shipStats.maxHealth;
        shipStats.currentLifes = shipStats.maxLifes;
        transform.position = startPos;
    }


    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKey(KeyCode.A) && transform.position.x > -width)
        {
            transform.Translate(Vector2.left * Time.deltaTime * shipStats.shipSpeed);
        }
        if (Input.GetKey(KeyCode.D) && transform.position.x < width)
        {
            transform.Translate(Vector2.right * Time.deltaTime * shipStats.shipSpeed);
        }
        if (Input.GetKey(KeyCode.Space) && !isShooting)
        {
            StartCoroutine(Shoot());
        }
#endif
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            collision.gameObject.SetActive(false);
            TakeDamage();
        }
    }

    public void TakeDamage()
    {
        shipStats.currentHealt--;
        Debug.Log(shipStats.currentHealt);
        if (shipStats.currentHealt<=0)
        {
            shipStats.currentLifes--;
            if (shipStats.currentLifes<=0)
            {
                Debug.Log("GameOver");
            }
            else
            {
                StartCoroutine(Respawn());
            }
        }
    }

    private IEnumerator Respawn()
    {
        transform.position = offScreenPos;

        yield return new WaitForSeconds(2f);

        shipStats.currentHealt = shipStats.maxHealth;

        transform.position = startPos;

    }

    private IEnumerator Shoot()
    {
        isShooting = true;

        //Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        GameObject obj = objectPool.GetPooledObject();
        obj.transform.position = gameObject.transform.position;
        yield return new WaitForSeconds(shipStats.fireRate);

        isShooting = false;
    }

}
