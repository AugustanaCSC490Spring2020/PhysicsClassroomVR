using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSnapper : MonoBehaviour
{
    private Grid grid;

    private void Awake()
    {
        grid = FindObjectOfType<Grid>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Ground"))
        {
            transform.position.Set((float) Mathf.RoundToInt(transform.position.x),
                (float) Mathf.RoundToInt(transform.position.y),
                (float) Mathf.RoundToInt(transform.position.z));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
