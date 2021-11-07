using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayerPos : MonoBehaviour
{
    GameObject playerPos;
    private void Start()
    {
        playerPos = GameObject.Find("PlayerLocation");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            other.transform.position = playerPos.transform.position;
        }
    }
}
