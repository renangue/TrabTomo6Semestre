using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    public bool dontDestroy;
    public NPCStats stats;
    public Transform muzzle;
    public GameObject bullet;
    public Animator animator;
    public Image lifeBar;

    private CoinSpawner coinSpawner;
   
    public GameObject target;

    private float life;
    private float currentLife;
    public static float currentSavedLife;

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
           
            if(stats.type == NPCStats.Type.RANGED)
                combat.children.Add(new BTAttackEnemy());

            else
            {
                combat.children.Add(new BTMeleeAttack());
                Debug.Log(name + " Vai atacar");
            }
        }
        
        BehaviourTree bt = GetComponent<BehaviourTree>();

        bt.root = combat;

        StartCoroutine(bt.Begin());

        life = stats.life;

        currentLife = life;

        bullet.GetComponent<Bullet>().SetStat(stats);
    }

    private void OnEnable()
    {
        coinSpawner = GetComponent<CoinSpawner>();

        if (dontDestroy)
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Update()
    {
        if (currentLife <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void ReceiveDamageOrLife(float amount)
    {
        currentLife += amount;

        lifeBar.fillAmount = currentLife/life;

        currentLife = Mathf.Clamp(currentLife, 0, life);

        if (!gameObject.CompareTag("Player"))
        {
            if (currentLife <= 0)
                coinSpawner.Spawn();
        }
    }

    public void Attack()
    {
        target.GetComponent<NPC>().ReceiveDamageOrLife(-stats.damagePower);

        print(name + " Atacou");
    }
}
