using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    private Vector3 location;
    public Vector3 limit;
    private Rigidbody rb;

    private void Start()
    {
        location = transform.position;
        rb = this.GetComponent<Rigidbody>();
    }

    void LateUpdate()
    {

        if(Mathf.Abs(transform.localPosition.x) > limit.x || 
            (transform.localPosition.y < limit.y) ||
            Mathf.Abs(transform.localPosition.z) > limit.z)
        {
            this.transform.position = location;
            rb.velocity = new Vector3(0, 0, 0);
        }
        Debug.Log(location.x + limit.x);
    }
}
