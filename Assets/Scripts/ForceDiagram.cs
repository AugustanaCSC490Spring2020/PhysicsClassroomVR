using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceDiagram : MonoBehaviour
{
    public GameObject arrow;
    public GameObject obj;
    private Rigidbody rb; 
    

    void Start()
    {
        rb = obj.GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        if (!rb.velocity.Equals(new Vector3(0,0,0)))
        {
            Vector3 rotation = new Vector3(rb.velocity.x - obj.transform.localRotation.x, 
                rb.velocity.y - obj.transform.localRotation.y, rb.velocity.z - obj.transform.localRotation.z);
            arrow.transform.Rotate(rotation);
            arrow.transform.localScale = new Vector3(0.29f + rb.velocity.magnitude, 1, 1);
        }
    }
}
