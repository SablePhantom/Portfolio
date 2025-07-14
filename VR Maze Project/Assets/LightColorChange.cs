using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Light))]
public class LightChangeColor : MonoBehaviour
{
    [SerializeField]
    int colorChangeInterval = 0; 

    Light mainLight;
    byte red = 0;
    byte green = 0;
    byte blue = 0;
    byte alpha = 255;

    int frameCount = 0;
    
    private void Awake(){
        mainLight = GetComponent<Light>();
        red = 255; 
        mainLight.color = new Color32 (red, green, blue, alpha);
        Debug.Log("Set main light color's R value to 255.");
    }

    void Update(){
        DoTimedRainbowLightingAnim(); 
    }

    private void DoTimedRainbowLightingAnim(){
        if (colorChangeInterval == 0){
            AnimateLightingInRainbow();
        }
        else if (colorChangeInterval != 0){
            frameCount++;
            if (frameCount == colorChangeInterval){
                AnimateLightingInRainbow();
                frameCount = 0;
            }
        }
    }

    private void AnimateLightingInRainbow(){
        if (red == 0 && green == 0 && blue == 0)
            red = 255;
        else if (red == 0 && green < 255 && blue == 255)
            green++;
        else if (red == 0 && green == 255 && blue > 0)
            blue--;
        else if (red == 255 && green == 0 && blue < 255)
            blue++;
        else if (red == 255 && green > 0 && blue == 0)
            green--;
        else if (red > 0 && green == 0 && blue == 255)
            red--;
        else if (red < 255 && green == 255 && blue == 0)
            red++;

        mainLight.color = new Color32(red, green, blue, alpha);
        Debug.Log("R value: " + red + " | G value: " + green + " | B value: " + blue);
    }
}