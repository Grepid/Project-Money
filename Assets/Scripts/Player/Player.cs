using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;

    private float money;
    private float premium;

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
