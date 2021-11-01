using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondCoin : MonoBehaviour
{
    private GameObject player;
    public float speed = 2f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        transform.LookAt(player.transform, Vector3.up);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Destroy(gameObject);

            player.GetComponent<Wallet>().UpdateCash(1);
        }
    }
}
