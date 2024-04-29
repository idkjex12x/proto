using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private float spawnRate = 1.0f;

    [SerializeField]
    private GameObject[] EnemyPrefabs;

    [SerializeField]
    private bool canSpawn = true;


    public Transform playerTransform;
    public bool isfollowing;
    public float followingDistance;
    private void Start()
    {
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
       if (isfollowing)
        {
            if (transform.position.x > playerTransform.position.x)
            {
                transform.localScale = new Vector3 (1, 1, 1);
                transform.position += Vector3.left * spawnRate * Time.deltaTime;
            }
            if (transform.position.x < playerTransform.position.x)
            {
                transform.localScale = new Vector3(1, 1, 1);
                transform.position += Vector3.right * spawnRate * Time.deltaTime;
            }
        }

        while (canSpawn)
        {
            yield return new WaitForSeconds(spawnRate);
            int rand = Random.Range(0, EnemyPrefabs.Length);
            GameObject enemyToSpawn = EnemyPrefabs[rand];

            Instantiate(enemyToSpawn, transform.position, Quaternion.identity);
        }
    }
   
}
