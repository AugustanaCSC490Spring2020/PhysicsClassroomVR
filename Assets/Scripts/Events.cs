using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events : MonoBehaviour
{
    public void OnIncreaseMassButtonPress(GameObject obj)
    {
        Rigidbody rb = obj.GetComponent<Rigidbody>();
        obj.transform.localScale += new Vector3(.1f,.1f,.1f);
        rb.mass = rb.mass * 1.5f;
    }

    public void OnDecreaseMassButtonPress(GameObject obj)
    {
        Rigidbody rb = obj.GetComponent<Rigidbody>();
        obj.transform.localScale -= new Vector3(.1f, .1f, .1f);
        rb.mass = rb.mass * .5f;
    }

    public void OnFreeBodyButtonPress()
    {

    }
}
