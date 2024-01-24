using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum StoreState {Locked,Idle,Running,Disabled}

public class Store : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Image shopImg;
    [SerializeField] private Sprite shopSprite;
    [SerializeField] private TextMeshProUGUI shopText;
    [SerializeField] private string shopName;

    [SerializeField] private RectTransform progressSlider;

    [SerializeField] private float progressSliderMin;
    [SerializeField] private float progressSliderMax;

    [SerializeField]
    [Range(0f, 1f)]
    private float progress;

    [SerializeField] private float completeTime;
    [SerializeField] private float reward;

    bool wasClicked;
    bool isAuto;

    StoreState state;

    // Properties
    public float Progress
    {
        get
        {
            return progress;
        }
        set
        {
            progress = Mathf.Clamp(value,0,1);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        shopText.text = shopName;
        shopImg.sprite = shopSprite;
    }

    // Update is called once per frame
    void Update()
    {
        if(wasClicked || isAuto)
        {
            ProgressTick();
        }
        UpdateProgressSlider();
    }

    public void Clicked()
    {
        if(!wasClicked && !isAuto)
        {
            
            wasClicked = true;
        }
        
    }
    public void UpdateProgressSlider()
    {
        float x = Mathf.Lerp(progressSliderMin, progressSliderMax, Progress);
        progressSlider.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, x); 
    }
    private void ProgressTick()
    {
        Progress += (Time.deltaTime / completeTime);
        if (Progress >= 1)
        {
            Complete();
            return;
        }
    }
    private void Complete()
    {
        wasClicked = false;
        Player.instance.Money += reward;
        Progress = 0;
    }
}
