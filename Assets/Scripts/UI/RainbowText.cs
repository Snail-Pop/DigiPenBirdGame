using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RainbowText : MonoBehaviour
{
    float hSVColor = 0;
    public TextMeshProUGUI thisTMP;
    private void Start()
    {
        thisTMP = gameObject.GetComponent<TextMeshProUGUI>();
    }
    // Update is called once per frame
    void Update()
    {   
        hSVColor += Time.deltaTime / 2;
        if (hSVColor >= 1)
        {
            hSVColor = 0;
        }
        thisTMP.color = Color.HSVToRGB(hSVColor, 1, 1);
        print(hSVColor);
    }
}
