using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;

    Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Space))
        {
            offset = new Vector3(Random.Range(-2f, 2f), 1, Random.Range(-2f, 2f));

            Instantiate(coinPrefab, transform.position + offset, transform.rotation);
            Instantiate(coinPrefab, transform.position + offset, transform.rotation);
            Instantiate(coinPrefab, transform.position + offset, transform.rotation);
        } 
    }
}
