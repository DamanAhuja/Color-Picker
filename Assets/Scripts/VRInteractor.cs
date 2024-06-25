/*using UnityEngine;
using UnityEngine.EventSystems;

public class VRInteractor : MonoBehaviour
{
    public OVRInput.Controller controller;

    private RaycastHit hit;
    private Ray ray;

    void Update()
    {
        ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray, out hit))
        {
            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, controller))
            {
                if (hit.collider.GetComponent<SvImageControl>())
                {
                    hit.collider.GetComponent<SvImageControl>().OnPointerClick(hit.point);
                }
            }

            if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger, controller))
            {
                if (hit.collider.GetComponent<SvImageControl>())
                {
                    hit.collider.GetComponent<SvImageControl>().OnPointerDrag(hit.point);
                }
            }
        }
    }
}*/

