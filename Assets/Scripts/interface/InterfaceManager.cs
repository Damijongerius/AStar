using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceManager : MonoBehaviour
{
    public Camera MainCam;

    void Update()
    {
        Ray ray = MainCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo))
        {
            GameObject other = hitInfo.rigidbody.gameObject;
        }
}
