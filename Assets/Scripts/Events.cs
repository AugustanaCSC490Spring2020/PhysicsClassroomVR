using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Events : MonoBehaviour
{

    public TextMeshProUGUI massText;

    public void OnIncreaseMassButtonPress(GameObject obj)
    {
        
        Rigidbody rb = obj.GetComponent<Rigidbody>();
        obj.transform.localScale += new Vector3(.1f,.1f,.1f);
        rb.mass = rb.mass * 2f;
        massText.SetText("Mass: {0}kg", rb.mass);
    }

    public void OnDecreaseMassButtonPress(GameObject obj)
    {
        Rigidbody rb = obj.GetComponent<Rigidbody>();
        obj.transform.localScale -= new Vector3(.1f, .1f, .1f);
        rb.mass = rb.mass * .5f;
        massText.SetText("Mass: {0}kg", rb.mass);
    }

    public void OnFreeBodyButtonPress()
    {

    }
}
