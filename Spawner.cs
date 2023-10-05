using System.Collections;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 3.0f;
    private float lastSpawnTime;

    public float timeToDestroyEnemy = 10.0f; // Tiempo para destruir al enemigo si no es eliminado

    private void Start()
    {
        lastSpawnTime = Time.time;
    }

    private void Update()
    {
        if (Time.time - lastSpawnTime >= spawnInterval)
        {
            SpawnEnemy();
            lastSpawnTime = Time.time;
        }
    }

    private void SpawnEnemy()
    {
        GameObject newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);

        // Configura las opciones de destrucci�n del enemigo aqu�
        EnemyBehavoiur enemyBehavior = newEnemy.GetComponent<EnemyBehavoiur>();
        if (enemyBehavior != null)
        {
            // Puedes configurar la destrucci�n despu�s de un tiempo
            Destroy(newEnemy, timeToDestroyEnemy);

            // O puedes configurar la destrucci�n cuando el enemigo salga de la vista de la c�mara
            Camera mainCamera = Camera.main;
            if (mainCamera != null)
            {
                DestroyOnCameraExit destroyOnCameraExit = newEnemy.AddComponent<DestroyOnCameraExit>();
                destroyOnCameraExit.SetCamera(mainCamera);
            }
        }
    }
}

