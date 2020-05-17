using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static OVRInput;
using Button = UnityEngine.UI.Button;

public class LineRendererSettings : MonoBehaviour
{
    public LayerMask layerMask;
    public GameObject panel;
    public Image img;
    private UnityEngine.UI.Button btn;
    private GameObject obj;
    private GameObject objToInspect;

    [SerializeField] LineRenderer rend;

    Vector3[] points;


    // Start is called before the first frame update
    void Start()
    {
        rend = gameObject.GetComponent<LineRenderer>();

        points = new Vector3[2];

        points[0] = Vector3.zero;

        points[1] = transform.position + new Vector3(0, 0, 20);

        img = panel.GetComponent<Image>();

        rend.SetPositions(points);
        rend.enabled = true;
    }

    public bool AlignLineRender(LineRenderer rend)
    {
        bool isHit = false;
        Ray ray;
        ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit))
        {
            btn = hit.collider.gameObject.GetComponent<Button>();
            obj = hit.collider.gameObject;
            points[1] = transform.forward + new Vector3(0, 0, 20);
            rend.startColor = Color.red;
            rend.endColor = Color.red;
            isHit = true;
        }
        else
        {
            points[1] = transform.forward + new Vector3(0, 0, 20);
            rend.startColor = Color.green;
            rend.endColor = Color.green;
            isHit = false;
        }

        rend.SetPositions(points);
        rend.material.color = rend.startColor;
        return isHit;
    }


    void FixedUpdate()
    {
        OVRInput.FixedUpdate();
        AlignLineRender(rend);
        if(AlignLineRender(rend) && (Input.GetAxis("Oculus_CrossPlatform_SecondaryIndexTrigger") > .88f
            && (Input.GetAxis("Oculus_CrossPlatform_SecondaryIndexTrigger") < .99f)))
        {
            //btn.onClick.Invoke();
        } else if (layerMask == (layerMask | (1 << obj.layer))
            && AlignLineRender(rend) && OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.RTouch)) 
        {
            Quaternion change = Quaternion.Euler(obj.transform.localEulerAngles);
            change = change * Quaternion.Euler(0, 45, 0);
            obj.transform.rotation = change;
        } else if (layerMask == (layerMask | (1 << obj.layer))
          && AlignLineRender(rend) && OVRInput.Get(OVRInput.Button.One, OVRInput.Controller.LTouch))
        {
            Debug.Log("test1");
            obj.GetComponent<CircuitBehavior>().ChangeValue();

        }


    }

    //What Buttons Do.

}
