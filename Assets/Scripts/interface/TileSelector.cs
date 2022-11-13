using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSelector
{
    public Camera MainCam;
    public LayerMask layerMask;

    // // \\ // \\ // \\
    public TileSelector(Camera _mainCam, LayerMask _layerMask, InterfaceManager _instance)
    {
        MainCam = _mainCam;
        this.layerMask = _layerMask;

        _instance.onMouseDown += OnMouseDown;
    }
    // \\ // \\ // \\ //

    // // \\ // \\ // \\
    private void OnMouseDown()
    {
        Ray ray = MainCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, 200f, layerMask))
        {
            Debug.Log("hit");
            GameObject other = hitInfo.transform.gameObject;
            other.layer = 9;
        }
    }
    // \\ // \\ // \\ //
}
