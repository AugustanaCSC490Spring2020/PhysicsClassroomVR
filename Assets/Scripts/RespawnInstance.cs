using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnInstance : MonoBehaviour
{
    public GameObject obj;
    public GameObject clone;
    private Vector3 location;
    public Vector3 limit;
    private Rigidbody rb;
    private Vector3 scale;
    private Vector3 rotation;
    private bool spawnable = false;


    private void Start()
    {
        location = transform.position;
        scale = transform.localScale;
        rotation = transform.localEulerAngles;

    }

    void LateUpdate()
    {

        if (Mathf.Abs(transform.localPosition.x) > limit.x ||
            (transform.localPosition.y < limit.y) ||
            Mathf.Abs(transform.localPosition.z) > limit.z)
        {
            clone = Instantiate<GameObject>(obj, location, Quaternion.identity, this.transform.parent);
            //clone.transform.parent = this.transform.parent;
            //clone.transform.position = location;
            clone.transform.localScale = scale;
            rb = clone.GetComponent<Rigidbody>();
            rb.velocity = new Vector3(0, 0, 0);
            rb.isKinematic = false;
            //clone.GetComponent<>
            enabled = false;
        }
        
        //Debug.Log(location.x + limit.x);
    }
    
}