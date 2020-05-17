using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSnapper : MonoBehaviour
{
    public float yRotation;

    private Grid grid;

    private void Awake()
    {
        grid = FindObjectOfType<Grid>();
    }

    //private void OnTriggerEnter(Collider collider)
    //{
    //    if (collider.gameObject.CompareTag("Ground"))
    //    {
    //        transform.position = grid.GetNearestPointOnGrid(transform.position);
    //    }
    //}

    private void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.CompareTag("Ground"))
        {
            transform.position = grid.GetNearestPointOnGrid(transform.position);
            transform.rotation = Quaternion.identity;

            //yRotation = transform.rotation.y;
            //float yRotationChange = yRotation % 45;
            //if(yRotationChange != 0)
            //{
            //    Debug.Log("dsfgnd");
            //    Vector3 rotate = new Vector3(0f, yRotation - yRotationChange, 0f);
            //    transform.Rotate(rotate);
            //}
        }
    }

}
