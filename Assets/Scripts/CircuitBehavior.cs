using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static OVRInput;
using TMPro;

public class CircuitBehavior : MonoBehaviour
{
    public float value = 5;
    public bool isResistor;
    private Canvas canvas;
    private TextMeshProUGUI canvasText;

    private void Start()
    {
        canvas = GetComponentInChildren<Canvas>();
        canvasText = canvas.GetComponentInChildren<TextMeshProUGUI>();
    }
    private void FixedUpdate()
    {
        canvasText.SetText("{0:1}", value);
    }

    public void ChangeValue()
    {
        
        Vector2 stickPos = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.RTouch);
        value = ((stickPos.y * 10f) + 10f) / 2f;
        Debug.Log(stickPos);
    }

    private void CalculateEquivalentValue()
    {

    }


}
