using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HammerTimeBarScript : MonoBehaviour
{
    [SerializeField] private Image radialImage;
    [SerializeField] private Gradient gradientColor;

    private float currentTime;

    // Update is called once per frame
    void Update()
    {
        currentTime = HammerScript.instance.GetTimeLeft() / HammerScript.instance.hammerTime;
        radialImage.fillAmount = currentTime;
        radialImage.color = gradientColor.Evaluate(currentTime);
    }
}
