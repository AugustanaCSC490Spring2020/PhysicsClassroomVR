using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdLaw : MonoBehaviour
{

    public GameObject arrow;
    public GameObject obj;
    private BoxCollider collider;
    private float displacement = 0;

    
    void Start()
    {
        collider = obj.GetComponent<BoxCollider>();
        arrow.SetActive(false);
        
    }

    
    void FixedUpdate()
    {
        arrow.transform.localScale = new Vector3(displacement, 1, 1);
    }

    private void OnCollisionEnter(Collision collision)
    {
        arrow.SetActive(true);
        displacement += .01f;
    }

    private void OnCollisionExit(Collision collision)
    {
        arrow.SetActive(false);
        displacement = 0;
    }
}
