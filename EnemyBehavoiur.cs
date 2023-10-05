using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavoiur : MonoBehaviour
{
    [Header("Vida")]
    public int maxHealth = 50; // Vida máxima del enemigo
    private int currentHealth; // Vida actual del enemigo

    [Header("Speed")]
    public float speedX = 2f; // Velocidad en el eje X

    [Header("Disparo")]
    public GameObject prefabDisparo;
    public float disparoSpeed = 2f;
    public float shootingInterval = 6f;
    public float timeDisparoDestroy = 2f;

    private float _shootingTimer;

    public Transform weapon1;
    public Transform weapon2;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _shootingTimer = Random.Range(0f, shootingInterval);

        // Configura la velocidad en el eje X
        rb.velocity = new Vector2(speedX, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        StartFire();
    }

    public void StartFire()
    {
        _shootingTimer -= Time.deltaTime;
        if (_shootingTimer <= 0f)
        {
            _shootingTimer = shootingInterval;
            GameObject disparoInstance = Instantiate(prefabDisparo);
            disparoInstance.transform.SetParent(transform.parent);
            disparoInstance.transform.position = weapon1.position;
            disparoInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, disparoSpeed);
            Destroy(disparoInstance, timeDisparoDestroy);

            GameObject disparoInstance2 = Instantiate(prefabDisparo);
            disparoInstance2.transform.SetParent(transform.parent);
            disparoInstance2.transform.position = weapon2.position;
            disparoInstance2.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, disparoSpeed);
            Destroy(disparoInstance2, timeDisparoDestroy);
        }
    }

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.tag == "disparoPlayer" || otherCollider.tag == "Player")
        {
            gameObject.SetActive(false);
            Destroy(otherCollider.gameObject);
        }
    }
}
