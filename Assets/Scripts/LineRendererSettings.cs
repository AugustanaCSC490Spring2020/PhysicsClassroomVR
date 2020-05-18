using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static OVRInput;
using Button = UnityEngine.UI.Button;
using UnityEngine.SceneManagement;

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
            obj = hit.collider.gameObject;
            btn = obj.GetComponentInChildren<Button>();
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
        if (obj.CompareTag("SceneChanger") && AlignLineRender(rend))
        {
            if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.LTouch))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            }
            else if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.RTouch))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else if (OVRInput.GetDown(OVRInput.Button.Start, OVRInput.Controller.LTouch))
            {
                SceneManager.LoadScene(0);
            }
        } else if (layerMask == (layerMask | (1 << obj.layer))
            && AlignLineRender(rend) && (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.RTouch) > .1f))
        {
            btn.onClick.Invoke();
        } else if (layerMask == (layerMask | (1 << obj.layer))
            && AlignLineRender(rend) && OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.RTouch)) 
        {
            Quaternion change = Quaternion.Euler(obj.transform.localEulerAngles);
            change = change * Quaternion.Euler(0, 45, 0);
            obj.transform.rotation = change;
        } else if (layerMask == (layerMask | (1 << obj.layer))
          && AlignLineRender(rend) && OVRInput.Get(OVRInput.Button.One, OVRInput.Controller.LTouch))
        {
            obj.GetComponent<CircuitBehavior>().ChangeValue();
        } 


    }

    //What Buttons Do.

}
