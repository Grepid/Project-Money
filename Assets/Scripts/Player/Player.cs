using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;

    private float money;
    private float premium;

    /*public delegate void CurrencyChangedEventHandler(float moneyDelta, float premiumDelta);

    public event CurrencyChangedEventHandler CurrencyChanged;

    protected virtual void OnCurrencyChanged(float moneyDelta, float premiumDelta)
    {
        CurrencyChanged?.Invoke(moneyDelta, premiumDelta);
    }*/


    // Properties
    public float Money
    {
        get
        {
            return money;
        }
        set
        {
            money = value;
            //OnCurrencyChanged(value, 0);
        }
    }

    public float Premium
    {
        get
        {
            return premium;
        }
        set
        {
            premium = value;
            //OnCurrencyChanged(0,value);
        }
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
