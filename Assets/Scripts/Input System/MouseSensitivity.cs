using UnityEngine;
using UnityEngine.UI;
public class MouseSensitivity : MonoBehaviour
{
    public Slider slider;
    public PlayerLook playerlook;
 
    void Start()
    {
        if (slider != null)
        {
            slider.value = playerlook.xSensitivity;
            slider.onValueChanged.AddListener(updateSlider);
        }
    }
    private void updateSlider(float newSensitivity)
    {
        
        playerlook.xSensitivity = newSensitivity;
        playerlook.ySensitivity = newSensitivity;
    }
}
