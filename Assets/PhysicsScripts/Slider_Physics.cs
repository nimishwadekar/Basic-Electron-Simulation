using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Slider_Physics : MonoBehaviour
{
    Electron[] electrons;

    Slider voltageSlider;
    public Text valueText;

    private void Start()
    {
        voltageSlider = GetComponent<Slider>();
        electrons = FindObjectsOfType<Electron>();
    }

    public void OnVoltageChange()
    {
        valueText.text = voltageSlider.value + " V";
        foreach (Electron electron in electrons)
        {
            electron.potentialDifference = voltageSlider.value;
        }
    }
}
