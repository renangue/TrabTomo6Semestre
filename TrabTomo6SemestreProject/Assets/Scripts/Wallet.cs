using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wallet : MonoBehaviour
{
    public static int cash = 20;

    public Text cashText;

    private void OnEnable()
    {
        //cashText = GameObject.Find("CashText");
        //cashText = cashText.GetComponent<Text>();
    }

    private void Update()
    {
        cashText.text = cash.ToString();
    }

    public void UpdateCash(int amount)
    {
        cash += amount;
    }
}
