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
        BTInverter noEnemyNear = new BTInverter();
        noEnemyNear.child = new BTNearEnemy();

        BTSequenceParallel moveToExit = new BTSequenceParallel();
        moveToExit.children.Add(noEnemyNear);
        moveToExit.children.Add(new BTMoveToExit());

        BTSequence combat = new BTSequence();
        combat.children.Add(new BTNearEnemy());
        combat.children.Add(new BTSpotEnemy());

        if (stats.type == NPCStats.Type.MELEE)
        {
            combat.children.Add(new BTMoveToEnemy());
            combat.children.Add(new BTAttackEnemy());
        }

        else combat.children.Add(new BTAttackEnemy());

        BTSequence walk = new BTSequence();
        walk.children.Add(new BTSpotExit());
        walk.children.Add(moveToExit); 

        BTSelector selector = new BTSelector();
        selector.children.Add(combat);
        selector.children.Add(walk); 

        BehaviourTree bt = GetComponent<BehaviourTree>();

        if (bt.CompareTag("Player")) bt.root = selector;

        else bt.root = combat;

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
