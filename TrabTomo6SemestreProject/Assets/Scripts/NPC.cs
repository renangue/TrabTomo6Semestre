using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public NPCStats stats;
    public Transform muzzle;
    public GameObject bullet;
    public Animator animator;

    private CoinSpawner coinSpawner;

    [HideInInspector]
    public GameObject target;

    private float life;

    void Start()
    {
        BTSequence combat = new BTSequence();
        combat.children.Add(new BTNearEnemy());
        combat.children.Add(new BTSpotEnemy());
        
        if(gameObject.CompareTag("Enemy") && stats.type == NPCStats.Type.RANGED)
        {
            combat.children.Add(new BTAttackEnemy());
        }
        else
        {
            combat.children.Add(new BTMoveToEnemy());
            combat.children.Add(new BTAttackEnemy());
        }
        
        BehaviourTree bt = GetComponent<BehaviourTree>();

        bt.root = combat;

        StartCoroutine(bt.Begin());

        life = stats.life;
    }

    private void OnEnable()
    {
        coinSpawner = GetComponent<CoinSpawner>();
    }

    private void Update()
    {
        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void ReceiveDamageOrLife(float amount)
    {
        life += amount;

        if(!gameObject.CompareTag("Player"))
        {
            if (life <= 0)
                coinSpawner.Spawn();
        }
    }
}
