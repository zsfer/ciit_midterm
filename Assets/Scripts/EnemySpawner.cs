using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject m_enemyPrefab;
    [SerializeField] private Transform[] m_spawnPoints;

    private int currentSpawnPoint;

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (!GameManager.Instance.isGameOver)
        {
            var spawnPoint = m_spawnPoints[currentSpawnPoint];
            Instantiate(m_enemyPrefab, spawnPoint.position, Quaternion.identity);

            currentSpawnPoint = (currentSpawnPoint + 1) % m_spawnPoints.Length;
            yield return new WaitForSeconds(1.5f);
        }
    }
}
