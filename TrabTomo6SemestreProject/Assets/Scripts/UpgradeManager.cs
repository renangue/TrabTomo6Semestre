using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager instance;
    
    public Button speedButton;
    
    public Button damagePowerButton;
    
    public Button fireRateButton;

    public Button lifeButton;

    public Button supportLifeButton;

    public Upgrade[] upgradeTree;

    public GameObject objectUI;

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

    //void Start()
    //{
    //    SetTexts(0, ref slingshot);
    //    SetTexts(1, ref ruler);
    //    SetTexts(2, ref guitar);
    //    SetTexts(3);
    //}

    //void OnEnable()
    //{
    //    slingshotButton.onClick.AddListener(delegate { Upgrade(0, ref slingshot); });
    //    rulerButton.onClick.AddListener(delegate { Upgrade(1, ref ruler); });
    //    guitarButton.onClick.AddListener(delegate { Upgrade(2, ref guitar); });
    //    lifeButton.onClick.AddListener(delegate { Upgrade(3); });
    //}

    //public void SetTexts(int index)
    //{
    //    Upgrade upgrade = upgradeTree[index];
    //    upgrade.actualBonusText.text = playerController.lifeMax.ToString();
    //    upgrade.costText.text = "$" + upgrade.rankUpgrades[upgrade.actualRankUpgrade].cost.ToString();
    //    upgrade.nextBonusText.text = (playerController.lifeMax + upgrade.rankUpgrades[upgrade.actualRankUpgrade].bonus).ToString();
    //}

    //public void SetTexts(int index, ref Weapon weapon)
    //{
    //    Upgrade upgrade = upgradeTree[index];
    //    weapon.SetDamage(weapon.preset.damage);
    //    upgrade.actualBonusText.text = weapon.damage.ToString();
    //    upgrade.costText.text = "$" + upgrade.rankUpgrades[upgrade.actualRankUpgrade].cost.ToString();
    //    upgrade.nextBonusText.text = (weapon.damage + upgrade.rankUpgrades[upgrade.actualRankUpgrade].bonus).ToString();
    //}

    //public void Upgrade(int index)
    //{
    //    Upgrade upgrade = upgradeTree[index];
    //    if (upgrade.actualRankUpgrade < upgrade.rankUpgrades.Length)
    //    {
    //        if (upgrade.rankUpgrades[upgrade.actualRankUpgrade].cost <= playerController.soulScore)
    //        {
    //            UpgradeLife(upgrade.rankUpgrades[upgrade.actualRankUpgrade].cost, upgrade.rankUpgrades[upgrade.actualRankUpgrade].bonus);
    //            upgrade.actualRankUpgrade++;
    //            if (upgrade.actualRankUpgrade < upgrade.rankUpgrades.Length)
    //            {
    //                upgrade.actualBonusText.text = playerController.lifeMax.ToString();
    //                upgrade.costText.text = "$" + upgrade.rankUpgrades[upgrade.actualRankUpgrade].cost.ToString();
    //                upgrade.nextBonusText.text = (playerController.lifeMax + upgrade.rankUpgrades[upgrade.actualRankUpgrade].bonus).ToString();
    //            }
    //            else
    //            {
    //                upgrade.actualBonusText.text = playerController.lifeMax.ToString();
    //                upgrade.costText.text = "";
    //                upgrade.nextBonusText.text = "";
    //            }
    //        }
    //    }
    //}

    //public void Upgrade(int index, ref Weapon weapon)
    //{
    //    Upgrade upgrade = upgradeTree[index];
    //    if (upgrade.actualRankUpgrade < upgrade.rankUpgrades.Length)
    //    {
    //        if (upgrade.rankUpgrades[upgrade.actualRankUpgrade].cost <= playerController.soulScore)
    //        {
    //            UpgradeWeapon(upgrade.rankUpgrades[upgrade.actualRankUpgrade].cost, upgrade.rankUpgrades[upgrade.actualRankUpgrade].bonus, ref weapon);
    //            upgrade.actualRankUpgrade++;

    //            if (upgrade.actualRankUpgrade < upgrade.rankUpgrades.Length)
    //            {
    //                upgrade.actualBonusText.text = weapon.damage.ToString();
    //                upgrade.costText.text = "$" + upgrade.rankUpgrades[upgrade.actualRankUpgrade].cost.ToString();
    //                upgrade.nextBonusText.text = (weapon.damage + upgrade.rankUpgrades[upgrade.actualRankUpgrade].bonus).ToString();
    //            }
    //            else
    //            {
    //                upgrade.actualBonusText.text = weapon.damage.ToString();
    //                upgrade.costText.text = "";
    //                upgrade.nextBonusText.text = "";
    //            }
    //        }
    //    }
    //}

    //public void UpgradeWeapon(int cost, int bonus, ref Weapon weapon)
    //{
    //    weapon.SetDamage(bonus);

    //    SpentSoul(-cost);
    //}

    //public void UpgradeLife(int cost, int bonus)
    //{
    //    playerController.UpdateMaxLife(bonus);

    //    SpentSoul(-cost);
    //}

    //public void SpentSoul(int amount)
    //{
    //    playerController.UpdateSoul(amount);
    //}

    //public void CloseWindow()
    //{
    //    objectUI.SetActive(false);
    //}
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
