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

    private void Start()
    {
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
       

        while (canSpawn)
        {
            yield return new WaitForSeconds(spawnRate);
            int rand = Random.Range(0, EnemyPrefabs.Length);
            GameObject enemyToSpawn = EnemyPrefabs[rand];

            Instantiate(enemyToSpawn, transform.position, Quaternion.identity);
        }
    }
}
