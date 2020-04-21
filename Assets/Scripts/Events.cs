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
    public float thrust = 500;
    public GameObject projectile;

    private bool canBePressed = true;
    private float pressDelay = 0.5f;
    private float rotate;

    

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
        Instantiate(projectile, CannonCylinder.transform.position, 
            Quaternion.Euler(CannonCylinder.transform.localRotation.x, CannonCylinder.transform.localRotation.y, CannonCylinder.transform.localRotation.z));
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        rb.velocity = transform.TransformDirection(new Vector3(0,0, thrust));

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
