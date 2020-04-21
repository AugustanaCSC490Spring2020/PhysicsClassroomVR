using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    private Vector3 location;
    public float limit;

    private void Start()
    {
        location = this.transform.position;
    }

    void LateUpdate()
    {

        if(this.transform.position.y < limit)
        {
            this.transform.position = location;
        }
    }
}
