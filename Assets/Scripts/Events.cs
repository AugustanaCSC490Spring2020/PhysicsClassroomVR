using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Events : MonoBehaviour
{

    public TextMeshProUGUI angleText;
    public TextMeshProUGUI ballmassText;
    public TextMeshProUGUI cubemassText;
    public GameObject FreeBodyArrow;
    public GameObject CannonCylinder;
    public int thrust = 10;
    public GameObject projectile;

    private bool canBePressed = true;
    private float pressDelay = 0.5f;
    private float cannonAngle = 120;

    

    public void OnIncreaseMassButtonPress(GameObject obj)
    {

        Rigidbody rb = obj.GetComponent<Rigidbody>();
        obj.transform.localScale += new Vector3(.05f, .05f, .05f);
        rb.mass = rb.mass * 2f;
        ballmassText.SetText("Ball Mass: {0}kg", rb.mass);

        
    }

    public void OnDecreaseMassButtonPress(GameObject obj)
    {

            Rigidbody rb = obj.GetComponent<Rigidbody>();
            obj.transform.localScale -= new Vector3(.05f, .05f, .05f);
            rb.mass = rb.mass * .5f;
            ballmassText.SetText("Ball Mass: {0}kg", rb.mass);

    }


    public void OnIncreaseCubeMassButtonPress(GameObject obj)
    {

        Rigidbody rb = obj.GetComponentInChildren<Rigidbody>();
        rb.mass = rb.mass * 2f;
        cubemassText.SetText("Cube Mass: {0}kg", rb.mass);


    }

    public void OnDecreaseCubeMassButtonPress(GameObject obj)
    {

        Rigidbody rb = obj.GetComponentInChildren<Rigidbody>();
        rb.mass = rb.mass * .5f;
        cubemassText.SetText("Cube Mass: {0}kg", rb.mass);

    }



    public void OnFreeBodyButtonPress()
    {

            FreeBodyArrow.SetActive(!FreeBodyArrow.active);

    }

    public void OnLaunchPress()
    { 
        //Instantiate(projectile, CannonCylinder.transform.position + new Vector3(.5f,.5f,0), 
        //   Quaternion.Euler(CannonCylinder.transform.localEulerAngles));
        GameObject ball = Instantiate(projectile);
        ball.transform.position = CannonCylinder.transform.position + new Vector3(.8f, .5f, 0);
        Rigidbody rb = ball.GetComponent<Rigidbody>();
        //Thanks to Jason Weimann!
        //https://unity3d.college/2017/06/30/unity3d-cannon-projectile-ballistics/
        //
        float velocity = Mathf.Sqrt(thrust * Physics.gravity.magnitude / Mathf.Sin(2 * cannonAngle));
        Vector3 velocityVector = new Vector3(Mathf.Sqrt(Mathf.Cos(cannonAngle)), Mathf.Sqrt(Mathf.Sin(cannonAngle)), 0);
        rb.velocity = velocityVector * velocity;
        Debug.Log(rb.velocity);
        //rb.AddRelativeForce(velocityVector, ForceMode.Impulse);

    }

    public void OnIncreaseAngle()
    {
            if (CannonCylinder.transform.localEulerAngles.z < 180)
            {
                Quaternion change = Quaternion.Euler(CannonCylinder.transform.localEulerAngles);
                change = change * Quaternion.Euler(0,0,1);
                CannonCylinder.transform.rotation = change;
                cannonAngle = CannonCylinder.transform.rotation.eulerAngles.z;
            }
    }

    public void OnDecreaseAngle()
    {
        if (CannonCylinder.transform.localEulerAngles.z < 180)
        {
            Quaternion change = Quaternion.Euler(CannonCylinder.transform.localEulerAngles);
            change = change * Quaternion.Euler(0, 0, -1);
            CannonCylinder.transform.rotation = change;
            cannonAngle = CannonCylinder.transform.rotation.eulerAngles.z;
        }


    }


    void Update()
    {
        
        //Debug.Log(cannonAngle - 90);
        angleText.SetText("Angle: {0} degrees", cannonAngle - 90);

    }


}
