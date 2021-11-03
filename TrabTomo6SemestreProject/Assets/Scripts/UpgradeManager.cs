using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager instance;

    public NPCStats stats;
    
    public Button speedButton;
    
    public Button damagePowerButton;
    
    public Button fireRateButton;

    public Button lifeButton;

    public Button supportLifeButton;
    
    public GameObject objectUI;

    public Wallet playerWallet;
    
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
        SetTexts(0);
        SetTexts(1);
        SetTexts(2);
        SetTexts(3);

    }

    void OnEnable()
    {
        lifeButton.onClick.AddListener(delegate { UpgradeLife(3); });
        speedButton.onClick.AddListener(delegate { UpgradeSpeed(0); });
        damagePowerButton.onClick.AddListener(delegate { UpgradeDamage(1); });
        fireRateButton.onClick.AddListener(delegate { UpgradeFireRate(2); });


        playerWallet = FindObjectOfType<Wallet>();
    }

    public void SetTexts(int index)
    {
        Upgrade upgrade = upgradeTree[index];
        upgrade.actualBonusText.text = stats.life.ToString();
        upgrade.costText.text = "$" + upgrade.rankUpgrades[upgrade.actualRankUpgrade].cost.ToString();
        upgrade.nextBonusText.text = (stats.life + upgrade.rankUpgrades[upgrade.actualRankUpgrade].bonus).ToString();
    }

    public void UpgradeLife(int index)
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
                    upgrade.costText.text = "$" + upgrade.rankUpgrades[upgrade.actualRankUpgrade].cost.ToString();
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

    public void UpgradeSpeed(int index)
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
                    upgrade.actualBonusText.text = stats.life.ToString();
                    upgrade.costText.text = "$" + upgrade.rankUpgrades[upgrade.actualRankUpgrade].cost.ToString();
                    upgrade.nextBonusText.text = (stats.speed + upgrade.rankUpgrades[upgrade.actualRankUpgrade].bonus).ToString();
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

    public void UpgradeDamage(int index)
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
                    upgrade.actualBonusText.text = stats.life.ToString();
                    upgrade.costText.text = "$" + upgrade.rankUpgrades[upgrade.actualRankUpgrade].cost.ToString();
                    upgrade.nextBonusText.text = (stats.damagePower + upgrade.rankUpgrades[upgrade.actualRankUpgrade].bonus).ToString();
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

    public void UpgradeFireRate(int index)
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
                    upgrade.actualBonusText.text = stats.life.ToString();
                    upgrade.costText.text = "$" + upgrade.rankUpgrades[upgrade.actualRankUpgrade].cost.ToString();
                    upgrade.nextBonusText.text = (stats.fireRate + upgrade.rankUpgrades[upgrade.actualRankUpgrade].bonus).ToString();
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

    public void IncreaseDamage(int cost, float bonus)
    {
        stats.damagePower += bonus;

        SpentCash(-cost);
    }

    public void IncreaseFireRate(int cost, float bonus)
    {
        stats.fireRate *= bonus/100;

        SpentCash(-cost);
    }

    public void IncreaseSpeed(int cost, float bonus)
    {
        stats.speed += bonus;

        SpentCash(-cost);
    }

    public void IncreaseLife(int cost, int bonus)
    {
        stats.life += bonus;

        SpentCash(-cost);
    }

    public void SpentCash(int amount)
    {
        playerWallet.UpdateCash(amount);
    }

    public void CloseWindow()
    {
        objectUI.SetActive(false);
    }
}
[System.Serializable]
public class Upgrade
{
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
