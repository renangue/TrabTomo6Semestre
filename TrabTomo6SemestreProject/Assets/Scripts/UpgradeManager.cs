using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager instance;

    public NPC[] players;

    public NPCStats stats;
    
    public Button speedButton;
    
    public Button damagePowerButton;
    
    public Button fireRateButton;

    public Button lifeButton;

    public Button supportShieldButton;

    public Button closeButton;
    
    public GameObject objectUI;

    public Wallet[] playerWallet;
    
    public Upgrade[] upgradeTree;

    private void Awake()
    {
        if (instance != null)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
    }

    void Start()
    {
        Time.timeScale = 0;    
    }

    public void Setup()
    {
        if(players[0].gameObject.activeSelf)
        {
            stats = players[0].stats;
        }

        if (players[1].gameObject.activeSelf)
        {
            stats = players[1].stats;
        }

        SetSpeed(0);
        SetDamage(1);
        SetFireRate(2);
        SetLife(3);
        SetSupportShield(4);

        playerWallet = FindObjectsOfType<Wallet>();
    }

    void OnEnable()
    {

        speedButton.onClick.AddListener(delegate { UpgradeSpeed(0); });
        damagePowerButton.onClick.AddListener(delegate { UpgradeDamage(1); });
        fireRateButton.onClick.AddListener(delegate { UpgradeFireRate(2); });
        lifeButton.onClick.AddListener(delegate { UpgradeLife(3); });
        supportShieldButton.onClick.AddListener(delegate { UpgradeShield(4); });

        closeButton.onClick.AddListener(delegate { CloseWindow(); });

    }

    void SetLife(int index)
    {
        Upgrade upgrade = upgradeTree[index];
        upgrade.actualBonusText.text = stats.life.ToString();
        upgrade.costText.text = upgrade.rankUpgrades[upgrade.actualRankUpgrade].cost.ToString();
        upgrade.nextBonusText.text = (stats.life + upgrade.rankUpgrades[upgrade.actualRankUpgrade].bonus).ToString();
    }

    void SetSpeed(int index)
    {
        Upgrade upgrade = upgradeTree[index];
        upgrade.actualBonusText.text = stats.speed.ToString();
        upgrade.costText.text = upgrade.rankUpgrades[upgrade.actualRankUpgrade].cost.ToString();
        upgrade.nextBonusText.text = (stats.speed + upgrade.rankUpgrades[upgrade.actualRankUpgrade].bonus).ToString();
    }

    void SetDamage(int index)
    {
        Upgrade upgrade = upgradeTree[index];
        upgrade.actualBonusText.text = stats.damagePower.ToString();
        upgrade.costText.text = upgrade.rankUpgrades[upgrade.actualRankUpgrade].cost.ToString();
        upgrade.nextBonusText.text = (stats.damagePower + upgrade.rankUpgrades[upgrade.actualRankUpgrade].bonus).ToString();
    }

    void SetFireRate(int index)
    {
        Upgrade upgrade = upgradeTree[index];
        upgrade.actualBonusText.text = stats.fireRate.ToString();
        upgrade.costText.text = upgrade.rankUpgrades[upgrade.actualRankUpgrade].cost.ToString();
        upgrade.nextBonusText.text = (stats.fireRate * (upgrade.rankUpgrades[upgrade.actualRankUpgrade].bonus)/ 100).ToString();
    }

    public void SetSupportShield(int index)
    {
        Upgrade upgrade = upgradeTree[index];
        upgrade.actualBonusText.text = stats.shieldForce.ToString();
        upgrade.costText.text = upgrade.rankUpgrades[upgrade.actualRankUpgrade].cost.ToString();
        upgrade.nextBonusText.text = (stats.shieldForce + upgrade.rankUpgrades[upgrade.actualRankUpgrade].bonus).ToString();
    }

    void UpgradeLife(int index)
    {
        Upgrade upgrade = upgradeTree[index];
        if (upgrade.actualRankUpgrade < upgrade.rankUpgrades.Length)
        {
            if (upgrade.rankUpgrades[upgrade.actualRankUpgrade].cost <= Wallet.cash)
            {
                IncreaseLife(upgrade.rankUpgrades[upgrade.actualRankUpgrade].cost, upgrade.rankUpgrades[upgrade.actualRankUpgrade].bonus);
                upgrade.actualRankUpgrade++;
                if (upgrade.actualRankUpgrade < upgrade.rankUpgrades.Length)
                {
                    upgrade.actualBonusText.text = stats.life.ToString();
                    upgrade.costText.text = upgrade.rankUpgrades[upgrade.actualRankUpgrade].cost.ToString();
                    upgrade.nextBonusText.text = (stats.life + upgrade.rankUpgrades[upgrade.actualRankUpgrade].bonus).ToString();
                }
                else
                {
                    upgrade.actualBonusText.text = stats.life.ToString();
                    upgrade.costText.text = "";
                    upgrade.nextBonusText.text = "";
                }
            }
        }
    }

    void UpgradeSpeed(int index)
    {
        Upgrade upgrade = upgradeTree[index];
        if (upgrade.actualRankUpgrade < upgrade.rankUpgrades.Length)
        {
            if (upgrade.rankUpgrades[upgrade.actualRankUpgrade].cost <= Wallet.cash)
            {
                IncreaseSpeed(upgrade.rankUpgrades[upgrade.actualRankUpgrade].cost, upgrade.rankUpgrades[upgrade.actualRankUpgrade].bonus);
                upgrade.actualRankUpgrade++;
                if (upgrade.actualRankUpgrade < upgrade.rankUpgrades.Length)
                {
                    upgrade.actualBonusText.text = stats.speed.ToString();
                    upgrade.costText.text = upgrade.rankUpgrades[upgrade.actualRankUpgrade].cost.ToString();
                    upgrade.nextBonusText.text = (stats.speed + upgrade.rankUpgrades[upgrade.actualRankUpgrade].bonus).ToString();
                }
                else
                {
                    upgrade.actualBonusText.text = stats.speed.ToString();
                    upgrade.costText.text = "";
                    upgrade.nextBonusText.text = "";
                }
            }
        }
    }

    void UpgradeDamage(int index)
    {
        Upgrade upgrade = upgradeTree[index];
        if (upgrade.actualRankUpgrade < upgrade.rankUpgrades.Length)
        {
            if (upgrade.rankUpgrades[upgrade.actualRankUpgrade].cost <= Wallet.cash)
            {
                IncreaseDamage(upgrade.rankUpgrades[upgrade.actualRankUpgrade].cost, upgrade.rankUpgrades[upgrade.actualRankUpgrade].bonus);
                upgrade.actualRankUpgrade++;
                if (upgrade.actualRankUpgrade < upgrade.rankUpgrades.Length)
                {
                    upgrade.actualBonusText.text = stats.damagePower.ToString();
                    upgrade.costText.text = upgrade.rankUpgrades[upgrade.actualRankUpgrade].cost.ToString();
                    upgrade.nextBonusText.text = (stats.damagePower + upgrade.rankUpgrades[upgrade.actualRankUpgrade].bonus).ToString();
                }
                else
                {
                    upgrade.actualBonusText.text = stats.damagePower.ToString();
                    upgrade.costText.text = "";
                    upgrade.nextBonusText.text = "";
                }
            }
        }
    }

    void UpgradeFireRate(int index)
    {
        Upgrade upgrade = upgradeTree[index];
        if (upgrade.actualRankUpgrade < upgrade.rankUpgrades.Length)
        {
            if (upgrade.rankUpgrades[upgrade.actualRankUpgrade].cost <= Wallet.cash)
            {
                IncreaseFireRate(upgrade.rankUpgrades[upgrade.actualRankUpgrade].cost, upgrade.rankUpgrades[upgrade.actualRankUpgrade].bonus);
                upgrade.actualRankUpgrade++;
                if (upgrade.actualRankUpgrade < upgrade.rankUpgrades.Length)
                {
                    upgrade.actualBonusText.text = stats.fireRate.ToString();
                    upgrade.costText.text = upgrade.rankUpgrades[upgrade.actualRankUpgrade].cost.ToString();
                    upgrade.nextBonusText.text = (stats.fireRate * (upgrade.rankUpgrades[upgrade.actualRankUpgrade].bonus) / 100).ToString();
                }
                else
                {
                    upgrade.actualBonusText.text = stats.fireRate.ToString();
                    upgrade.costText.text = "";
                    upgrade.nextBonusText.text = "";
                }
            }
        }
    }

    void UpgradeShield(int index)
    {
        Upgrade upgrade = upgradeTree[index];
        if (upgrade.actualRankUpgrade < upgrade.rankUpgrades.Length)
        {
            if (upgrade.rankUpgrades[upgrade.actualRankUpgrade].cost <= Wallet.cash)
            {
                IncreaseSupportField(upgrade.rankUpgrades[upgrade.actualRankUpgrade].cost, upgrade.rankUpgrades[upgrade.actualRankUpgrade].bonus);
                upgrade.actualRankUpgrade++;
                if (upgrade.actualRankUpgrade < upgrade.rankUpgrades.Length)
                {
                    upgrade.actualBonusText.text = stats.shieldForce.ToString();
                    upgrade.costText.text = upgrade.rankUpgrades[upgrade.actualRankUpgrade].cost.ToString();
                    upgrade.nextBonusText.text = (stats.shieldForce + upgrade.rankUpgrades[upgrade.actualRankUpgrade].bonus).ToString();
                }
                else
                {
                    upgrade.actualBonusText.text = stats.shieldForce.ToString();
                    upgrade.costText.text = "";
                    upgrade.nextBonusText.text = "";
                }
            }
        }
    }

    void IncreaseDamage(int cost, float bonus)
    {
        stats.damagePower += bonus;

        SpentCash(-cost);
    }

    void IncreaseFireRate(int cost, float bonus)
    {
        stats.fireRate *= bonus/100;

        SpentCash(-cost);
    }

    void IncreaseSpeed(int cost, float bonus)
    {
        stats.speed += bonus;

        SpentCash(-cost);
    }

    void IncreaseLife(int cost, int bonus)
    {
        stats.life += bonus;

        SpentCash(-cost);
    }

    void IncreaseSupportField(int cost, int bonus)
    {
        stats.shieldForce += bonus;

        SpentCash(-cost);
    }

    void SpentCash(int amount)
    {
        foreach (Wallet wallet in playerWallet)
        {
            wallet.UpdateCash(amount);
        }
        
    }

    void CloseWindow()
    {
        objectUI.SetActive(false);

        Time.timeScale = 1;
    }

    public void ResetRanks()
    {
        for (int i = 0; i < upgradeTree.Length; i++)
        {
            upgradeTree[i].actualRankUpgrade = 0;
        }
    }
}
[System.Serializable]
public class Upgrade
{
    public string upgradeName;
    public int actualRankUpgrade;
    public Text actualBonusText;
    public Text nextBonusText;
    public Text costText;
    public RankUpgrade[] rankUpgrades;
}
[System.Serializable]
public class RankUpgrade
{
    public int bonus;
    public int cost;
}
