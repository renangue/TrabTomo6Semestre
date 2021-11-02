using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wallet : MonoBehaviour
{
    public static int cash;
    public int diamonds;
    public Text cashText;

    private void Start()
    {
        cash = diamonds;
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
