using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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

    bool isProgressing;

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
        UpdateProgressSlider();
    }

    public void Clicked()
    {
        if(!isProgressing)
        {
            StartCoroutine(Progressing());
            isProgressing = true;
        }
        
    }
    public void UpdateProgressSlider()
    {
        float x = Mathf.Lerp(progressSliderMin, progressSliderMax, progress);
        progressSlider.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, x); 
    }
    private IEnumerator Progressing()
    {
        while (true)
        {
            progress += (Time.deltaTime / completeTime);
            if (progress >= 1)
            {
                Complete();
                yield break;
            }
            yield return null;
        }
    }
    private void Complete()
    {
        isProgressing = false;
        Player.instance.Money += reward;
        progress = 0;
    }
}
