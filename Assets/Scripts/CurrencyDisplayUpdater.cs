using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurrencyDisplayUpdater : MonoBehaviour
{
    private TextMeshProUGUI text;

    [SerializeField]bool displayingPremium;
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
        if (displayingPremium)
        {
            text.text = Player.instance.Premium.ToString();
        }
        else
        {
            text.text = Player.instance.Money.ToString();
        }
        
    }


}
