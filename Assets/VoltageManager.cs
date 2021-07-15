using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class VoltageManager : MonoBehaviour
{
    ElectronForce[] electrons;
    ElectronSpawner[] electronSpawners;

    Slider voltageSlider;
    public Text valueText;
    float oldVoltage, oldOldVoltage;

    private void Start()
    {
        oldVoltage = 5;
        voltageSlider = GetComponent<Slider>();
        electronSpawners = FindObjectsOfType<ElectronSpawner>();
        float maxWait = electronSpawners.Max(spawner => spawner.waitTime + spawner.count * spawner.spawnTimeInterval) + 0.1f;
        StartCoroutine(FindElectrons(maxWait));
    }

    IEnumerator FindElectrons(float maxWait)
    {
        if (maxWait > 0) yield return new WaitForSeconds(maxWait);

        electrons = FindObjectsOfType<ElectronForce>();
    }

    public void OnVoltageChange()
    {
        valueText.text = voltageSlider.value + " V";

        if(voltageSlider.value == 0)
        {
            foreach (ElectronForce electron in electrons)
            {
                electron.enabled = false;
            }
            oldOldVoltage = oldVoltage;
            oldVoltage = voltageSlider.value;
            return;
        }

        float factor = oldVoltage / voltageSlider.value;
        bool oldZero = false;
        if (oldVoltage == 0)
        {
            oldZero = true;
            factor = oldOldVoltage / voltageSlider.value;
        }
        foreach (ElectronForce electron in electrons)
        {
            if (oldZero) electron.enabled = true;
            electron.time *= factor;
            electron.currentTime *= factor;
        }
        oldOldVoltage = oldVoltage;
        oldVoltage = voltageSlider.value;
    }
}
