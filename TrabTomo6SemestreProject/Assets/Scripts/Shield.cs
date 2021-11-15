using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public NPCStats stats;
    public GameObject support;

    int shieldPoints;

    int currentShieldPoints;

    void Start()
    {
        shieldPoints = stats.shieldForce;
        currentShieldPoints = shieldPoints;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Bullet"))
        {
            ApplyDamage();

            Destroy(other.gameObject);
        }
    }

    void Update()
    {
        if(currentShieldPoints <= 0)
        {
            gameObject.SetActive(false);
            support.SetActive(false);
        }
    }

    public void ApplyDamage()
    {
        --currentShieldPoints;

        print("escudo");
    }

    public void CreateShield()
    {
        gameObject.SetActive(true);
        support.SetActive(true);
    }

    public void ReinforceShield()
    {
        currentShieldPoints = shieldPoints;
    }
}
