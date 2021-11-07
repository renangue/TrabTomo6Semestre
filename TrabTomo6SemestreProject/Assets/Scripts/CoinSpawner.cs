using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] coinPrefabs;

    private Vector3 offset;

    public void Spawn()
    {
        foreach (GameObject coin in coinPrefabs)
        {
            offset = new Vector3(Random.Range(-1, 1f), 1, Random.Range(-1, 1f));

            Instantiate(coin, transform.position + offset, Quaternion.identity);
        }
    }
}
