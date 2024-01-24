using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurrencyDisplayUpdater : MonoBehaviour
{
    private TextMeshProUGUI text;
    private void Start()
    {
        //SubscribeToCurrencyChanged();
        text = GetComponent<TextMeshProUGUI>();
    }


    /*public void SubscribeToCurrencyChanged()
    {
        Player.instance.CurrencyChanged += UpdateCurrency;
    }
    public void UpdateCurrency(float moneyDelta, float premiumDelta)
    {
        print("Test");
    }*/

    private void Update()
    {
        text.text = "Money: " + System.Math.Round(Player.instance.Money) + "   Platinum: " + Player.instance.Premium;
    }


}
