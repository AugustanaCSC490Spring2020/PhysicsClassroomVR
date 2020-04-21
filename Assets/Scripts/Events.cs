using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Events : MonoBehaviour
{

    public TextMeshProUGUI angleText;
    public TextMeshProUGUI massText;
    public GameObject FreeBodyArrow;
    public GameObject CannonCylinder;
    public float thrust = 500;
    public GameObject projectile;

    private bool canBePressed = true;
    private float pressDelay = 0.5f;
    private float rotate;

    

    public void OnIncreaseMassButtonPress(GameObject obj)
    {
        float lastPressTime = 0;
        if(lastPressTime + pressDelay > Time.unscaledTime)
        {
            Rigidbody rb = obj.GetComponent<Rigidbody>();
            obj.transform.localScale += new Vector3(.1f, .1f, .1f);
            rb.mass = rb.mass * 2f;
            massText.SetText("Mass: {0}kg", rb.mass);
        }
        lastPressTime = Time.unscaledTime;
        
    }

    public void OnDecreaseMassButtonPress(GameObject obj)
    {
        float lastPressTime = 0;
        if (lastPressTime + pressDelay > Time.unscaledTime)
        {
            Rigidbody rb = obj.GetComponent<Rigidbody>();
            obj.transform.localScale -= new Vector3(.1f, .1f, .1f);
            rb.mass = rb.mass * .5f;
            massText.SetText("Mass: {0}kg", rb.mass);
        }
        lastPressTime = Time.unscaledTime;
    }

    public void OnFreeBodyButtonPress()
    {
        float lastPressTime = 0;
        if (lastPressTime + pressDelay > Time.unscaledTime)
        {
            FreeBodyArrow.SetActive(!FreeBodyArrow.active);
        }
        lastPressTime = Time.unscaledTime;
    }

    public void OnLaunchPress()
    { 
        Instantiate(projectile, CannonCylinder.transform.position, Quaternion.Euler(0f, 90f, 0f));
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        rb.AddForce(CannonCylinder.transform.forward * thrust);

    }

    public void OnIncreaseAngle()
    {
            if (CannonCylinder.transform.localEulerAngles.z < 360)
            {
                CannonCylinder.transform.Rotate(new Vector3(0, 0, CannonCylinder.transform.localEulerAngles.z + 1));
            }
    }

    public void OnDecreaseAngle()
    {
            if (CannonCylinder.transform.localEulerAngles.z > 270)
            {
                CannonCylinder.transform.Rotate(new Vector3(0, 0, CannonCylinder.transform.localEulerAngles.z - 1));
            }
        
        
    }


    void Update()
    {
        rotate = CannonCylinder.transform.localEulerAngles.z;
        Debug.Log(rotate);
        angleText.SetText("Angle: {0} degrees", rotate - 270);

    }


}
