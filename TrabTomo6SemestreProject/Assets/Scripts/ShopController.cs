using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    public GameObject shopUI;
    public Button healerButton;
    public Text lifeText;
    public int lifeCost = 50;
    
    public Button buySupportButton;
    public Text supportText;
    public int supportCost = 25;

    public Button closeButton;
    
    private NPC npc;
    private Wallet wallet;

    bool alreadyOpen = false;

    void Start()
    {
        healerButton.onClick.AddListener(delegate { BuyLife(lifeCost); });
        closeButton.onClick.AddListener(delegate { CloseShop(); });

        lifeText.text = lifeCost.ToString();
        supportText.text = supportCost.ToString();

        npc = FindObjectOfType<NPC>();
        wallet = FindObjectOfType<Wallet>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if(!alreadyOpen)
        {
            shopUI.SetActive(true);
            
            Time.timeScale = 0;
        }      
    }

    void BuySupport(int cost)
    {

    }

    void BuyLife(int cost)
    {
        if (Wallet.cash >= cost)
        {
            wallet.UpdateCash(-cost);
            npc.Heal();
        }
    }

    void CloseShop()
    {
        shopUI.SetActive(false);

        Time.timeScale = 1;

        alreadyOpen = true;
    }
}
