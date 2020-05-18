using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static OVRInput;
using TMPro;
using UnityEngine.SceneManagement;

public class CircuitCalculations: MonoBehaviour
{

    private string sceneName;

    public GameObject r1;
    public GameObject r2;
    public GameObject r3;
    public GameObject voltage;
    public GameObject wire;

    private Canvas canvas;
    private TextMeshProUGUI canvasText;
    private float r1Value;
    private float r2Value;
    private float r3Value;
    private float voltageValue;

    private void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;
        canvas = GetComponentInChildren<Canvas>();
        canvasText = canvas.GetComponentInChildren<TextMeshProUGUI>();

    }
    private void FixedUpdate()
    {
        r1Value = r1.GetComponent<CircuitBehavior>().value;
        r2Value = r2.GetComponent<CircuitBehavior>().value;
        r3Value = r3.GetComponent<CircuitBehavior>().value;
        voltageValue = voltage.GetComponent<CircuitBehavior>().value;
        canvasText.SetText("{0:2}", calculateCurrent());
    }

    public float calculateCurrent()
    {
        if (sceneName.Equals("Circuits 1"))
        {
            return voltageValue / GetTotalResistance();
        }
        else if (sceneName.Equals("Circuits 2"))
        {
            return voltageValue / GetTotalResistance();
        }
        else if (sceneName.Equals("Circuits 3"))
        {
            if (name.Equals("Wire2a") || name.Contains("Wire3a"))
            {
                return (voltageValue / GetTotalResistance()) * r2Value / (r1Value + r2Value);
            }
            if (name.Contains("Wire2b") || name.Contains("Wire3b"))
            {
                return (voltageValue / GetTotalResistance()) * r1Value / (r1Value + r2Value);
            }
            if (name.Contains("1") || name.Contains("5"))
            {
                return voltageValue / GetTotalResistance();
            }
            
        }
        else if (sceneName.Equals("Circuits 4"))
        {
            if (name.Equals("Wire2a") || name.Contains("Wire3a"))
            {
                return (voltageValue / GetTotalResistance()) * r2Value / (r1Value + r2Value);
            }
            if (name.Contains("Wire2b") || name.Contains("Wire3b"))
            {
                return (voltageValue / GetTotalResistance()) * r1Value / (r1Value + r2Value);
            }
            if (name.Contains("1") || name.Contains("6") || name.Contains("5"))
            {
                return voltageValue / GetTotalResistance();
            }
        }

        return 0f;
    }

    public float GetTotalResistance()
    {
        if (sceneName.Equals("Circuits 1"))
        {
            return r1Value;
        }
        else if (sceneName.Equals("Circuits 2"))
        {
            return r1Value + r2Value;
        }
        else if (sceneName.Equals("Circuits 3"))
        {
            return 1f / ((1f / r1Value) + (1f / r2Value));
        }
        else if (sceneName.Equals("Circuits 4"))
        {
            return (1f / ((1f / r1Value) + (1f / r2Value))) + r3Value;
        }

        return 0f;
    }



}
