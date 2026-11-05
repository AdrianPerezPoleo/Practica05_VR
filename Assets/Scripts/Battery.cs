using UnityEngine;

public class Battery : MonoBehaviour
{
    private Color inactiveLightColor;
    private Color activeLightColor;
    private Light batteryLight; 

    void Start()
    {
        batteryLight = GetComponentInChildren<Light>();
        inactiveLightColor = batteryLight.color;
        activeLightColor = new Color(1, 0, 0);
    }


    public void OnPointerEnter()
    {
        batteryLight.color = activeLightColor;
    }

    public void OnPointerExit()
    {
        batteryLight.color = inactiveLightColor;
    }

    public void OnPointerClick()
    {
        Destroy(gameObject); 
    }
}
