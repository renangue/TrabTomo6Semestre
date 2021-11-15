using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public GameObject support;

    public int shieldPoints = 3;

    int currentShieldPoints;

    void Start()
    {
        currentShieldPoints = shieldPoints;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Bullet"))
        {
            --currentShieldPoints;

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

    public void CreateShield()
    {
        gameObject.SetActive(true);
        support.SetActive(true);
    }

    public void ReinforceShield()
    {
        currentShieldPoints = shieldPoints;
    }

    public void UpgradeShield(int amount)
    {
        shieldPoints += amount;
    }
}
