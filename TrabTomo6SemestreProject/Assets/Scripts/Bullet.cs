using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [HideInInspector]
    public NPCStats stats;

    [SerializeField]
    private string targetTag;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(targetTag))
        {
            other.GetComponent<NPC>().ReceiveDamageOrLife(-stats.damagePower);
            Destroy(gameObject);
        }
    }

    public void SetStat(NPCStats _stats)
    {
        stats = _stats;
    }
}
