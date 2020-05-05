using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Events : MonoBehaviour
{

    public TextMeshProUGUI angleText;
    public TextMeshProUGUI ballmassText;
    public TextMeshProUGUI cubemassText;
    public GameObject freeBodyArrow;
    public GameObject cannonCylinder;
    public int thrust = 10;
    public GameObject projectile;

    private bool canBePressed = true;
    private float pressDelay = 0.5f;
    private float cannonAngle = 30;

    

    public void OnIncreaseMassButtonPress(GameObject obj)
    {

        Rigidbody rb = obj.GetComponent<Rigidbody>();
        obj.transform.localScale += new Vector3(.05f, .05f, .05f);
        //obj.transform.localScale = obj.transform.localScale * Mathf.Pow(2f, 1f/3f);
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

    private void scaleCube(GameObject obj, float scaleFactor)
    {
        Rigidbody rb = obj.GetComponentInChildren<Rigidbody>();
        rb.mass = rb.mass * scaleFactor;
        cubemassText.SetText("Cube Mass: {0}kg", rb.mass);
    }

    public void OnIncreaseCubeMassButtonPress(GameObject obj)
    {
        scaleCube(obj, 2f);
    }

    public void OnDecreaseCubeMassButtonPress(GameObject obj)
    {
        scaleCube(obj, 0.5f);
    }



    public void OnFreeBodyButtonPress()
    {

            freeBodyArrow.SetActive(!freeBodyArrow.active);

    }

    public void OnLaunchPress()
    { 
        GameObject ball = Instantiate(projectile);
        ball.transform.position = cannonCylinder.transform.position + new Vector3(.8f, .5f, 0);
        Rigidbody rb = ball.GetComponent<Rigidbody>();
        //Thanks to Jason Weimann!
        //https://unity3d.college/2017/06/30/unity3d-cannon-projectile-ballistics/
        //
        //float velocity = Mathf.Sqrt(thrust * Physics.gravity.magnitude / Mathf.Sin(2 * Mathf.Deg2Rad * cannonAngle));
        float speed = thrust;
        Vector3 velocityVector = new Vector3(Mathf.Sqrt(Mathf.Cos(Mathf.Deg2Rad*cannonAngle)), Mathf.Sqrt(Mathf.Sin(Mathf.Deg2Rad*cannonAngle)), 0);
        rb.velocity = velocityVector * speed;
        Debug.Log(cannonAngle);

    }

    public void OnIncreaseAngle()
    {
            //if (cannonCylinder.transform.localEulerAngles.z < 180)
            //{
                Quaternion change = Quaternion.Euler(cannonCylinder.transform.localEulerAngles);
                change = change * Quaternion.Euler(0,0,1);
                cannonCylinder.transform.rotation = change;
                cannonAngle = (cannonCylinder.transform.rotation.eulerAngles.z + 90) % 360;
            //}
    }

    public void OnDecreaseAngle()
    {
        //if (cannonCylinder.transform.localEulerAngles.z < 180)
        //{
            Quaternion change = Quaternion.Euler(cannonCylinder.transform.localEulerAngles);
            change = change * Quaternion.Euler(0, 0, -1);
            cannonCylinder.transform.rotation = change;
            cannonAngle = (cannonCylinder.transform.rotation.eulerAngles.z + 90) % 360;
        //}


    }


    void Update()
    {
        
        //Debug.Log(cannonAngle - 90);
        angleText.SetText("Angle: {0} degrees", cannonAngle);

    }


}
