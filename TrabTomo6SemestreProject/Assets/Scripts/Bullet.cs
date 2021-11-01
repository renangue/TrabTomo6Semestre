using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private string targetTag;
    
    [SerializeField]
    private float damage = -1 ;

    [SerializeField]
    private bool meele;

    private void OnTriggerEnter(Collider other)
    {
        if(meele)
        {
            other.GetComponent<NPC>().ReceiveDamageOrLife(damage);
            Destroy(gameObject);
        }
        else if(other.CompareTag(targetTag))
        {
            other.GetComponent<NPC>().ReceiveDamageOrLife(damage);
            Destroy(gameObject);
        }
    }
}
