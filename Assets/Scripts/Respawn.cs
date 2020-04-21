using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{

    public GameObject obj;
    void LateUpdate()
    {
        if(obj.transform.position.y < -10)
        {
            obj.transform.position = new Vector3(2.263f, .9f, -12.285f);
        }
    }
}
