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
    public Shield forceField;
    public GameObject gameOverScreen;
    public GameObject winScreen;

    public AudioClip deathSFX;
    public AudioClip winSFX;
    public AudioClip[] attackSFX;
    public AudioClip[] damageSFX;

    private CoinSpawner coinSpawner;
   
    [HideInInspector]
    public GameObject target;

    private float life;
    private float currentLife;
    private Vector3 firstPos;

    private void OnEnable()
    {
        coinSpawner = GetComponent<CoinSpawner>();

        BTSequence combat = new BTSequence();
        combat.children.Add(new BTNearEnemy());
        combat.children.Add(new BTSpotEnemy());

        if (gameObject.CompareTag("Enemy") && stats.type == NPCStats.Type.RANGED)
        {
            combat.children.Add(new BTAttackEnemy());
        }
        else
        {
            combat.children.Add(new BTMoveToEnemy());

            if (stats.type == NPCStats.Type.RANGED)
            {
                combat.children.Add(new BTAttackEnemy());
                Debug.Log(name + " ranged");
            }
                
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

        firstPos = transform.position;
    }

    private void OnDisable()
    {
        if(gameObject.CompareTag("Player"))
        {
            Heal();

            transform.position = firstPos;
        }   
    }

    private void Update()
    {
        CheckLife();

        if(SceneLoader.level > 20)
        {
            winScreen.SetActive(true);

            AudioManager.PlaySFX(winSFX);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Undefeated();
        }
    }

    public void DontDestroy()
    {
        DontDestroyOnLoad(gameObject);     
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

        if(damageSFX.Length != 0)
            AudioManager.PlaySFX(GetRandomClip(damageSFX));
    }
    
    public void Heal()
    {
        currentLife = life;
        lifeBar.fillAmount = life;
    }

    public void Attack()
    {
        if(gameObject.CompareTag("Enemy"))
        {
            if(target.GetComponent<NPC>().forceField.gameObject.activeSelf)
                target.GetComponent<NPC>().forceField.ApplyDamage();
            
            else
                target.GetComponent<NPC>().ReceiveDamageOrLife(-stats.damagePower);

        }
        else
        {
            target.GetComponent<NPC>().ReceiveDamageOrLife(-stats.damagePower);
        }

        AudioManager.PlaySFX(GetRandomClip(attackSFX));
        
        print(name + " Atacou");
    }

    public AudioClip GetRandomClip(AudioClip[] clips)
    {
        return clips[UnityEngine.Random.Range(0, clips.Length)];
    }

    void CheckLife()
    {
        if (currentLife <= 0)
        {
            gameObject.SetActive(false);

            AudioManager.PlaySFX(deathSFX);

            SceneLoader.level = 1;

            if (gameObject.CompareTag("Player"))
            {
                gameOverScreen.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }

    void Undefeated()
    {
        if(gameObject.CompareTag("Player"))
        {
            life = 1000f;
            currentLife = life;
            lifeBar.fillAmount = life;
        }
    }
}
