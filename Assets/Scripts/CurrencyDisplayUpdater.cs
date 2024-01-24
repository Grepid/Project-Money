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
        text.text = "Money: " + Player.instance.Money + "   Platinum: " + Player.instance.Premium;
    }


}
