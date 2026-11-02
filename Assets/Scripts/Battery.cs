using UnityEngine;

public class Battery : MonoBehaviour
{
    private Color inactiveLightColor;
    private Color activeLightColor;
    private Light light;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        light = GetComponent<Light>();
        inactiveLightColor = light.color;
        activeLightColor = new Color(0, 1, 0);
    }

    public void OnPointerEnter()
    {
        light.color = activeLightColor;
    }

    public void OnPointerExit()
    {
        light.color = activeLightColor;
    }

    public void OnPointerClick()
    {
        
    }
}
