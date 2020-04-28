using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    private Vector3 location;
    public Vector3 limit;

    private void Start()
    {
        location = this.transform.position;
    }

    void LateUpdate()
    {

        if(this.transform.position.y < limit.y || this.transform.position.x < Mathf.Abs(limit.x) || 
            this.transform.position.z < Mathf.Abs(limit.z))
        {
            this.transform.position = location;
        }
    }
}
