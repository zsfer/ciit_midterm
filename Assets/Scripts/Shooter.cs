using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject m_bulletPrefab;
    [SerializeField] private Transform m_bulletSpawn;

    void Start()
    {
        StartCoroutine(Shoot());
    }

    // Update is called once per frame
    IEnumerator Shoot()
    {
        while (!GameManager.Instance.isGameOver)
        {
            var bullet = Instantiate(m_bulletPrefab, m_bulletSpawn.position, m_bulletSpawn.rotation);
            Destroy(bullet, 10);
            yield return new WaitForSeconds(1);
        }
    }
}
