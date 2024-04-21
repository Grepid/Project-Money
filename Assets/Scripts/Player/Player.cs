using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    public static Player instance;

    private double money;
    private int premium;

    public static RaycastHit2D rayHit;

    private PlayerControls controls;

    private static Vector2 pointerPos;

    [SerializeField] private float fpsBeforeSolidAuto;
    public float FPSBeforeSolidAuto => fpsBeforeSolidAuto;


    /*public delegate void CurrencyChangedEventHandler(float moneyDelta, float premiumDelta);

    public event CurrencyChangedEventHandler CurrencyChanged;

    protected virtual void OnCurrencyChanged(float moneyDelta, float premiumDelta)
    {
        CurrencyChanged?.Invoke(moneyDelta, premiumDelta);
    }*/


    // Properties
    public double Money
    {
        get
        {
            return money;
        }
        set
        {
            money = System.Math.Round(value);
            //OnCurrencyChanged(value, 0);
        }
    }

    public int Premium
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

    private void OnEnable()
    {
        controls.Player.Enable();
    }
    private void OnDisable()
    {
        controls.Player.Disable();
    }

    private void Awake()
    {
        controls = new PlayerControls();


        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        controls.Player.PointerLocation.performed += context => pointerPos = context.ReadValue<Vector2>();
        controls.Player.PointerLocation.canceled += context => pointerPos = Vector2.zero;

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
                
    }
    void Raycast()
    {
        Ray ray = Camera.main.ScreenPointToRay(pointerPos);
        rayHit = Physics2D.Raycast(ray.origin,Vector2.zero);
    }
    public static List<RaycastResult> UICast()
    {
        List<RaycastResult> result = new List<RaycastResult>();

        PointerEventData pointerData = new PointerEventData(EventSystem.current);
        pointerData.position = pointerPos;

        EventSystem.current.RaycastAll(pointerData, result);

        return result;
    }
}
